using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InventoryManagementAPI.Data;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Services.Interfaces;
using InventoryManagementAPI.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InventoryManagementAPI.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> RegisterAsync(RegisterDTO registerDto)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == registerDto.UserName || u.Email == registerDto.Email);

        if (existingUser != null)
            throw new InvalidOperationException("User with this username or email already exists.");

        var user = new User
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            PasswordHash = PasswordHasher.Hash(registerDto.Password),
            Role = string.IsNullOrWhiteSpace(registerDto.Role) ? "User" : registerDto.Role
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return "User registered successfully";
    }

    public async Task<LoginResponseDTO?> LoginAsync(LoginDTO loginDto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

        if (user == null || !PasswordHasher.Verify(loginDto.Password, user.PasswordHash))
            return null;

        var token = GenerateJwtToken(user);

        return new LoginResponseDTO
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(GetJwtDuration()),
            UserName = user.UserName,
            Role = user.Role
        };
    }

    private double GetJwtDuration()
    {
        return double.Parse(_configuration["Jwt:DurationInMinutes"] ?? "60");
    }

    private string GenerateJwtToken(User user)
    {
        var key = _configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("JWT key is not configured.");
        var issuer = _configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException("JWT issuer is not configured.");
        var audience = _configuration["Jwt:Audience"]
            ?? throw new InvalidOperationException("JWT audience is not configured.");
        var duration = GetJwtDuration();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(duration),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
