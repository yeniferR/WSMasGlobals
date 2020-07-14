using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CreateEmployees
    {
        public string NAME { get; set; }
        public string CONTRACTTYPENAME {get; set;}
        public int HOURLYSALARY { get; set; }
        public int MONTHLYSALARY { get; set; }
        public int IDENTIFICATIONNUMBER { get; set; }

    }
}