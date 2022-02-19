using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services.Interfaces;

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

    public IEnumerable<User> GetAll()
    {
        return db.Users.ToList();
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