using TaskerAPI.Models.Create;
using TaskerAPI.Models.ViewModel;

namespace TaskerAPI.Entities;

public class Reminder : ReminderViewModel
{
    public int Id { get; set; }

    public Note Note { get; set; }
    public int NoteId { get; set; }
}
