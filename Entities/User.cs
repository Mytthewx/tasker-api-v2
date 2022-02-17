using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskerAPI
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		
		public List<Note> Notes { get; set; }
	}
}
