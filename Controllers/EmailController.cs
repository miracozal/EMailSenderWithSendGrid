using EMailSenderWithSendGrid.Models;
using EMailSenderWithSendGrid.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMailSenderWithSendGrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            try
            {
                bool result = await _emailService.SendEmailAsync(emailRequest);
                if (result)
                {
                    return Ok("Email sending operation was successful.");
                }
                else
                {
                    return BadRequest("An error occurred.");
                }
            }
            catch (Exception ex) {
                return BadRequest("An error occurred.");
            }

        }
    }
}
