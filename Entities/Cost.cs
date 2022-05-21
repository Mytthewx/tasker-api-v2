using System;

namespace TaskerAPI.Entities;

public class Cost
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string Price { get; set; }
    public DateTime DateTime { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }
}