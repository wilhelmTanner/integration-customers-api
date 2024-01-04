
namespace FCUBS.Customer.Service.Common.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task<int> GetByIdAsync(CustomerRequest customerId);
        public Task<int> CreateAsync(CustomerRequest customer);
        public Task<CustomerEntity> UpdateAsync(CustomerRequest customer);
    }
}
