﻿
namespace IntegrationCustomers.Common.Interfaces.Services
{
    public interface ICustomerService
    {

        public Task<CustomerEntity> GetById(ObjectId customerId);

        public Task<IEnumerable<CustomerEntity>> GetAll();

        public Task<RecordSavedResponse> Insert(CustomerEntity customer);

        public Task<int> Update(CustomerEntity customer);

    }
}