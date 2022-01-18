using Common.Model;
using Common.Model.GenericModel;
using Common.Model.ResponseModel;
using DBContext.Data;
using KU_Banking.Services;
using Microsoft.AspNetCore.Mvc;

namespace KU_Banking.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountServices accountServices;


        public AccountController(IAccountServices accountServices) {
            this.accountServices = accountServices;
        }

        [HttpGet("GetAccounts")]
        [ProducesResponseType(typeof(ResponseType<Account>), StatusCodes.Status200OK)]
        public IActionResult Get() {
            return new ObjectResult(accountServices.GetAcounts());
        }
    }
}