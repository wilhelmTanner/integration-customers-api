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
    public class CustomerService : ICustomerService
    {

        private readonly ILogger<CustomerService> _logger;
        private FCUBSCustomerServiceSEIClient _client;

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
            _client = FBCustomerClient.Client;
        }

        public async Task<int> CreateAsync(CustomerRequest request)
        {

            CreateCustomer customer = new(request);

            var response = await _client.CreateCustomerFSAsync(customer);

            

            var errorDetail = response.CREATECUSTOMER_FSFS_RES.FCUBS_BODY.FCUBS_ERROR_RESP;
           
            //string code = retorno[0][0].ECODE;
            //string codeDesc = retorno[0][0].EDESC;

            ////if(string.Compare)

            ////Aca convertir result a objeto Response
    
            return 1;
        }
          
        public async Task<int> GetByIdAsync(CustomerRequest customer)
        {

            QueryCustomer queryCustomer = new QueryCustomer(customer);
            QueryCustomerIOResponse response = await _client.QueryCustomerIOAsync(queryCustomer);

            QueryCustomerResponse queryResponse = new(response);

            var resp = queryResponse.QUERYCUSTOMER_IOFS_RES.FCUBS_BODY.CustomerFull;

            var error = queryResponse.QUERYCUSTOMER_IOFS_RES.FCUBS_BODY.FCUBS_ERROR_RESP[0][0].ECODE ?? string.Empty;

            return 1;
        }

        public async Task<CustomerEntity> UpdateAsync(CustomerRequest customer)
        {
            CustomerEntity customerNew = new() { Name = "Wilhelm", LastName = "Sauerbaum", Age = 20, Address = "123455" };
            return customerNew;
        }

   
    }
}
