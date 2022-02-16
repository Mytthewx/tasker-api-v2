using System.Collections.Generic;

namespace TaskerAPI.Services;

public interface INoteService
{
	IEnumerable<Note> GetAll();
}
