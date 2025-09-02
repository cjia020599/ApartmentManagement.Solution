namespace PropertyManagement.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IPropertyRepository Properties { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
