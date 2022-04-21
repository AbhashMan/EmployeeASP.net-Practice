using Common_Entities;
using Employee_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Interface
{
    public interface IEmployee
    {
        JsonResponse AddEmployee(ATTEmployee aTTEmployee);

        JsonResponse GetAllEmployees();

        JsonResponse GetAllEmployees(int? EmpId);

        JsonResponse UpdateEmployee(ATTEmployee updatedEmployee);

        JsonResponse DeleteEmployee(int EmpId);
    }
}
