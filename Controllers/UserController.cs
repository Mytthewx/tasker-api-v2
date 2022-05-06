using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Models;
using TaskerAPI.Models.Create;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreate model)
    {
        var result = await _userService.Register(model);

        if (!result)
        {
            return BadRequest(new { message = "Username already exist" });
        }

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] LoginModel model)
    {
        var user = await _userService.Authenticate(model.Username, model.Password);

        if (user == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAll());
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
