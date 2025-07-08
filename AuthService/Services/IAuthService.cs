using SharedLibrary.Dto;

namespace AuthService.Services
{
  public interface IAuthService
  {
    Task<string> Register(UserRegisterDto userRegisterDto);
    Task<string> Login(UserLoginDto userLoginDto);

    Task<String> UpdateProfile(UpdateProfileDto updateProfileDto, Guid userId);
  }
}