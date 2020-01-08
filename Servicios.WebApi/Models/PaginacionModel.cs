using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.WebApi.Models
{
    public class PaginacionModel
    {
        public int Page { get; set; }
        public int Rows { get; set; }
        public int Id { get; set; }
    }
}
