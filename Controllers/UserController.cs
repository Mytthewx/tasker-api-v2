using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services.Interfaces;

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
    public IActionResult GetAll()
    {
        return Ok(_userService.GetAll());
    }

    [HttpGet]
    [Route("id")]
    public IActionResult Get(int id)
    {
        return Ok(_userService.Get(id));
    }

    [HttpPost]
    public IActionResult Create(UserCreate userCreate)
    {
        return Ok(_userService.Create(userCreate));
    }

    [HttpDelete]
    [Route("id")]
    public IActionResult Delete(int id)
    {
        return _userService.Delete(id) ? Ok() : NotFound();
    }

    [HttpPut]
    [Route("id")]
    public IActionResult Update(int id, UserUpdate userUpdate)
    {
        return Ok(_userService.Update(id, userUpdate));
    }
}
