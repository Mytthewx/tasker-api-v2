using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Models.Update;

public class UserUpdate
{
    public string Login { get; set; }
    public string Password { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
}
