using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSServicioPichincha.Security.Models
{
    public class AuthorizationResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
