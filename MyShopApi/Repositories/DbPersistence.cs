namespace MyShopApi.Repositories;

public class DbPersistence : IPersistence
{
    private readonly AppDbContext _context;

    public DbPersistence(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task RollBackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }
}