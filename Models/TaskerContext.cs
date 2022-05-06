using Microsoft.EntityFrameworkCore;
using TaskerAPI.Entities;

namespace TaskerAPI.Models;

public class TaskerContext : DbContext
{
    public TaskerContext(DbContextOptions<TaskerContext> options) : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.Entity<ApplicationUser>(user =>
        //{
        //    user.HasMany(u => u.Notes)
        //        .WithOne(n => n.ApplicationUser)
        //        .HasForeignKey(n => n.ApplicationUserId);
        //});

        builder.Entity<Note>(note =>
        {
            note.HasMany(n => n.Reminders).WithOne(r => r.Note).HasForeignKey(r => r.NoteId);
        });
    }
}
