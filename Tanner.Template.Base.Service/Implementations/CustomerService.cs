using MongoDB.Bson;
using System.ComponentModel.Design.Serialization;
using Tanner.Integration.Common.Interfaces.Services;
using Tanner.Integration.Common.Models.Entities;
using Tanner.Integration.Common.Models.Responses;

namespace Tanner.Integration.Service.Implementations
{
    public class CustomerService : ICustomerService
    {

        public CustomerService(){}

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Customer> GetById(ObjectId customerId)
        {
            Customer customer = new() { Name = "Wilhelm", LastName = "Sauerbaum", Age = 20 };
            return customer;
        }

        public async Task<RecordSavedResponse> Insert(Customer customer)
        {
            RecordSavedResponse response = new();

            if(customer != null)
            {
                response.Success = false;
                response.ErrorMessage = "Este es un error";
            }

            return response;
        }

        public Task<int> Update(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
