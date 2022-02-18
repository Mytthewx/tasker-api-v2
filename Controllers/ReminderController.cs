﻿using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services;

namespace TaskerAPI.Controllers
{
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
		public IActionResult GetAll()
		{
			return Ok(_reminderService.GetAll());
		}

		[HttpGet]
		[Route("id")]
		public IActionResult Get(int id)
		{
			return Ok(_reminderService.Get(id));
		}

		[HttpPost]
		public IActionResult Create(ReminderCreate reminderCreate)
		{
			return Ok(_reminderService.Create(reminderCreate));
		}

		[HttpDelete]
		[Route("id")]
		public IActionResult Delete(int id)
		{
			if (_reminderService.Delete(id) == false)
			{
				return NotFound();
			}

			return Ok();
		}

		[HttpPut]
		[Route("id")]
		public Reminder Update(int id, ReminderUpdate reminderUpdate)
		{
			return _reminderService.Update(id, reminderUpdate);
		}
	}
}
