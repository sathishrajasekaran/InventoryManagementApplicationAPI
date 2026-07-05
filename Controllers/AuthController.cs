using Microsoft.AspNetCore.Mvc;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Services.Interfaces;

namespace InventoryManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _authService.RegisterAsync(registerDto);
            return Ok(new { success = true, message = result });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { success = false, message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.LoginAsync(loginDto);
        if (result == null)
            return Unauthorized(new { success = false, message = "Invalid username or password." });

        return Ok(new { success = true, data = result });
    }
}
