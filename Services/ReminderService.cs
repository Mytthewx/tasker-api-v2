using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
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

    public IEnumerable<Reminder> GetAll()
    {
        return db.Reminders.ToList();
    }

    public Reminder Get(int id)
    {
        return db.Reminders.FirstOrDefault(x => x.Id == id) ?? throw new Exception(ReminderNotFoundMessage);
    }

    public Reminder Create(ReminderCreate reminder)
    {
        var createReminder = _mapper.Map<Reminder>(reminder);
        db.Reminders.Add(createReminder);
        db.SaveChanges();
        return createReminder;
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