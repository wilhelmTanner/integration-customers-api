using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUBS.Customer.Service.Common.Interfaces.Requests
{
    public interface ICustomerRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //Maxlength 9
        public int Code { get; set; }

        //maxlen 35
        //required false
        [Range(0, 35, ErrorMessage = "El largo del nombre es máximo de 35 carácteres")]
        public string Name { get; set; }

        //maxlen 105
        public string FullName { get; set; }

        //maxlen 35
        public string FirstName { get; set; }

        //maxlen 35
        public string MiddleName { get; set; }

        //maxlen 20 //SNAME
        public string LastName { get; set; }
        public string SecondLastName { get; set; }

        public int Age { get; set; }

        //UNIX TIME?
        public string BirdthDate { get; set; }

        //maxlen 105
        //required true
 
        public string Address { get; set; }

        //maxlen 30*
        public string City { get; set; }

        //maxlen 3
        public string Country { get; set; }

        //maxlen 10
        public string Category { get; set; }

        //maxlen 15
        public string Media { get; set; }
        //maxlen 3
        public string Location { get; set; }

        public string PersonalInformation { get; set; }
        //maxlen 3
        public string Language { get; set; }

        //Indicates Nationality
        //required false
        public string Nationality { get; set; }

        //Indicates Gender M - Male F - Female O - Other P - Prefer Not to Disclose
        public string Gender { get; set; }

        //maxlen 255
        //required false
        public string Email { get; set; }

    }
}
