using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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
        
        services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskerAPI", Version = "v1" }));

        services.AddScoped<TaskerDatabaseSeeder>();
        services.AddScoped<INoteService, NoteService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IReminderService, ReminderService>();

        services.AddDbContext<TaskerContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TaskerContext")));
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
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
