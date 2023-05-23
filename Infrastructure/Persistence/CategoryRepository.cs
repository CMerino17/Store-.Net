using bootcamp_store_backend.Domain.Entities;
using bootcamp_store_backend.Domain.Persistence;

namespace bootcamp_store_backend.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext _storeContext;

        public CategoryRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public List<Category> GetAll()
        {
            return _storeContext.Categories.ToList<Category>();
        }
    }
}
