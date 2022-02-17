using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services;

namespace TaskerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReminderController : ControllerBase
{
	private readonly IReminderService _reminderService;

	public ReminderController(IReminderService reminderService)
	{
		_reminderService = reminderService;
	}

	[HttpGet]
	public IEnumerable<Reminder> GetAll()
	{
		return _reminderService.GetAll();
	}

	[HttpGet]
	[Route("id")]
	public Reminder Get(int id)
	{
		return _reminderService.Get(id);
	}

	[HttpPost]
	public Reminder Create(ReminderCreate reminderCreate)
	{
		return _reminderService.Create(reminderCreate);
	}

	[HttpDelete]
	[Route("id")]
	public void Delete(int id)
	{
		_reminderService.Delete(id);
	}

	[HttpPost]
	[Route("id")]
	public Reminder Update(int id, ReminderUpdate reminderUpdate)
	{
		return _reminderService.Update(id, reminderUpdate);
	}
}
