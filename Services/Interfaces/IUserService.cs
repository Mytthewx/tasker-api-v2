using System.Collections.Generic;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Services.Interfaces;

public interface IUserService
{
    IEnumerable<User> GetAll();
    User Get(int id);
    User Create(UserCreate note);
    bool Delete(int id);
    User Update(int id, UserUpdate userUpdate);
}