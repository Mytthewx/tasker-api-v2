using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Services;

namespace TaskerAPI.Controllers
{
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
        public IEnumerable<Note> GetAll()
        {
            return _noteService.GetAll();
        }
    }
}
