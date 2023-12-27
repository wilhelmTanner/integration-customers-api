
namespace IntegrationCustomers.Common.Models.Entities
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {
        }

        public CustomerEntity(CustomerEntity customer) { 

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
