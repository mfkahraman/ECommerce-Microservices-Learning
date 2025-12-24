using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Repositories;
using Ecommerce.Catalog.Settings;

namespace Ecommerce.Catalog.Services.CategoryServices
{
    public class CategoryService (IDatabaseSettings databaseSettings)
        : GenericRepository<Category>(databaseSettings), ICategoryService
    {

    }
}
