using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCUBS.Customer.Service.Common.Models.Entities;

namespace FCUBS.Customer.Service.Common.Interfaces.Repositories
{
    public interface ICustomerRepository
    {

        Task<CustomerEntity> Insert(CustomerEntity customer);
        Task<CustomerEntity> Update(CustomerEntity customer);
        Task<List<IEnumerable<CustomerEntity>>> GetAll();
        Task<CustomerEntity> GetOneById(ObjectId id);
    }
}
