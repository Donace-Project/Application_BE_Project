namespace BE_Event_Project.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public Guid CreatorId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsEnable { get; set; } = true;
}
