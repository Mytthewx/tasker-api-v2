using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public async Task<IActionResult> Create(ReminderViewModel reminderCreate, int noteId)
    {
        return Ok(await _reminderService.Create(reminderCreate, noteId));
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
