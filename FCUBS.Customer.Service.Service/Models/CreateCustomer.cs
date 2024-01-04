using FCUBSCustomerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsTipoCambio;

namespace FCUBS.Customer.Service.Services.Models
{
    public class CreateCustomer : CREATECUSTOMER_FSFS_REQ
    {
        public CreateCustomer(CustomerRequest customer)
        {
            CREATECUSTOMER_FSFS_REQ.FCUBS_BODY.CustomerFull.ADDRLN1 = customer.Name;
            CREATECUSTOMER_FSFS_REQ.FCUBS_BODY.CustomerFull.CUSTNO = customer.Id;
            CREATECUSTOMER_FSFS_REQ.FCUBS_BODY.CustomerFull.COUNTRY = customer.Country;
            CREATECUSTOMER_FSFS_REQ.FCUBS_BODY.CustomerFull.CCATEG = customer.Category;
            CREATECUSTOMER_FSFS_REQ.FCUBS_BODY.CustomerFull.MEDIA = "MEDIA";
            CREATECUSTOMER_FSFS_REQ.FCUBS_BODY.CustomerFull.LOC = customer.Location;
            CREATECUSTOMER_FSFS_REQ.FCUBS_BODY.CustomerFull.Custpersonal.LANG = customer.Language;
        } 

        public CreateCustomer()
        {

        }
    }
}
