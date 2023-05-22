using bootcamp_store_backend.Domain.Entities;

namespace bootcamp_store_backend.Infrastructure.Persistence
{
    public class DevelopmentDataLoader
    {
        private readonly StoreContext storeContext;
        private readonly byte[] defaultImage = Convert.FromBase64String("");

        public DevelopmentDataLoader(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public void LoadData() 
        {
            if (!storeContext.Categories.Any()) 
            {
                LoadCategories();
            }

            if (!storeContext.Items.Any())
            {
                LoadItems();
            }
            storeContext.SaveChanges();
        }

        private void LoadCategories()
        {
            var categories = new Category[]
            {
                new Category{ Name="Chaquetas", Image=defaultImage },
                new Category{ Name="Calzado", Image=defaultImage}
            };
            foreach (Category c in categories)
            {
                storeContext.Categories.Add(c);
            }
        }

        private void LoadItems()
        {
            var items = new Item[]
            {
                new Item{ Name="CHAQUETA MULTI BOLSILLOS", Price=39.95, CategoryId=1, Image=defaultImage},
                new Item{ Name="CHAQUETA CINTURA AJUSTABLE CON LINO", Price=34.95, CategoryId=1, Image=defaultImage},
                new Item{ Name="ZAPATO ATADO CUÑA", Price=28.95, CategoryId=2, Image=defaultImage}
            };
            foreach (Item i in items)
            {
                storeContext.Items.Add(i);
            }
        }
    }
}
