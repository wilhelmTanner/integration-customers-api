using MongoDB.Bson;
using Polly;

namespace IntegrationCustomers.API.Controllers
{
    [SwaggerTag("Endpoints de servicio Clientes")]
    [Route("api/cliente")]
    [ApiController]
    public sealed class CustomerController : CustomControllerBase
    {
        private readonly ICustomerService _customerService;
        private const int RETRIES = 4;

        public CustomerController(ICustomerService service)
        {
            _customerService = service;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(BaseObjectResponse<CustomerEntity>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
         public async Task<ActionResult<BaseObjectResponse<RecordSavedResponse>>> InsertCustomer([FromBody] CustomerEntity customer)
        {
            var response = await _customerService.Insert(customer);
            return CustomOk(response);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(BaseObjectResponse<CustomerEntity>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<BaseObjectResponse<CustomerEntity>>> GetById() {


            var policy = Policy.Handle<ApplicationException>()
                .RetryAsync(RETRIES, (ex, retryCount) =>
                {
                    Console.WriteLine($"Current attempt: {retryCount}, {ex}");
                });


            var response = await policy.ExecuteAsync(()=>
            {
                Random randomNumber = new Random();

                if (randomNumber.Next(1, 5) == 4) throw new ApplicationException("Attempt error");

               return _customerService.GetById(new MongoDB.Bson.ObjectId()); 
            });

            //var response = await _customerService.GetById(new MongoDB.Bson.ObjectId());
            var jsondata = response.ToJson();
            Console.WriteLine($"json: {jsondata}");

            return CustomOk(response);
        }

 
    }

}
