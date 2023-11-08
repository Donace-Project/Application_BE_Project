using Application_BE_Project.Constant;
using Application_BE_Project.Exceptions;
using Application_BE_Project.Interfaces.Services;
using Newtonsoft.Json;

namespace Application_BE_Project.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly ILogger<RabbitMQService> _logger;
        public RabbitMQService(ILogger<RabbitMQService> logger)
        {

            _logger = logger;

        }
        public Task<string> PushMessageReplyAsync(string exchange, string queue, string routingKey, string data)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                _logger.LogError($"RabbitMQService.Exception: {ex.Message}", JsonConvert.SerializeObject(new
                {
                    exchange, queue, routingKey, data
                }));

                throw new FriendlyException(ExceptionCode.RabbitMQ_Service, ex.Message);
            }
        }
    }
}
