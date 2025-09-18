using TaskManagementSystem.Authentication.Model;
using TaskManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using AutoMapper;
using TaskManagementSystem.DTO;
using TaskManagementSystem.Interface;
using Microsoft.AspNetCore.Authorization;

namespace TaskManagementSystem.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager <UserModel> _signInManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        //private Roles _roles;
        private string AdminRole = "Boss";
        //private string userEmail = "adminuser@gmail.com"; 
        private readonly EmailSettings _emailSettings;

        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IOptions<JwtConfig> jwtConfig, IMapper mapper, RoleManager<IdentityRole> roleManager, IEmailService emailService, IOptions<EmailSettings> emailSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig.Value;
            _mapper = mapper;
            _emailService = emailService;
            _roleManager = roleManager;
            // _roles = roles;
            _emailSettings = emailSettings.Value;

        }

        //

        //I want the admin users to be able to select from a list of possible roles
        //Employee, HoD
        //[Authorize(Roles = "Administrator")]
        [HttpPost("BossRole")]
        public async Task<IActionResult> Manager(string userEmail)
        {

        //    string userFullName = "Administrator";
            if (!await _roleManager.RoleExistsAsync(AdminRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(AdminRole));
            }

            //
            var userExists = await _userManager.FindByEmailAsync(userEmail);
            if (userExists == null)
            {
                return BadRequest("User does not exist");
            }
            else
            {
                await _userManager.AddToRoleAsync(userExists, AdminRole);
                return Ok("User assigned new role");
            }
        }


        [HttpPost("register")]  

        public async Task<IActionResult> Register([FromBody] UserModelInputDto userinput)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newUser = new UserModel{
                UserName = userinput.Email,
                Email = userinput.Email,
                FullName = userinput.FullName
            };


            var result = await  _userManager.CreateAsync(newUser, userinput.Password);
            if(!result.Succeeded)
            {
                
                return BadRequest(result.Errors);
            }

            //var userToken = GenerateJwtToken(newUser);
            //var token = await _userManager.GenerateEmailCOnfirmationTokenAsync(newUser);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var confirmationLink = Url.Action("ConfirmEmail", "Auth", new{
                userId = newUser.Id, 
                token = token,
                email =newUser.Email 

            },
            Request.Scheme
            );
            await _emailService.SendEmailAsync(newUser.Email, "Confirm your email", $"Please confirm your email by clicking this link: <a href='{confirmationLink}'>link</a>");

            return Ok("User Created Successfully. Please check your email to confirm your account");
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return BadRequest("user not found");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if(result.Succeeded)
            {
                return Ok("Email confirmed successfully! you can now Log in");
            }
            return BadRequest("Email confirmaton failed. The token may be invalid or expired");
        }



        //     if(userToken != null)
        //     {
        //         await _emailService.SendEmailAsync(newUser.Email, "Welcome To The System", $"Thank you {newUser.FullName} for joining the system, welcome to the 1%! ");
              
        //     }
        //  return Ok(new 
        //     {
        //             Message = "User registered Successfully",
        //             Token = userToken
        //         });
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user == null)
            {
                return BadRequest("Invalid email or password");
            }
            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                return BadRequest("Email not confirmed. Please check your email before logging in.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

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