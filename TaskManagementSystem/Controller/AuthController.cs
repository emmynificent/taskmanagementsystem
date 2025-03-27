using TaskManagementSystem.Authentication.Model;
using TaskManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace TaskManagementSystem.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager <UserModel> _signInManager;
        private readonly JwtConfig _jwtConfig;

        public AuthController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IOptions<JwtConfig> jwtConfig )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig.Value;

        }

        [HttpPost ("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newUser = new UserModel{
                UserName = registerModel.Email,
                Email = registerModel.Email
            };
            var result = await  _userManager.CreateAsync(newUser, registerModel.Password);
            if(!result.Succeeded)
            {
                
                return BadRequest(result.Errors);
            }

            var userToken = GenerateJwtToken(newUser);
            return Ok(new {
                Message = "User Registered successfully"
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if(user == null)
            {
                return BadRequest("Invalid email or password");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if(!result.Succeeded)
            {

                return BadRequest("Invalid email or password");
            }

            var token = GenerateJwtToken(user);
            return Ok( new {Token = token});
        }


        // [HttpGet]
        // public async Task<IActionResult> AllUsers()
        // {
        //   var users =  .Users.ToList();
        //   return Ok(users);
        // }

        private string GenerateJwtToken(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.ValidIssuer,
                Audience = _jwtConfig.ValidAudience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            
        }
        


    }
}