using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebService.Models;

namespace WebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            var dbFactory = new OrmLiteConnectionFactory(
                     connStr, ServiceStack.OrmLite.Oracle.OracleDialect.Provider);
            //container.Register<IDbConnectionFactory>(
            //    new OrmLiteConnectionFactory(connStr, ServiceStack.OrmLite.Oracle.OracleDialect.Provider));
            dbFactory.Open();
            Globals.GlobalConnection = new Oracle.ManagedDataAccess.Client.OracleConnection(dbFactory.ConnectionString);
            Globals.ConnectionString = dbFactory.ConnectionString;
            Globals.GlobalConnection.Open();
        }
    }
}
