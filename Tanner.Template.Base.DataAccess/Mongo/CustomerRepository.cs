using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanner.Integration.Common.Interfaces.Repositories;
using Tanner.Integration.Common.Models.Entities;

namespace Tanner.Integration.DataAccess.Mongo
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<List<IEnumerable<Customer>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetOneById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
