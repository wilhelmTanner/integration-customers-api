using FCUBS.Customer.Service.Common.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUBS.Customer.Service.Common.Models.Requests
{
    public class CustomerRequest : ICustomerRequest
    {
        public string Source { get; set; }
        public string MessageId { get; set; }
        public string UserId { get; set; }
        public string Branch { get; set; }
        public string Service { get; set; }
        public string Operation { get; set; }
        public string Id { get; set; }

        //public int Code { get; set; }
        //public string Name { get; set; }
        //public string FullName { get; set; }
        //public string FirstName { get; set; }
        //public string MiddleName { get; set; }
        //public string LastName { get; set; }
        //public string SecondLastName { get; set; }
        //public int Age { get; set; }
        //public string BirdthDate { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        //public string Category { get; set; }
        //public string Media { get; set; }
        //public string Location { get; set; }
        //public string PersonalInformation { get; set; }
        //public string Language { get; set; }
        //public string Nationality { get; set; }
        //public string Gender { get; set; }
        //public string Email { get; set; }
    }
}
