using System.Collections.Generic;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Services.Interfaces;

public interface INoteService
{
    IEnumerable<NoteViewModel> GetAll();
    NoteViewModel Get(int id);
    Task<int> Create(NoteViewModel note);
    bool Delete(int id);
    Note Update(int id, NoteUpdate noteUpdate);
}
