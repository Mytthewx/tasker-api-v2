using System.Collections.Generic;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Services.Interfaces;

public interface IReminderService
{
    IEnumerable<ReminderViewModel> GetAll();
    ReminderViewModel Get(int id);
    Reminder Create(ReminderViewModel reminder);
    bool Delete(int id);
    Reminder Update(int id, ReminderUpdate reminderUpdate);
}
