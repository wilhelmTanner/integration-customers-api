using Microsoft.Extensions.Logging;
using MongoDB.Bson;
 

namespace FCUBS.Customer.Service.Service.Implementations
{
    public class CustomerService : ICustomerService
    {

        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger) {
            _logger = logger;
        }

        public Task<IEnumerable<CustomerEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<CustomerEntity> GetByIdAsync(ObjectId customerId)
        {
            return await Task.FromResult<CustomerEntity>(GetById(customerId));
        }

        public async Task<RecordSavedResponse> Insert(CustomerEntity customer)
        {
            RecordSavedResponse response = new();

            if(customer != null)
            {
                response.Success = false;
                response.ErrorMessage = "Este es un error";
                _logger.LogError($"Ha ocurrido un error {nameof(Insert)}");
            }

            return response;
        }

        public async Task<CustomerEntity> UpdateAsync(CustomerEntity customer)
        {
            return await Task.FromResult<CustomerEntity>(Update(customer));
        }

        public CustomerEntity Update(CustomerEntity customer)
        {
            CustomerEntity customerNew = new() { Name = "Wilhelm", LastName = "Sauerbaum", Age = 20 };
            return customerNew;
        }

        public CustomerEntity GetById(ObjectId customerId)
        {
            CustomerEntity customer = new() { Name = "Wilhelm", LastName = "Sauerbaum", Age = 20 };
            return customer;
        }
    }
}
