using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskerAPI.Models.Update;
using TaskerAPI.Models.ViewModel;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Controllers;

[Authorize]
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
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_noteService.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(NoteViewModel noteCreate)
    {
        return Ok(await _noteService.Create(noteCreate));
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        return _noteService.Delete(id) ? Ok() : NotFound();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(int id, NoteUpdate noteUpdate)
    {
        return Ok(_noteService.Update(id, noteUpdate));
    }
}
