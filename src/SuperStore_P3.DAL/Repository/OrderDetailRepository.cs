using Data;
using Models;
using System.Linq;

namespace SuperStore_P3.DAL.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SuperStoreContext context) : base(context)
        {
            
        }

        
    }
}
