using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            var users = StaticDB.userNames;

            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("index")]
        public ActionResult<List<string>> GetByIndex(int index)
        {
            var users = StaticDB.userNames;

            try
            {
                if (index < 0)
                {
                    return BadRequest("The value of the index canot be negative");
                }
                if (index >= users.Count)
                {
                    return NotFound($"The info on index-{index} does not exist");
                }
                return Ok(users[index]);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred, try again later");
            }
            
        }
    }
}
