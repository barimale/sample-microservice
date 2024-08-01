using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Infrastructure
{
    public class HttpResponse: HttpBase
    {
        protected HttpResponse() : base()
        {

        }

        [Required]
        public string IdentityGuid { get; private set; }
    }
}
