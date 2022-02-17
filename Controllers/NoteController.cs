using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
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

        [HttpGet]
        [Route("id")]
        public Note Get(int id)
        {
            return _noteService.Get(id);
        }

        [HttpPost]
        public Note Create(NoteCreate noteCreate)
        {
            return _noteService.Create(noteCreate);
        }

        [HttpDelete]
        [Route("id")]
        public void Delete(int id)
        {
            _noteService.Delete(id);
        }

        [HttpPost]
        [Route("id")]
        public Note Update(int id, NoteUpdate noteUpdate)
        {
            return _noteService.Update(id, noteUpdate);
        }
    }
}
