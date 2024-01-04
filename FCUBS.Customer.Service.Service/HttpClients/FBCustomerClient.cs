
using FCUBSCustomerServiceReference;
using System;

namespace FCUBS.Customer.Service.Services.HttpClients;
public class FBCustomerClient
{
    private static readonly Lazy<FCUBSCustomerServiceSEIClient> _clientLazy = new Lazy<FCUBSCustomerServiceSEIClient>(() =>
           new FCUBSCustomerServiceSEIClient(new FCUBSCustomerServiceSEIClient.EndpointConfiguration()));
    public static FCUBSCustomerServiceSEIClient Client
    {
        get { return _clientLazy.Value; }
    }
}

