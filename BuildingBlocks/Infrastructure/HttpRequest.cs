using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Infrastructure
{
    public class HttpRequest: HttpBase
    {
        protected HttpRequest():base()
        {
            
        }

        [Required]
        public string IdentityGuid { get; private set; }
    }
}
