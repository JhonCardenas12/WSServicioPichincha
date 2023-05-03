using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSServicioPichincha.Security.Models;

namespace WSServicioPichincha.Security.Services
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResponse> GetToken(AuthorizationRequest authorization);
    }
}
