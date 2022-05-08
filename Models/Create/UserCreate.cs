using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Models.Create;

public class UserCreate
{
    public string Username { get; set; }
    public string Password { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}
