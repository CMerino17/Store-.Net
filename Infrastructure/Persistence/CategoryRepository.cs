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

        public void Delete(long id)
        {
            var category = _storeContext.Categories.Find(id);
            if (category == null)
            {
                throw new ElementNotFoundException();
            }
            _storeContext.Categories.Remove(category);
            _storeContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _storeContext.Categories.ToList<Category>();
        }

        public Category GetById(long id)
        {
            var category = _storeContext.Categories.Find(id);
            if (category == null)
            {
                throw new ElementNotFoundException();
            }
            return category;
        }

        public Category Insert(Category category)
        {
            _storeContext.Categories.Add(category);
            _storeContext.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            _storeContext.Categories.Update(category);
            _storeContext.SaveChanges();
            return category;
        }

        
    }
}
