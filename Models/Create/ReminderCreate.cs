using System;

namespace TaskerAPI.Models.Create;

public class ReminderCreate
{
    public string Label { get; set; }
    public DateTime Date { get; set; }
    public int NoteId { get; set; }
}