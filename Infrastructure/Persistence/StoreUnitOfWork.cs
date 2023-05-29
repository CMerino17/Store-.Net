using bootcamp_store_backend.Domain.Persistence;


namespace bootcamp_store_backend.Infrastructure.Persistence
{
    public class StoreUnitOfWork : UnitOfWork, IStoreUnitOfWork
    {
        public StoreUnitOfWork(StoreContext dbContext) : base(dbContext)
        {
        }
    }
}
