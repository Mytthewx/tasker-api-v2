using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Models.ViewModel
{
    public class UserViewModel
    {
        public string Username { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

        public IEnumerable<NoteViewModel> Notes { get; set; }
    }
}
