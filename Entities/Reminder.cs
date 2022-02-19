using TaskerAPI.Models.Create;

namespace TaskerAPI.Entities;

public class Reminder : ReminderCreate
{
    public int Id { get; set; }
    public Note Note { get; set; }
}