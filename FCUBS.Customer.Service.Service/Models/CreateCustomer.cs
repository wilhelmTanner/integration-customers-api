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
            FCUBS_BODY.CustomerFull.ADDRLN1 = customer.Id;
            FCUBS_BODY.CustomerFull.CUSTNO = customer.Id;
            FCUBS_BODY.CustomerFull.COUNTRY = customer.Id;
            FCUBS_BODY.CustomerFull.CCATEG = customer.Id;
            FCUBS_BODY.CustomerFull.MEDIA = "MEDIA";
            FCUBS_BODY.CustomerFull.LOC = customer.Id;
            FCUBS_BODY.CustomerFull.Custpersonal.LANG = customer.Id;
        } 

        public CreateCustomer()
        {

        }
    }
}
