using FCUBSCustomerServiceReference;
namespace FCUBS.Customer.Service.Services.Models
{
    public class QueryCustomer : QUERYCUSTOMER_IOFS_REQ
    {
        public QueryCustomer(CustomerRequest customer)
        {
            this.FCUBS_BODY.CustomerIO.CUSTNO = customer.Id;
            this.FCUBS_HEADER.PASSWORD = string.Format("{0}{1}", customer.Id, customer.Code);
        }
    }
}