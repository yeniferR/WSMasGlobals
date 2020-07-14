using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    
    [RoutePrefix("/Api/Employee/")]
    public class EmployeeController : ApiController
    {
        [HttpGet]

        public object Any(int cedula)
        {
            EmployeeData c = new EmployeeData();
            c.Db = Globals.GlobalConnection;
           
            var table = c.getEmployee(cedula);
            if (table.Tables.Count > 0)
            {

                return table;
            }

            return "No se encontro valor con el numero de cedula";

           
        }
    }
}
