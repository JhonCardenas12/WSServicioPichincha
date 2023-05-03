using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WSServicioPichincha.Security.Models;


namespace WSServicioPichincha.Security.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly string KeyJwt;
        private readonly string User;
        public AuthorizationService(IConfiguration configuration)
        {
            KeyJwt = configuration.GetSection("JwtSettings").GetSection("Key").Value.ToString();
            User = configuration.GetSection("JwtSettings").GetSection("User").Value.ToString();
        }
        public async Task<AuthorizationResponse> GetToken(AuthorizationRequest authorization)
        {
            AuthorizationResponse authorizationResponse = new();
            try
            {
                if (!string.IsNullOrEmpty(authorization.User) && authorization.User == User)
                {
                    byte[] keyJwtBytes = Encoding.ASCII.GetBytes(KeyJwt);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, authorization.User));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyJwtBytes), SecurityAlgorithms.HmacSha256Signature)

                    };
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SecurityToken tokenConfig = tokenHandler.CreateToken(tokenDescriptor);


                    authorizationResponse.Token = tokenHandler.WriteToken(tokenConfig);
                    authorizationResponse.Message = "Token Creado con exito";
                    authorizationResponse.Success = true;

                }
                else
                {
                    authorizationResponse.Token = string.Empty;
                    authorizationResponse.Message = "Usuario no existe, por favor comunicarse con el administrador.";
                    authorizationResponse.Success = false;
                }
            }
            catch (Exception ex)
            {
                authorizationResponse.Token = string.Empty;
                authorizationResponse.Message = ex.Message;
                authorizationResponse.Success = false;
            }
            return authorizationResponse;
        }
    }
}
