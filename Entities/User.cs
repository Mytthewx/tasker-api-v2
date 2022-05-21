using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();
        public List<Cost> Costs { get; set; } = new List<Cost>();
    }
}
