using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("api/auth/[action]")]
public class AuthenticationController : BaseController
{
    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }

    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok(request);
    }
}