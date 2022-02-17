using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Services;

public class ReminderService : IReminderService
{
	private const string REMINDER_NOT_FOUND_MESSAGE = "Reminder with this id doesn't exist.";
	private readonly TaskerContext db;
	private readonly IMapper _mapper;

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
		return db.Reminders.FirstOrDefault(x => x.Id == id) ?? throw new Exception(REMINDER_NOT_FOUND_MESSAGE);
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
			throw new Exception(REMINDER_NOT_FOUND_MESSAGE);
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
			throw new Exception(REMINDER_NOT_FOUND_MESSAGE);
		}
		
		reminder.Label = newReminder.Label;
		reminder.Date = newReminder.Date;

		db.SaveChanges();
		return reminder;
	}
}
