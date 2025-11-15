using Microsoft.AspNetCore.Mvc;
using OnlineStoreSystem.Application.Common.Contracts.Authentication;
using OnlineStoreSystem.Application.Common.Interfaces.Authentication;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthController(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // اعتبارسنجی ساده
        if (request.Username != "customer" || request.Password != "1234")
            return Unauthorized();

        var customer = new Customer
        {
            Id = 1,
            Name = "Ali",
            Family = "Rezayi",
            Is_Active = true,
            Register_date = DateTime.Now
        };

        var token = _jwtTokenGenerator.GenerateToken(customer);

        return Ok(new { Token = token });
    }
}