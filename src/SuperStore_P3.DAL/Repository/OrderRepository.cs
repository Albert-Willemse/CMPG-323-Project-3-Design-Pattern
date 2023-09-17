using Data;
using Models;

namespace SuperStore_P3.BLL.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SuperStoreContext context) : base(context)
        {
            
        }

    }
}
