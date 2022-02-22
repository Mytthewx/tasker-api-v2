using System.Collections.Generic;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Services.Interfaces;

public interface INoteService
{
    IEnumerable<Note> GetAll();
    Note Get(int id);
    Note Create(NoteCreate note);
    bool Delete(int id);
    Note Update(int id, NoteUpdate noteUpdate);
}
