using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tMovies.API.Models;
using tMovies.API.Token;
using tMovies.API.Utilities;
using tMovies.API.ViewModels;

namespace tMovies.API.Controllers
{    
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(ITokenGenerator tokenGenerator, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _tokenGenerator = tokenGenerator;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("/api/v1/auth/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel registerUserViewModel)
        {
            try
            {
                var user = new User
                {
                    UserName = registerUserViewModel.UserName,
                    Email = registerUserViewModel.Email                    
                };

                var result = await _userManager.CreateAsync(user, registerUserViewModel.Password);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso",
                    Success = true,
                    Data = user
                });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPost]
        [Route("/api/v1/auth/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel userLoginViewModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLoginViewModel.Login);
                if (user != null && await _userManager.CheckPasswordAsync(user, userLoginViewModel.Password))
                {
                    var token = _tokenGenerator.GenerateToken(user);

                    return Ok(new { token });
                }

                return StatusCode(401, Responses.UnauthorizedErrorMessage());
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
