using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly PasswordService _passwordService;
    private readonly TokenService _tokenService;


    public AuthController(
        ApplicationDBContext context,
        PasswordService passwordService,
        TokenService tokenService)
    {
        _context = context;
        _passwordService = passwordService;
        _tokenService = tokenService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Register dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
            return BadRequest("Invalid data");

        var existingUser = await _context.Users
            .FirstOrDefaultAsync(x => x.Username == dto.Username);

        if (existingUser != null)
            return BadRequest("User already exists");

        var user = new User
        {
            Username = dto.Username,
            PasswordHash = _passwordService.HashPassword(dto.Password)
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User Registered Successfully" });
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login dto)
    {
        if (dto == null)
            return BadRequest("Invalid request");

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Username == dto.Username);

        if (user == null || !_passwordService.VerifyPassword(dto.Password, user.PasswordHash))
            return Unauthorized("Invalid credentials");

        var token = _tokenService.GenerateToken(user.Username);

        return Ok(new
        {
            message = "Login Successful",
            token = token
        });
    }
}