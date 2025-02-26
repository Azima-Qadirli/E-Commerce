using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetRoles()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public Task<IActionResult> GetRole(string id)
        {
            return Ok();
        }

        [HttpPost]
        public Task<IActionResult> CreateRole()
        {
            return Ok();
        }

        [HttpPut("{Id}")]
        public Task<IActionResult> UpdateRole()
        {
            return Ok();
        }

        [HttpDelete("{Id}")]
        public Task<IActionResult> DeleteRole()
        {
            return Ok();
        }
    }
}
