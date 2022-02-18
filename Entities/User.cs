using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskerAPI.Models.Create;

namespace TaskerAPI
{
	public class User : UserCreate
	{
		public int Id { get; set; }

		public List<Note> Notes { get; set; }
	}
}
