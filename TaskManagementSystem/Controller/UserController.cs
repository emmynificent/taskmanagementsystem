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
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("GetUser{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            if(Id <= 0){
                return BadRequest("Invalid Id");
            }
            var user = await _userRepository.GetUserModel(Id);
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModelInputDto user)
        {
            if(user == null){
                return BadRequest("User is null");
            }
            var createUser = _mapper.Map<UserModel>(user);
            var createdUser = await _userRepository.CreateUserAsync(createUser);
            return CreatedAtAction("GetUser", new {Id = createdUser.Id}, createdUser);
        }
        
    }
}