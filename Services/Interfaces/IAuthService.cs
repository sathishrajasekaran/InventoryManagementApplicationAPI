using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Services.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDTO registerDto);
    Task<LoginResponseDTO?> LoginAsync(LoginDTO loginDto);
}
