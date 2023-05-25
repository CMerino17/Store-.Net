using bootcamp_store_backend.Domain.Entities;
using bootcamp_store_backend.Domain.Persistence;

namespace bootcamp_store_backend.Infrastructure.Persistence
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private StoreContext _storeContext;

        public CategoryRepository(StoreContext context) : base(context)
        {
            _storeContext = context;
        }
    }
}
