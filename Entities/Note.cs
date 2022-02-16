using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskerAPI
{
	public class Note
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreationDate { get; set; }
		
		public int UserId { get; set; }
		public User User { get; set; }
		public List<Reminder> Reminders { get; set; }
	}
}