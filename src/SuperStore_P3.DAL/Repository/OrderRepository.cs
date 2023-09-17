using Data;
using Models;

namespace SuperStore_P3.DAL.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SuperStoreContext context) : base(context)
        {
            
        }

    }
}
