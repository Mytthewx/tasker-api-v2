using System;

namespace TaskerAPI.Models.Update;

public class NoteUpdate
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
}
