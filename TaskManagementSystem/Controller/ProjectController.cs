using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.DTO;
using TaskManagementSystem.Interface;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController: ControllerBase
    {
        private readonly IProject _projectRepository;
        private readonly IMapper _mapper;
        public ProjectController(IProject projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetProjects()
        {
            var projects =  await _projectRepository.GetProjectsAsync();

            return Ok(projects);
        }

        [HttpGet("GetProject/")]
        public async Task<IActionResult> GetProject(int projectId)
        {
            if(projectId <= 0 )
            {
                return BadRequest("Invalid Request");
            }
            var getProject = await _projectRepository.GetProject(projectId);
            if(getProject is null)
            {
                return NotFound();
            }
            return Ok(getProject);
        }

        [HttpPost("CreateProject")]
        public async Task<IActionResult> CreateProject(ProjectInputDto project)
        {
            if(project is null)
            {
                return BadRequest("Invalid Request");                
            }
            var CreateProject = _mapper.Map<Project>(project);

            await _projectRepository.CreateProjectAsync(CreateProject);
            return Ok("Project created");
        }

        [HttpGet("GetWorkItemsInAProject/{projectId}")]
        public async Task<IActionResult> GetWorkItemsInAProject(int projectId)
        {
            if(projectId <= 0)
            {
                return BadRequest("Invalid Request");
            }
            var workItems = await _projectRepository.GetWorkItemsInProject(projectId);
            if(workItems is null)
            {
                return NotFound();
            }
            return Ok(workItems);
        }

        [HttpPut("UpdateProject")]
        public async Task<IActionResult> UpdateProject(int projectId, ProjectInputDto project)
        {
            if(projectId <= 0 )
            {
                return BadRequest("Invalid Request");
            }

            var getproject = await _projectRepository.GetProject(projectId);
            _mapper.Map(getproject, project);

            if(!await _projectRepository.UpdateProjectAsync(getproject))
            {
                return BadRequest("Update failed");
            }
            return Ok("Project updated");

        }
    

    }
}