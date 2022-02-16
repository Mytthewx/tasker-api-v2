using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskerAPI.Models;

namespace TaskerAPI.Services;

public class NoteService : INoteService
{
	private readonly TaskerContext _taskerContext;

	public NoteService(TaskerContext taskerContext)
	{
		_taskerContext = taskerContext;
	}

	public IEnumerable<Note> GetAll()
	{
		return _taskerContext.Notes.Include(x => x.User).ToList();
	}
}