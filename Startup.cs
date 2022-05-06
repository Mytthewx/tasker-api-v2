using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json.Serialization;
using TaskerAPI.Models;
using TaskerAPI.Services;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson()
            .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddDbContext<TaskerContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TaskerDb")));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskerAPI", Version = "v1" });
        });

        services.AddScoped<TaskerDatabaseSeeder>();
        services.AddScoped<INoteService, NoteService>();
        services.AddScoped<IReminderService, ReminderService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TaskerDatabaseSeeder seeder)
    {
        seeder.Seed();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskerAPI v1"));
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
