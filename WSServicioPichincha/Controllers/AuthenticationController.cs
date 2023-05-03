using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSServicioPichincha.Security.Models;
using WSServicioPichincha.Security.Services;

namespace WSServicioPichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthorizationService authorizationService;
        public AuthenticationController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("GetToken")]
        public Task<AuthorizationResponse> GetToken([FromBody] AuthorizationRequest authorizationRequest)
        {
            return authorizationService.GetToken(authorizationRequest);
        }
    }
}
