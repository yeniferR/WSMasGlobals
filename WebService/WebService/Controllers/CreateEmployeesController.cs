using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    [RoutePrefix("/Api/CreateEmployees/")]
    public class CreateEmployeesController : ApiController
    {
        [HttpPost]
        public object Any(CreateEmployees request)
        {
            var name = request.NAME;
            var Contract = request.CONTRACTTYPENAME;
            var hourlysalary = request.HOURLYSALARY;
            var monthlysalary = request.MONTHLYSALARY;
            var identificacionnumber = request.IDENTIFICATIONNUMBER;
            int Total;
            if (Contract == "HourlySalaryEmployee")
            {
                Total = 120 * hourlysalary * 12;
            }
            else
            {
                Total = monthlysalary * 12;
            }

            EmployeeData c = new EmployeeData();
            c.Db = Globals.GlobalConnection;
            var r = c.InsertEmployees(name, Contract, hourlysalary, monthlysalary, identificacionnumber, Total);
            if (r)
            {
                return new ServiceModel.ErrorResponse
                {

                    Message = "creado"
                };
            }
            else
            {
                return new ServiceModel.ErrorResponse
                {

                    Message = "no"
                };
            }



            //return Total;
        }
    }
}
