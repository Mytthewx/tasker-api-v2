using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace TaskerAPI.Services;

public class NoteService : INoteService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string NoteNotFoundMessage = "Note with this id doesn't exist.";
    private readonly IMapper _mapper;
    private readonly TaskerContext _db;


    public NoteService(TaskerContext taskerContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _db = taskerContext;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public IEnumerable<NoteViewModel> GetAll()
    {
        var notes = _db.Notes.Include(n => n.Reminders).ToList();
        var result = _mapper.Map<IEnumerable<NoteViewModel>>(notes);
        return result;
    }

    public NoteViewModel Get(int id)
    {
        var note = _db.Notes.FirstOrDefault(x => x.Id == id);
        if (note == null)
        {
            throw new Exception(NoteNotFoundMessage);
        }
        var result = _mapper.Map<NoteViewModel>(note);
        return result;

    }

    public async Task<int> Create(NoteViewModel note)
    {
        var createNote = _mapper.Map<Note>(note);
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        createNote.UserId = int.Parse(userId);
        await _db.Notes.AddAsync(createNote);
        await _db.SaveChangesAsync();
        return createNote.Id;
    }

    public bool Delete(int id)
    {
        var note = _db.Notes.FirstOrDefault(x => x.Id == id);
        if (note == null)
        {
            return false;
        }

        _db.Notes.Remove(note);
        _db.SaveChanges();
        return true;
    }

    public Note Update(int id, NoteUpdate newNote)
    {
        var note = _db.Notes.FirstOrDefault(x => x.Id == id);
        if (note == null)
        {
            throw new Exception(NoteNotFoundMessage);
        }

        note.Title = newNote.Title;
        note.Content = newNote.Content;
        note.CreationDate = newNote.CreationDate;

        _db.SaveChanges();
        return note;
    }
}
