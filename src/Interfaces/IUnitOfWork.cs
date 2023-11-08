namespace Application_BE_Project.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangeAsync();
    Task RollbackAsync();
    Task CommitAsync();
}