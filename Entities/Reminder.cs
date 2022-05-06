﻿using TaskerAPI.Models.Create;

namespace TaskerAPI.Entities;

public class Reminder : ReminderViewModel
{
    public int Id { get; set; }

    public Note Note { get; set; }
    public int NoteId { get; set; }
}
