using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using TaskerAPI.Models.ViewModel;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CostController : ControllerBase
{
    private readonly ICostService _costService;

    public CostController(ICostService costService)
    {
        _costService = costService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_costService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_costService.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CostViewModel costCreate)
    {
        return Ok(await _costService.Create(costCreate));
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        return _costService.Delete(id) ? Ok() : NotFound();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(int id, CostViewModel costUpdate)
    {
        return Ok(_costService.Update(id, costUpdate));
    } 
}