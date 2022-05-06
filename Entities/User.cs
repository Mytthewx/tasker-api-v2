using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace TaskerAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
