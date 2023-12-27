using MongoDB.Bson;
 

namespace IntegrationCustomers.Service.Implementations
{
    public class CustomerService : ICustomerService
    {

        public CustomerService(){}

        public Task<IEnumerable<CustomerEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<CustomerEntity> GetById(ObjectId customerId)
        {
            CustomerEntity customer = new() { Name = "Wilhelm", LastName = "Sauerbaum", Age = 20 };
            return customer;
        }

        public async Task<RecordSavedResponse> Insert(CustomerEntity customer)
        {
            RecordSavedResponse response = new();

            if(customer != null)
            {
                response.Success = false;
                response.ErrorMessage = "Este es un error";
            }

            return response;
        }

        public Task<int> Update(CustomerEntity customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
