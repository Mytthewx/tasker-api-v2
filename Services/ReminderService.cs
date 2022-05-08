using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Update;
using TaskerAPI.Models.ViewModel;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Services;

public class ReminderService : IReminderService
{
    private const string ReminderNotFoundMessage = "Reminder with this id doesn't exist.";
    private readonly IMapper _mapper;
    private readonly TaskerContext db;


    public ReminderService(TaskerContext taskerContext, IMapper mapper)
    {
        db = taskerContext;
        _mapper = mapper;
    }

    public IEnumerable<ReminderViewModel> GetAll()
    {
        var reminders = db.Reminders.ToList();
        return _mapper.Map<IEnumerable<ReminderViewModel>>(reminders);
    }

    public ReminderViewModel Get(int id)
    {
        var reminder = db.Reminders.FirstOrDefault(x => x.Id == id);
        if (reminder == null)
        {
            throw new Exception(ReminderNotFoundMessage);
        }

        var result = _mapper.Map<ReminderViewModel>(reminder);
        return result;

    }

    public async Task<int> Create(ReminderViewModel reminder, int noteId)
    {
        var createReminder = _mapper.Map<Reminder>(reminder);
        createReminder.NoteId = noteId;
        await db.Reminders.AddAsync(createReminder);
        await db.SaveChangesAsync();
        return createReminder.Id;
    }

    public bool Delete(int id)
    {
        var reminder = db.Reminders.FirstOrDefault(x => x.Id == id);
        if (reminder == null)
        {
            return false;
        }

        db.Reminders.Remove(reminder);
        db.SaveChanges();
        return true;
    }

    public Reminder Update(int id, ReminderUpdate newReminder)
    {
        var reminder = db.Reminders.FirstOrDefault(x => x.Id == id);
        if (reminder == null)
        {
            throw new Exception(ReminderNotFoundMessage);
        }

        reminder.Label = newReminder.Label;
        reminder.Date = newReminder.Date;

        db.SaveChanges();
        return reminder;
    }
}
