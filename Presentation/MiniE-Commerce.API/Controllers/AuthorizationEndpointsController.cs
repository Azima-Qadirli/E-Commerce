using Microsoft.AspNetCore.Mvc;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint()
        {
            return Ok();
        }
    }
}
