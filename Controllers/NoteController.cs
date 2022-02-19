using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_noteService.GetAll());
    }

    [HttpGet]
    [Route("id")]
    public IActionResult Get(int id)
    {
        return Ok(_noteService.Get(id));
    }

    [HttpPost]
    public IActionResult Create(NoteCreate noteCreate)
    {
        return Ok(_noteService.Create(noteCreate));
    }

    [HttpDelete]
    [Route("id")]
    public IActionResult Delete(int id)
    {
        return _noteService.Delete(id) ? Ok() : NotFound();
    }

    [HttpPut]
    [Route("id")]
    public IActionResult Update(int id, NoteUpdate noteUpdate)
    {
        return Ok(_noteService.Update(id, noteUpdate));
    }
}