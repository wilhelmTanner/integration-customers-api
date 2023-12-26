﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Tanner.Integration.Common.Models.Entities
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(Customer customer) { 

            Id = customer.Id;
            Name = customer.Name;
            LastName = customer.LastName;
            SecondLastName = customer.SecondLastName;
            Age = customer.Age;
            BirdthDate = customer.BirdthDate;
        
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }

        public int Age { get; set; }

        public DateTime? BirdthDate { get; set;}

    }
}
