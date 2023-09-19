using BE_Event_Project.Interfaces;

namespace BE_Event_Project.EntityFramework;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task CommitAsync()
    {
        using(var transaction = _context.Database.BeginTransaction())
        {
            await transaction.CommitAsync();
        }
    }
    public async Task RollbackAsync()
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            await transaction.RollbackAsync();
        }
    }
    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}
