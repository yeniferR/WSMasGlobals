using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    [RoutePrefix("/Salary/api/calcularSalario/")]
    public class ValoresSalarialesController : ApiController
    {
        [HttpPost]
        public object Any(Salario request)
        {
            var Contract = request.type_Contract;
            var Salary = request.Hourly_Monthly;
            int Total;
            if (Contract == "HourlySalaryEmployee")
            {
              Total = 120 * Salary * 12;
            }
            else
            {
               Total= Salary * 12;
            }

            return Total;
        }


    }
}
