using System.Collections.Generic;
using TaskerAPI.Models.Create;

namespace TaskerAPI;

public class Note : NoteCreate
{
	public int Id { get; set; }

	public User User { get; set; }
	public List<Reminder> Reminders { get; set; }
}