using AutoMapper;
using TaskManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interface;
using TaskManagementSystem.DTO;
namespace TaskManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserModel _userRepository;
        //private readonly UserManager _userManager;
        private readonly IMapper _mapper;
        public UserController(IUserModel userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            var userMapped = _mapper.Map<List<UserOutputDto>>(users);

            return Ok(userMapped);

        }
        [HttpGet("GetUser{UserEmail}")]
        public async Task<IActionResult> GetUser(string UserEmail)
        {
            if (UserEmail == null)
                return BadRequest("Invalid input");

            
            var user = await _userRepository.GetUserByEmail(UserEmail);
            if (user == null)
                return BadRequest("Something went wrong");
            return Ok(user);
        }
        

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userEmail)
        {
            if(userEmail == null){
                return BadRequest("Invalid input");
            }
            var email = await _userRepository.GetUserByEmail(userEmail);
            if (email == null)
            {
                return BadRequest("User does not exist or User has been deleted");
            }
            await _userRepository.DeleteUser(userEmail);
            return Ok("User deleted successfully");

        }
        //Assigning roles
        // [HttpPost]
        // public async Task<IActionResult> AssignRole(string userMail)

        // [HttpPost]
        // public async Task<IActionResult> 


        //this would be for profile creation at some point. the authcontroller would be handlng the login and registration.
        // [HttpPost]
        // public async Task<IActionResult> CreateUser([FromBody] UserModelInputDto user)
        // {
        //     if(user == null){
        //         return BadRequest("User is null");
        //     }
        //     var createUser = _mapper.Map<UserModel>(user);
        //     var createdUser = await _userRepository.CreateUserAsync(createUser);
        //     return CreatedAtAction("GetUser", new {Id = createdUser.Id}, createdUser);
        // }

    }
}
//sort out the creation of roles later, it's taking so much time to figure out right now



