using Microsoft.AspNetCore.Mvc;
using MiniE_Commerce.Application.Configurations;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeServicesController : ControllerBase
    {
        readonly IApplicationService _applicationService;

        public AuthorizeServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var data = _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(data);
        }
    }
}
