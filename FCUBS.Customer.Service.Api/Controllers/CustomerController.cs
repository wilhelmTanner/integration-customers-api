using FCUBS.Customer.Service.Common.Interfaces.Requests;
using MongoDB.Bson;
using Polly;
using Prometheus;

namespace FCUBS.Customer.Service.API.Controllers
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
        public async Task<ActionResult<BaseObjectResponse<int>>> Create([FromBody] CustomerRequest customer)
        {
            var response = await _customerService.CreateAsync(customer);
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
        public async Task<ActionResult<BaseObjectResponse<int>>> GetById(string id)
        {

            var req = Request.Headers;

            CustomerRequest c = new()
            {
                Id = id
            };

            var response = await _customerService.GetByIdAsync(c);

            var jsondata = response.ToJson();

            Console.WriteLine($"json: {jsondata}");
         
            return CustomOk(1);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("all")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(BaseObjectResponse<List<CustomerEntity>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<BaseObjectResponse<List<CustomerEntity>>>> GetAllAsync()
        {
            // var result = await _customerService.GetAllAsync();
            var l = new List<CustomerEntity>();

            return CustomOk(l);
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
        public async Task<ActionResult<BaseObjectResponse<CustomerEntity>>> UpdateCustomer([FromBody] CustomerRequest customer)
        {
            var response = await _customerService.UpdateAsync(customer);
            return CustomOk(response);
        }
    }

}
