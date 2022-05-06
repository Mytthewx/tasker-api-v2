using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Services;

public class NoteService : INoteService
{
    private const string NoteNotFoundMessage = "Note with this id doesn't exist.";
    private readonly IMapper _mapper;
    private readonly TaskerContext db;



    public NoteService(TaskerContext taskerContext, IMapper mapper)
    {
        db = taskerContext;
        _mapper = mapper;
    }

    public IEnumerable<NoteViewModel> GetAll()
    {
        var notes = db.Notes.Include(n => n.Reminders).ToList();
        var result = _mapper.Map<IEnumerable<NoteViewModel>>(notes);
        return result;
    }

    public NoteViewModel Get(int id)
    {
        var note = db.Notes.FirstOrDefault(x => x.Id == id);
        if (note == null)
        {
            throw new Exception(NoteNotFoundMessage);
        }
        var result = _mapper.Map<NoteViewModel>(note);
        return result;

    }

    public async Task<Note> Create(NoteViewModel note)
    {
        var createNote = _mapper.Map<Note>(note);
        db.Notes.Add(createNote);
        db.SaveChanges();
        return createNote;
    }

    public bool Delete(int id)
    {
        var note = db.Notes.FirstOrDefault(x => x.Id == id);
        if (note == null)
        {
            return false;
        }

        db.Notes.Remove(note);
        db.SaveChanges();
        return true;
    }

    public Note Update(int id, NoteUpdate newNote)
    {
        var note = db.Notes.FirstOrDefault(x => x.Id == id);
        if (note == null)
        {
            throw new Exception(NoteNotFoundMessage);
        }

        note.Title = newNote.Title;
        note.Content = newNote.Content;
        note.CreationDate = newNote.CreationDate;

        db.SaveChanges();
        return note;
    }
}
