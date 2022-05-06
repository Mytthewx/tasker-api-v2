﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Services.Interfaces;

public interface IReminderService
{
    IEnumerable<ReminderViewModel> GetAll();
    ReminderViewModel Get(int id);
    Task<int> Create(ReminderViewModel reminder, int noteId);
    bool Delete(int id);
    Reminder Update(int id, ReminderUpdate reminderUpdate);
}
