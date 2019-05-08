using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTracking.Models
{
    public class Company
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public CompanyStatus Status { get; set; }
    }

    public enum CompanyStatus {
        Activo,
        Inactivo
    }
}
