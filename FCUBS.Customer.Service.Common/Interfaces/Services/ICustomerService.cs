
namespace FCUBS.Customer.Service.Common.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task<CustomerEntity> GetByIdAsync(ObjectId customerId);
        public CustomerEntity GetById(ObjectId customerId);
        public Task<IEnumerable<CustomerEntity>> GetAllAsync();
        public IEnumerable<CustomerEntity> GetAll();
        public Task<RecordSavedResponse> Insert(CustomerEntity customer);
        public Task<CustomerEntity> UpdateAsync(CustomerEntity customer);
        public CustomerEntity Update(CustomerEntity customer);
    }
}
