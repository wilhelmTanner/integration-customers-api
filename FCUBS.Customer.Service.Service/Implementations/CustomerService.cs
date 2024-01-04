using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Linq;
using WsTipoCambio; 
using System.Diagnostics.Metrics;
using FCUBS.Customer.Service.Services.HttpClients;
using FCUBS.Customer.Service.Services.Models;
using FCUBSCustomerServiceReference;

namespace FCUBS.Customer.Service.Services.Implementations
{
    public class CustomerService
    {

        private readonly ILogger<CustomerService> _logger;
        private FCUBSCustomerServiceSEIClient _client;

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
            _client = FBCustomerClient.Client;
        }

        public async Task<IEnumerable<CustomerEntity>> GetAll(CustomerRequest customer)
        {
            QueryCustomer queryCustomer = new QueryCustomer(customer);

            QueryCustomerIOResponse queryResponse = await _client.QueryCustomerIOAsync(queryCustomer);

            var resp = queryResponse.QUERYCUSTOMER_IOFS_RES.FCUBS_BODY.CustomerFull;

            var error = queryResponse.QUERYCUSTOMER_IOFS_RES.FCUBS_BODY.FCUBS_ERROR_RESP[0][0].ECODE ?? string.Empty;

            List<CustomerEntity> customers = new();
            return customers;
        }

        public async Task<int> CreateAsync (CustomerRequest request)
        {

            CreateCustomer customer = new(request);
            

            var result = await _client.CreateCustomerFSAsync(customer);

            //var retorno = result.CREATECUSTOMER_FSFS_RES.FCUBS_BODY.FCUBS_ERROR_RESP;
           
            //string code = retorno[0][0].ECODE;
            //string codeDesc = retorno[0][0].EDESC;

            ////if(string.Compare)

            ////Aca convertir result a objeto Response
    
            return 1;
        }
          
        public async Task<CustomerEntity> GetByIdAsync(ObjectId customerId)
        {

            TipoCambioSoapClient c = new TipoCambioSoapClient(new TipoCambioSoapClient.EndpointConfiguration());
            var x = c.TipoCambioDiaAsync();



            throw new ApplicationException("---- Reintentando -----");

            return await Task.FromResult(GetById(customerId));
        }

        public async Task<RecordSavedResponse> Create(CustomerRequest customer)
        {
 

            CreateCustomer create = new CreateCustomer(customer);
            
            RecordSavedResponse response = new();

            if (customer != null)
            {
                response.Success = false;
                response.ErrorMessage = "Este es un error";
                _logger.LogError($"Ha ocurrido un error {nameof(Create)}");
            }

            return response;
        }

        public async Task<CustomerEntity> UpdateAsync(CustomerEntity customer)
        {
            return await Task.FromResult<CustomerEntity>(Update(customer));
        }

        public CustomerEntity Update(CustomerEntity customer)
        {
            CustomerEntity customerNew = new() { Name = "Wilhelm", LastName = "Sauerbaum", Age = 20, Address="123455" };
            return customerNew;
        }

        public CustomerEntity GetById(ObjectId customerId)
        {
            CustomerEntity customer = new() { Name = "Wilhelm", LastName = "Sauerbaum", Age = 20, Address = "123455" };
            return customer;
        }
    }
}
