using Application_BE_Project.Interfaces.Services;
using Application_BE_Project.Models.Eto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_BE_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMQService;
        public RabbitMQController(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [HttpPost("Calendar/user-join")]
        public async Task TaskJoinCalendarAsync(JoinCalendarEto input)
        {
            await _rabbitMQService.PushRequestJoinCalendarAsync(input);
        }

        [HttpPost("Event/user-join")]
        public async Task TaskJoinEventAsync(JoinEventEto input)
        {
            await _rabbitMQService.PushRequestJoinEventAsync(input);
        }
    }
}
