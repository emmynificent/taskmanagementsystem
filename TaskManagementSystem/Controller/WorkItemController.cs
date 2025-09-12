using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interface;
using TaskManagementSystem.Models;
using TaskManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;

namespace TaskManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IWorkItem _workRepository;
        private readonly IMapper _mapper;
        public WorkItemController(IWorkItem workRepository, IMapper mapper)
        {
            _workRepository = workRepository;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetWorks()
        {
            var works = await _workRepository.GetWorkItems();
            var workMap = _mapper.Map<List<WorkItemOutputDto>>(works);
            return Ok(workMap);
        }

       // [Authorize]
        [HttpGet("work-item/{Id}")]
        public async Task<IActionResult> GetWork(int Id)
        {
            if( Id <= 0)
            {return BadRequest("Invalid Id");}
            try{
                if(!await _workRepository.WorkExist(Id))
                {return NotFound($"Search Item not found");}

                var work = await _workRepository.GetWorkItem(Id);
                
                var workMap = _mapper.Map<WorkItemOutputDto>(work);
                return Ok(workMap);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       // [Authorize]
        [HttpPut("UpdateWork")]
        public async Task<IActionResult> UpdateWork(int workId, WorkItemInputDto workItem)
        {
            if(workId <= 0 && !await _workRepository.WorkExist(workId))
            {return BadRequest("Invalid Request");}
            var retrievedWork = await _workRepository.GetWorkItem(workId);
            if(retrievedWork is null)
            {return BadRequest();}
            _mapper.Map(workItem, retrievedWork);
            if(await _workRepository.UpdateWorkItemAsync(retrievedWork))
            {
                return NoContent();
            }
            return BadRequest("An error occured");

        }

       // [Authorize]
        [HttpPost("CreateWork")]
        public async Task<IActionResult> CreateWork(WorkItemInputDto workItem)
        {
            if(workItem == null)
            {return BadRequest("Try again");}
            var workMap = _mapper.Map<WorkItem>(workItem);
            var createWork = await _workRepository.CreateWorkItemAsync(workMap);
            return Ok(createWork);
        }

       // [Authorize ]
        [HttpDelete("DeleteWork")]
        public async Task<IActionResult> DeleteWork(int workId)
        {
            if(workId <= 0)
            {return BadRequest(" Work does not exist ");}
            
            var deleteWorkItem = await _workRepository.GetWorkItem(workId);
                
            if(deleteWorkItem is null)
            {
                return BadRequest("Invalid Request");
            }
            await _workRepository.DeleteWorkItem(deleteWorkItem);
            return Ok();
        }

        // [HttpPatch]
        // public async Task<IActionResult> UpdateStatus(int workId, WorkItemInputDto workItemInput)
        // {
        //     if(workId <= 0)
        //     {
        //         return BadRequest("input does not exist");
        //     }
        //     var wor = _workRepository.GetWorkItem(workId);
        //     if (wor is null)
        //     {
        //         return NotFound("wor item not found");
        //     }


        // }
        

    }

}