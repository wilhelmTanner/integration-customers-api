using System;
using FCUBSCustomerServiceReference;
using MongoDB.Driver;
namespace FCUBS.Customer.Service.Services.Models
{
    public class QueryCustomer : QUERYCUSTOMER_IOFS_REQ
    {
        public QueryCustomer(CustomerRequest customer): base()
        {
            InitializeHeader();
            InitializeBody();

            FCUBS_HEADER.SOURCE = customer.Source;//Falta definicion

            FCUBS_HEADER.UBSCOMP = UBSCOMPType.FCUBS; //enumeration(FCUBS,FCIS)

            FCUBS_HEADER.MSGID = customer.MessageId;//Indicate the Id that valid the response to the request Optional pattern [a-zA-Z_0-9]*

            FCUBS_HEADER.USERID = customer.UserId;//Indicate the user of flexcube that does the request maxLength(12)   pattern [A-Z_0-9]*

            FCUBS_HEADER.BRANCH = customer.Branch;//Indicate the number of the branch  length(3) - pattern [a-zA-Z_0-9]{3}

            FCUBS_HEADER.SERVICE = customer.Service;//Indicate the service that is being occupied (FCUBSCustomerService) pattern [a-zA-Z_0-9]*

            FCUBS_HEADER.OPERATION = customer.Operation;//Indicate the operation that is being occupied (QueryCustomer)  pattern [a-zA-Z_0-9]*

            FCUBS_HEADERTypePARAM addl = new() { VALUE = customer.Id, NAME = customer.Id };
            
            FCUBS_HEADER.ADDL = [addl];

            FCUBS_BODY.CustomerIO.CUSTNO = customer.Id; //"	Indicates Customer No" maxLength(9)


        }

        private void InitializeHeader()
        {
            FCUBS_HEADER = new FCUBS_HEADERType();
        }

        private void InitializeBody()
        {
            FCUBS_BODY = new QUERYCUSTOMER_IOFS_REQFCUBS_BODY
            {
                CustomerIO = new CustomerQueryIOType()
            };
        }
    }
}