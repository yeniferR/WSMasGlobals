using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class EmployeeData
    {
        public const string connectionString = "User Id=system;Password=nuva2019;Data Source=testlab;Pooling=False;Statement Cache Size=20;Self Tuning=false;Persist Security Info=True;";
        public virtual OracleConnection Db { get; set; }

        public DataSet getEmployee(int cedula)
        {
            //mensaje = "";
            DataSet resultado = new DataSet();

            using (OracleCommand command = (OracleCommand)Db.CreateCommand())
            {
                Helper.OpenDb(Db);
                command.CommandText = $"select * from employee where IDENTIFICATIONNUMBER='{cedula}'";

                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                try
                {
                    OracleDataReader r = (OracleDataReader)command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable data = new DataTable();
                    int i = 0;
                    do
                    {
                        data = new DataTable();
                        data.Load(r);

                        if (data.Rows.Count > 0)
                        {

                            switch (i)
                            {
                                case 0:
                                    data.TableName = "EMPLOYEE";
                                    break;
                            }


                            resultado.Tables.Add(data);
                            i++;
                        }
                    } while (!r.IsClosed);

                }
                catch (Exception ex)
                {
                    resultado = null;
                    //mensaje = ex.Message;
                }

                return resultado;

            }
        }



        public DataSet allEmployees()
        {
            //mensaje = "";
            DataSet resultado = new DataSet();

            using (OracleCommand command = (OracleCommand)Db.CreateCommand())
            {
                Helper.OpenDb(Db);
                command.CommandText = $"select * from employee";

                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                try
                {
                    OracleDataReader r = (OracleDataReader)command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable data = new DataTable();
                    int i = 0;
                    do
                    {
                        data = new DataTable();
                        data.Load(r);

                        if (data.Rows.Count > 0)
                        {

                            switch (i)
                            {
                                case 0:
                                    data.TableName = "EMPLOYEES";
                                    break;
                            }


                            resultado.Tables.Add(data);
                            i++;
                        }
                    } while (!r.IsClosed);

                }
                catch (Exception ex)
                {
                    resultado = null;
                    //mensaje = ex.Message;
                }

                return resultado;

            }
        }


        public bool InsertEmployees(
         string name,
         string contractype,
         int hourlysalary,
         int monthlysalary,
         int identificacionnumber,
         int Total
       )
        {
            using (OracleCommand command = (OracleCommand)Db.CreateCommand())
            {
                Helper.OpenDb(Db);
                command.CommandText = $"  INSERT INTO employee  VALUES ('{name}','{contractype}','{hourlysalary}','{monthlysalary}','{identificacionnumber}','{Total}')";
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }


    }

}