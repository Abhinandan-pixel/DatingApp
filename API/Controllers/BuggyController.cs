using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }  

        [HttpGet("internal-server-error")]
        public ActionResult GetInternalServerError()
        {
            
            var thing = _context.Users.Find(-1);
            var thingToReturn = thing.ToString();
            return Ok(thingToReturn);
        }
    }
}