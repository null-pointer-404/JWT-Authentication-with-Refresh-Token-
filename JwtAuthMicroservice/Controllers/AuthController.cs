using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtAuthMicroservice.API.Data;
using JwtAuthMicroservice.API.Models;
using JwtAuthMicroservice.API.Services;

namespace JwtAuthMicroservice.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly TokenService _tokenService;
        private readonly ApplicationDbContext _context;

        public AuthController(AuthService authService, TokenService tokenService, ApplicationDbContext context)
        {
            _authService = authService;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _authService.Authenticate(request.Username, request.Password);
            if (user == null)
                return Unauthorized();

            var jwtToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            await _tokenService.SaveRefreshToken(user, refreshToken);

            return Ok(new { Token = jwtToken, RefreshToken = refreshToken });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);
            if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
                return Unauthorized();

            var newJwtToken = _tokenService.GenerateJwtToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            await _tokenService.SaveRefreshToken(user, newRefreshToken);

            return Ok(new { Token = newJwtToken, RefreshToken = newRefreshToken });
        }
    }
}
