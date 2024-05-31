using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddleWare_ExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController() { }


        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            throw new Exception();
            return Ok(new[] { 1,2,3,4,5,6,});
        }
    }
}
