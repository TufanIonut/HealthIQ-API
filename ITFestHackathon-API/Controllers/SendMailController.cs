using HealthIQ.Interfaces;
using HealthIQ.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HealthIQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public  SendMailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail([FromBody] MailRequest mailRequest)
        {
            var result = emailService.SendEmail(mailRequest.To,mailRequest.Subject,mailRequest.Body);
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}
