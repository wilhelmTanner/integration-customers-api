using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanner.Integration.Common.Models.Entities;
using Tanner.Integration.Common.Models.Responses;

namespace Tanner.Integration.Common.Interfaces.Services
{
    public interface ICustomerService
    {

        public Task<Customer> GetById(ObjectId customerId);

        public Task<IEnumerable<Customer>> GetAll();

        public Task<RecordSavedResponse> Insert(Customer customer);

        public Task<int> Update(Customer customer);

    }
}
