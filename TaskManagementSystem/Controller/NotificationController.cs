using TaskManagementSystem.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.DTO;

namespace TaskManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotification _notificationRepository;
        private readonly IMapper _mapper;
        public NotificationController(INotification notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await _notificationRepository.GetNotifications();
            var notes = _mapper.Map<List<NotificationOutput>>(notifications);
            return Ok(notes);
        }


        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationInputDto notification)
        {
            if(notification is null)
            {
                return BadRequest("Bad request");
            }

            var newNotification = _mapper.Map<Notification>(notification);
            await _notificationRepository.CreateNotificationAsync(newNotification);
            return Ok();
        }


        [HttpPut ("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(int notificationId , NotificationInputDto notificationStatus)
        {
            if(notificationId <= 0){
                return BadRequest("Error");
            }
            var status = await _notificationRepository.GetNotification(notificationId);
            if(status is null)
            {
                return BadRequest("Something is broken");
            }

            _mapper.Map(status, notificationStatus);

           if(! await _notificationRepository.UpdateNotificationStatus(status))
           {
            return BadRequest("Update Went Wrong");
           }
           return NoContent();
            
        }
    }
}