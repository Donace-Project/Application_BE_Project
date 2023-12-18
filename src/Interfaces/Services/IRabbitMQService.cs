using Application_BE_Project.Models.Eto;

namespace Application_BE_Project.Interfaces.Services
{
    public interface IRabbitMQService
    {
        Task<string> PushRequestJoinCalendarAsync(JoinCalendarEto input);
        Task<string> PushRequestJoinEventAsync(JoinEventEto input);
    }
}
