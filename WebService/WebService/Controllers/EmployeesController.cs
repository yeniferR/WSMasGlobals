using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    [RoutePrefix("/Api/AllEmployees/")]
    public class EmployeesController : ApiController
    {
        [HttpGet]

        public object Any()
        {
            EmployeeData cEmployeed = new EmployeeData();
            cEmployeed.Db = Globals.GlobalConnection;
            //var x = request.cedula;
            var tablesEmployees = cEmployeed.allEmployees();


            return tablesEmployees;


        }
    }
}
