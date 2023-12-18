using Application_BE_Project.Constant;
using Application_BE_Project.Exceptions;
using Application_BE_Project.Interfaces.Services;
using Application_BE_Project.Models.Eto;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Application_BE_Project.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly ILogger<RabbitMQService> _logger;
        public RabbitMQService(ILogger<RabbitMQService> logger)
        {

            _logger = logger;

        }
        public async Task<string> PushRequestJoinCalendarAsync(JoinCalendarEto input)
        {
            try
            {
                var factory = new ConnectionFactory() 
                { 
                    HostName = "171.245.205.120", 
                    Port = 5672, 
                    UserName = "admin", 
                    Password = "123456789", 
                    VirtualHost = "/" 
                };

                using var connection = factory.CreateConnection();

                using var channel = connection.CreateModel();

                var response = string.Empty;

                //hang doi yeu cau
                var replyQueue = channel.QueueDeclare(queue: $"reply-join-calendar-{Guid.NewGuid()}", exclusive: true);
                channel.QueueDeclare("request-join-calendar", exclusive: false);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();

                    response = Encoding.UTF8.GetString(body);
                };

                channel.BasicConsume(queue: replyQueue.QueueName, autoAck: true, consumer: consumer);

                var message = JsonConvert.SerializeObject(input);
                var body = Encoding.UTF8.GetBytes(message);


                //tao doi tuong
                var properties = channel.CreateBasicProperties();
                properties.ReplyTo = replyQueue.QueueName;
                properties.CorrelationId = Guid.NewGuid().ToString();

                channel.BasicPublish("", "request-join-calendar", properties, body);

                while (response == string.Empty)
                {

                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"RabbitMQService.Exception: {ex.Message}", JsonConvert.SerializeObject(new
                {
                    
                }));

                throw new FriendlyException(ExceptionCode.RabbitMQ_Service, ex.Message);
            }
        }

        public async Task<string> PushRequestJoinEventAsync(JoinEventEto input)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "171.245.205.120",
                    Port = 5672,
                    UserName = "admin",
                    Password = "123456789",
                    VirtualHost = "/"
                };

                using var connection = factory.CreateConnection();

                using var channel = connection.CreateModel();

                var response = string.Empty;

                //hang doi yeu cau
                var replyQueue = channel.QueueDeclare(queue: $"reply-join-event-{Guid.NewGuid()}", exclusive: true);
                channel.QueueDeclare("request-join-event", exclusive: false);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();

                    response = Encoding.UTF8.GetString(body);
                };

                channel.BasicConsume(queue: replyQueue.QueueName, autoAck: true, consumer: consumer);

                var message = JsonConvert.SerializeObject(input);
                var body = Encoding.UTF8.GetBytes(message);


                //tao doi tuong
                var properties = channel.CreateBasicProperties();
                properties.ReplyTo = replyQueue.QueueName;
                properties.CorrelationId = Guid.NewGuid().ToString();

                channel.BasicPublish("", "request-join-event", properties, body);

                while (response == string.Empty)
                {

                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"RabbitMQService.Exception: {ex.Message}", JsonConvert.SerializeObject(new
                {

                }));

                throw new FriendlyException(ExceptionCode.RabbitMQ_Service, ex.Message);
            }
        }
    }
}
