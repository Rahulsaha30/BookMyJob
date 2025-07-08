using System.Security.Claims;
using AuthService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dto;

namespace AuthService.Controller
{
  [ApiController]
  [Route("api/Auth")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authservice;

    public AuthController(IAuthService authService)
    {
      _authservice = authService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
    {
      var result = await _authservice.Register(userRegisterDto);
      return Ok(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
      var result =await _authservice.Login(userLoginDto);

       if (result == "Invalid")
        return BadRequest("Invalid Credentials");
        
      return Ok(result);
    }


    [Authorize]
    [HttpPut("update")]
   
    public async Task<IActionResult> Update(UpdateProfileDto updateProfileDto)
    {
      var userId = Guid.Parse(User.FindFirstValue("UserId"));
      var result =await _authservice.UpdateProfile(updateProfileDto, userId);
      return Ok(result);

    }
  }
}