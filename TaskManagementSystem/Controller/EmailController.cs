using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interface;

namespace TaskManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _mailService;

        public EmailController(IEmailService mailService)
        {
            _mailService = mailService;  
        }

        [HttpPost("Send-Mail")]
        public async Task<IActionResult> endEmail(string ReceiverEmail, string mailSubject, string mailBody)
        {
            var result = await _mailService.SendEmailAsync(ReceiverEmail, mailSubject, mailBody);
            return Ok(result);
        }
    }
}