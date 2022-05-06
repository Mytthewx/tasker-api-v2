using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Models.ViewModel;
using TaskerAPI.Services.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace TaskerAPI.Services;

public class UserService : IUserService
{
    private const string UserNotFoundMessage = "User with this id doesn't exist.";
    private readonly IMapper _mapper;
    private readonly TaskerContext db;

    public UserService(TaskerContext taskerContext, IMapper mapper)
    {
        db = taskerContext;
        _mapper = mapper;
    }


    public async Task<bool> Register(UserCreate model)
    {
        var user = await db.Users.FirstOrDefaultAsync(x => x.Username == model.Username);
        if (user != null)
        {
            return false;
        }

        var newUser = new User
        {
            EmailAddress = model.Email,
            Username = model.Username,
            Password = BC.HashPassword(model.Password)
        };

        await db.Users.AddAsync(newUser);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<User> Authenticate(string username, string password)
    {
        var user = await db.Users.FirstOrDefaultAsync(x => x.Username == username);

        if (user == null)
        {
            return null;
        }
        
        return BC.Verify(password, user.Password) ? user : null;
    }

    public async Task<IEnumerable<UserViewModel>> GetAll()
    {
        var users = await db.Users.Include(x => x.Notes)
            .ThenInclude(x => x.Reminders)
            .ToListAsync();
        var result = _mapper.Map<IEnumerable<UserViewModel>>(users);
        return result;
    }

    public User Get(int id)
    {
        return db.Users.FirstOrDefault(x => x.Id == id) ?? throw new Exception(UserNotFoundMessage);
    }

    public User Create(UserCreate user)
    {
        var createUser = _mapper.Map<User>(user);
        db.Users.Add(createUser);
        db.SaveChanges();
        return createUser;
    }

    public bool Delete(int id)
    {
        var user = db.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return false;
        }

        db.Users.Remove(user);
        db.SaveChanges();
        return true;
    }

    public User Update(int id, UserUpdate newUser)
    {
        var user = db.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            throw new Exception(UserNotFoundMessage);
        }

        var editedUser = EditReflectionHelper(user, newUser);

        var updateUser = _mapper.Map<User>(editedUser);
        db.SaveChanges();
        return updateUser;
    }

    private UserUpdate EditReflectionHelper(User user, UserUpdate newUser)
    {
        var userProperties = user.GetType().GetProperties();
        var newUserProperties = newUser.GetType().GetProperties();

        foreach (var newUserProperty in newUserProperties)
        {
            if (newUserProperty.GetValue(newUser) == null)
            {
                continue;
            }

            var userProperty = userProperties.FirstOrDefault(x => x.Name == newUserProperty.Name);
            if (userProperty != null)
            {
                userProperty.SetValue(user, newUserProperty.GetValue(newUser));
            }
        }

        return newUser;
    }
}
