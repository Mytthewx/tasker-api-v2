using System.Collections.Generic;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Services;

public interface IReminderService
{
	IEnumerable<Reminder> GetAll();
	Reminder Get(int id);
	Reminder Create(ReminderCreate reminder);
	bool Delete(int id);
	Reminder Update(int id, ReminderUpdate reminderUpdate);
}
