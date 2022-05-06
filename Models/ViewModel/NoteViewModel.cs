using System;
using System.Collections.Generic;

namespace TaskerAPI.Models.Create;

public class NoteViewModel
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }

    public IEnumerable<ReminderViewModel> Reminders { get; set; }
}
