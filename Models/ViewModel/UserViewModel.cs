using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Models.ViewModel
{
    public class UserViewModel
    {
        public string Username { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

        public IEnumerable<NoteViewModel> Notes { get; set; }
        public IEnumerable<CostViewModel> Costs { get; set; }
    }
}
