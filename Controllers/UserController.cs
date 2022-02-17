using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services;

namespace TaskerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	public UserController(IUserService userService)
	{
		_userService = userService;
	}
	
	[HttpGet]
	public IEnumerable<User> GetAll()
	{
		return _userService.GetAll();
	}

	[HttpGet]
	[Route("id")]
	public User Get(int id)
	{
		return _userService.Get(id);
	}

	[HttpPost]
	public User Create(UserCreate userCreate)
	{
		return _userService.Create(userCreate);
	}

	[HttpDelete]
	[Route("id")]
	public void Delete(int id)
	{
		_userService.Delete(id);
	}

	[HttpPost]
	[Route("id")]
	public User Update(int id, UserUpdate userUpdate)
	{
		return _userService.Update(id, userUpdate);
	}
}
