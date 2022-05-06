using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Entities;

public class Note : NoteViewModel
{
    public int Id { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }
    [JsonIgnore]
    [IgnoreDataMember]
    public List<Reminder> Reminders { get; set; } = new List<Reminder>();
}
