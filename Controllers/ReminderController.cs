using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Controllers;

[Authorize]
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
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_reminderService.Get(id));
    }

    [HttpPost]
    public IActionResult Create(ReminderViewModel reminderCreate)
    {
        return Ok(_reminderService.Create(reminderCreate));
    }

    [HttpDelete]
    [Route("id")]
    public IActionResult Delete(int id)
    {
        return _reminderService.Delete(id) ? Ok() : NotFound();
    }

    [HttpPut]
    [Route("id")]
    public IActionResult Update(int id, ReminderUpdate reminderUpdate)
    {
        return Ok(_reminderService.Update(id, reminderUpdate));
    }
}
