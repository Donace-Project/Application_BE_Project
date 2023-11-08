namespace Application_BE_Project.Interfaces.Services
{
    public interface IRabbitMQService
    {
        Task<string> PushMessageReplyAsync(string exchange, string queue, string routingKey, string data);
    }
}
