using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Array.Empty<string>());
    }
}