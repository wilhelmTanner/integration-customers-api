using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Linq;
using WsTipoCambio;


namespace FCUBS.Customer.Service.Services.Implementations
{
    public class CustomerService : ICustomerService
    {

        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            WeatherService.GlobalWeatherSoapClient client = new WeatherService.GlobalWeatherSoapClient(new WeatherService.GlobalWeatherSoapClient.EndpointConfiguration());


            var result = client.GetWeatherAsync("Santiago", "Chile");


            Random r = new Random();


            // if(r.Next(1,4) == 2) throw new ApplicationException("---- Reintentando -----");


            List<CustomerEntity> customers = new();

            CustomerEntity customer = new() { Name = "Wilhelm", LastName = "Sauerbaum", SecondLastName = "Alarcon", Age = 20, Address="Avenida siempre viva 333" };

            customers.Add(customer);

            return customers;
        }

        public Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return Task.FromResult(GetAll());
        }
        public async Task<CustomerEntity> GetByIdAsync(ObjectId customerId)
        {

            TipoCambioSoapClient c = new TipoCambioSoapClient(new TipoCambioSoapClient.EndpointConfiguration());
            var x = c.TipoCambioDiaAsync();



            throw new ApplicationException("---- Reintentando -----");

            return await Task.FromResult(GetById(customerId));
        }

        public async Task<RecordSavedResponse> Insert(CustomerEntity customer)
        {
            RecordSavedResponse response = new();

            if (customer != null)
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
