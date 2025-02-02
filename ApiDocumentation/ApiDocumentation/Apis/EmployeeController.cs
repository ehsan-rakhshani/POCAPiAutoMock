using Microsoft.AspNetCore.Mvc;

namespace ApiDocumentation.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return null;
        }
    }
}
