using System;

namespace TaskerAPI.Models.Create
{
    public class NoteCreate
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
    }
}
