namespace Application_BE_Project.Models.Eto
{
    public class JoinCalendarEto
    {
        public string Token {  get; set; }
        public Guid CalendarId { get; set; }
    }

    public class JoinEventEto
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
    }
}
