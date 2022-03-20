using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Okta.Example.Api.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("api")]
    public class InfoController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("whoami")]
        public Dictionary<string, string> GetAuthorized()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;
            return principal.Claims
                .GroupBy(claim => claim.Type)
                .ToDictionary(claim => claim.Key, claim => claim.First().Value);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("hello")]
        public string GetAnonymous()
        {
            return "You are anonymous";
        }
    }
}
