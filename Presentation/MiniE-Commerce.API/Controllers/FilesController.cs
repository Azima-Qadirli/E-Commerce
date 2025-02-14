using Microsoft.AspNetCore.Mvc;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        readonly IConfiguration _configuration;

        public FilesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("[action]")]
        public IActionResult GetBaseUrl()
        {
            return Ok(new
            {
                Url = _configuration["BaseStorageUrl"]
            });
        }
    }
}
