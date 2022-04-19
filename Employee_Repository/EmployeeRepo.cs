using Common_Entities;
using Employee_Entity;
using Employee_Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;

namespace Employee_Repository
{
    public class EmployeeRepo : IEmployee
    {
        IOptions<ReadConfig> _connectionString;
        public EmployeeRepo(IOptions<ReadConfig> connectionString) 
        {
            _connectionString= connectionString;
        }
        public JsonResponse AddEmployee(ATTEmployee aTTEmployee)
        {
            JsonResponse jsonResponse = new JsonResponse();
            using (SqlConnection connection = new SqlConnection(_connectionString.Value.DefaultConnection))
            {
                try
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@EmpId", aTTEmployee.EmpId);
                        parameters.Add("@EmpName", aTTEmployee.EmpName);
                        parameters.Add("@EmpAge", aTTEmployee.EmpAge);
                        parameters.Add("@EmpDesignation", aTTEmployee.EmpDesignation);
                        parameters.Add("@EmpDepartment", aTTEmployee.EmpDepartment);
                        jsonResponse = connection.Query<JsonResponse>(sql: "AddEmployee", param: parameters, transaction: transaction,
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
                        if (jsonResponse.IsSuccess)
                            transaction.Commit();
                        else
                            transaction.Rollback();
                    }

                }
                catch (Exception ex)
                {
                    jsonResponse.Message = ex.Message;
                }
            }
            return jsonResponse;
        }
    }
}
