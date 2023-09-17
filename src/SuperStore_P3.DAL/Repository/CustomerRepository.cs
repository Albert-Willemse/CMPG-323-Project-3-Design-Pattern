using Data;
using Models;

namespace SuperStore_P3.DAL.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SuperStoreContext context) : base(context)
        {

        }

    }
}
