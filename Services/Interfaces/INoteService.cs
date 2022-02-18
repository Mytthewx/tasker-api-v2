using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Services;

public interface INoteService
{
	IEnumerable<Note> GetAll();
	Note Get(int id);
	Note Create(NoteCreate note);
	bool Delete(int id);
	Note Update(int id, NoteUpdate noteUpdate);
}
