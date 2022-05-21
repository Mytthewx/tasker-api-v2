using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TaskerAPI.Entities;

namespace TaskerAPI.Models;

public class TaskerContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TaskerContext(DbContextOptions<TaskerContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cost> Costs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(user =>
        {
            user.HasMany(u => u.Notes).WithOne(n => n.User).HasForeignKey(n => n.UserId);
            user.HasMany(u => u.Costs).WithOne(c => c.User).HasForeignKey(c => c.UserId);
        });

        builder.Entity<Note>(note =>
        {
            note.HasMany(n => n.Reminders).WithOne(r => r.Note).HasForeignKey(r => r.NoteId);
        });
    }
}
