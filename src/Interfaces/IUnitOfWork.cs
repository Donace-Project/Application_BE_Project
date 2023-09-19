namespace BE_Event_Project.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangeAsync();
    Task RollbackAsync();
    Task CommitAsync();
}