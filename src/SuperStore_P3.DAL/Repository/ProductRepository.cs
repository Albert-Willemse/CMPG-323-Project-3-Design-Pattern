using Data;
using Models;
using System.Linq;

namespace SuperStore_P3.DAL.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SuperStoreContext context) : base(context)
        {

        }

    }
}
