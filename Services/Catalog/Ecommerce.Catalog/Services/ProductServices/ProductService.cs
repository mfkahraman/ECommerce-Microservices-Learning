using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Repositories;
using Ecommerce.Catalog.Settings;

namespace Ecommerce.Catalog.Services.ProductServices
{
    public class ProductService(IDatabaseSettings databaseSettings)
                : GenericRepository<Product>(databaseSettings), IProductService
    {
    }
}
