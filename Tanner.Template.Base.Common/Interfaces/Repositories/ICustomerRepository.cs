using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanner.Integration.Common.Models.Entities;

namespace Tanner.Integration.Common.Interfaces.Repositories
{
    public interface ICustomerRepository
    {

        Task<Customer> Insert(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<List<IEnumerable<Customer>>> GetAll();
        Task<Customer> GetOneById(ObjectId id);
    }
}
