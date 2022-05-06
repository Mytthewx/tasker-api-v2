using System.Collections.Generic;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Models.ViewModel;

namespace TaskerAPI.Services.Interfaces;

public interface IUserService
{
    Task<bool> Register(UserCreate model);
    Task<User> Authenticate(string username, string password);
    Task<IEnumerable<UserViewModel>> GetAll();
    User Get(int id);
    User Create(UserCreate note);
    bool Delete(int id);
    User Update(int id, UserUpdate userUpdate);
}
