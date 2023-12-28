using MongoDB.Bson;
using Polly;
using Prometheus;

namespace IntegrationCustomers.API.Controllers
{
    [SwaggerTag("Endpoints de servicio Clientes")]
    [Route("api/cliente")]
    [ApiController]
    public sealed class CustomerController : CustomControllerBase
    {
        private readonly ICustomerService _customerService;
        private const int RETRIES = 4;
        private const int DELAY = 5;

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
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(BaseObjectResponse<CustomerEntity>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<BaseObjectResponse<RecordSavedResponse>>> UpdateCustomer([FromBody] CustomerEntity customer)
        {
            var response = await _customerService.UpdateAsync(customer);
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
        public async Task<ActionResult<BaseObjectResponse<CustomerEntity>>> GetById()
        {


            var policy = Policy.Handle<ApplicationException>()
                .WaitAndRetryAsync(RETRIES, tiempo => TimeSpan.FromSeconds(1 * DELAY), (exception, timeSpan, retry, ctx) =>
                {
                    Console.WriteLine($"Exception {exception.GetType().Name} with message {exception.Message} detected on attempt {retry} of {RETRIES}");
                });

            var response = await policy.ExecuteAsync(() =>
            {

                //throw new ApplicationException("---- Reintentando -----");

                Random randomNumber = new Random();

                if (randomNumber.Next(1, 3) == 2) throw new ApplicationException(" * Reintentando * ");

                return _customerService.GetByIdAsync(new MongoDB.Bson.ObjectId());
            });

            var jsondata = response.ToJson();
            Console.WriteLine($"json: {jsondata}");

            return CustomOk(response);
        }


    }

}
