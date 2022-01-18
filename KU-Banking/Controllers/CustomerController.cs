using Common.Model.GenericModel;
using Common.Model.RequestModel;
using Common.Model.ResponseModel;
using DBContext.Data;
using KU_Banking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KU_Banking.Controllers {
    [ApiController]
    [Route("api/v1")]
    public class CustomerController : ControllerBase {


        private readonly ICustomerServices customerServices;


        public CustomerController(ICustomerServices customerServices) {
            this.customerServices = customerServices;
        }


        [HttpGet("GetCustomers")]
        [ProducesResponseType(typeof(ResponseType<Customer>), StatusCodes.Status200OK)]
        public IActionResult Get() {
            return new ObjectResult(customerServices.GetCustomers());
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(ResponseType<Customer>), StatusCodes.Status200OK)]
        public IActionResult Get([FromBodyAttribute] CreateCustomerRequest customer) {
            try {
                return new ObjectResult(customerServices.CreateCustomerAsync(customer));

            } catch (Exception ex) {
                throw new Exception();
            }
        }
    }
}
