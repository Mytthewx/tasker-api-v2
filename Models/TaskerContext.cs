﻿using Microsoft.EntityFrameworkCore;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>()
            .HasOne(n => n.User)
            .WithMany(n => n.Notes)
            .HasForeignKey(n => n.UserId);

        modelBuilder.Entity<Reminder>()
            .HasOne(r => r.Note)
            .WithMany(r => r.Reminders)
            .HasForeignKey(r => r.NoteId);
    }
}
