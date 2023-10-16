namespace MyShopApi.Repositories;

public interface IPersistence
{
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task RollBackTransactionAsync();
    Task CommitTransactionAsync();
}