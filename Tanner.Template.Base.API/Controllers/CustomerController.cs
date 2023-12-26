using Microsoft.AspNetCore.Mvc;
using Tanner.Integration.Common.Interfaces.Services;
using Tanner.Integration.Common.Models.Entities;
using Tanner.Integration.Service.Implementations;
using Tanner.Template.Base.API.ActionResults;
using Tanner.Template.Base.API.Controllers;

namespace Tanner.Integration.API.Controllers
{
    [SwaggerTag("Endpoints de servicio X")]
    [Route("api/template/customer")]
    [ApiController]
    public class CustomerController : CustomControllerBase
    {
        private readonly ICustomerService _customerService;
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
        //[SwaggerResponse((int)HttpStatusCode.OK, type: typeof(BaseObjectResponse<ItemObjectResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse(200, "Success", typeof(BaseObjectResponse<Customer>))]
        public async Task<ActionResult<BaseObjectResponse<Customer>>> InsertCustomer([FromBody] Customer customer)
        {
            var response = await _customerService.Insert(customer);


            return CustomOk(customer);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(BaseObjectResponse<Customer>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(BaseErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<BaseObjectResponse<Customer>>> GetById() {

            var response = await _customerService.GetById(new MongoDB.Bson.ObjectId());

            return CustomOk(response);

        }

 
    }

}
