using System;
using FCUBSCustomerServiceReference;
namespace FCUBS.Customer.Service.Services.Models
{
    public class QueryCustomer : QUERYCUSTOMER_IOFS_REQ
    {
        public QueryCustomer(CustomerRequest customer): base()
        {
            InitializeHeader();
            InitializeBody();

            FCUBS_HEADER.SOURCE = "";
            FCUBS_HEADER.UBSCOMP = UBSCOMPType.FCUBS; //FCUBS,FCIS

            FCUBS_HEADER.MSGID = customer.Id;
            FCUBS_HEADER.USERID = customer.Id;
            FCUBS_HEADER.BRANCH = customer.Id;
            FCUBS_HEADER.SERVICE = customer.Id;
            FCUBS_HEADER.OPERATION = customer.Id;

            FCUBS_HEADERTypePARAM addl = new FCUBS_HEADERTypePARAM() { VALUE = customer.Id, NAME = customer.Id };
            
            FCUBS_HEADER.ADDL = [addl];

            FCUBS_BODY.CustomerIO.CUSTNO = customer.Id;

        }

        private void InitializeHeader()
        {
            FCUBS_HEADER = new FCUBS_HEADERType();
        }

        private void InitializeBody()
        {
            FCUBS_BODY = new QUERYCUSTOMER_IOFS_REQFCUBS_BODY(); 
            FCUBS_BODY.CustomerIO = new CustomerQueryIOType();
        }
    }
}