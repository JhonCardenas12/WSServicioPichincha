using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSServicioPichincha.Domain.Exceptions
{
    public class ResponseExeption
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Message { get; set; }
    }
}
