using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCUBS.Customer.Service.Common.Interfaces.Repositories;
using FCUBS.Customer.Service.Common.Models.Entities;

namespace FCUBS.Customer.Service.DataAccess.Mongo
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<List<IEnumerable<CustomerEntity>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerEntity> GetOneById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerEntity> Insert(CustomerEntity customer)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerEntity> Update(CustomerEntity customer)
        {
            throw new NotImplementedException();
        }
    }
}
