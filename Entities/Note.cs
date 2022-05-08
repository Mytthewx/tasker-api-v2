using System.Collections.Generic;
using TaskerAPI.Models.ViewModel;

namespace TaskerAPI.Entities;

public class Note : NoteViewModel
{
    public int Id { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }

    public List<Reminder> Reminders { get; set; } = new();
}
