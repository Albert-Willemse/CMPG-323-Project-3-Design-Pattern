using Data;
using Models;
using System.Linq;

namespace SuperStore_P3.BLL.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SuperStoreContext context) : base(context)
        {
            
        }

        
    }
}
