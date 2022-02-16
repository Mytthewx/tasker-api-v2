using System;

namespace TaskerAPI
{
	public class Reminder
	{
		public int Id { get;}
		public string Label { get; set; }
		public DateTime Date { get; set; }
		
		public int NoteId { get; set; }
		public Note Note { get; set; }
	}
}
