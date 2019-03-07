using Domain_Layer.Compensations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer
{
    public class AccessPoint
    {
        public readonly Employee Employee;

        public AccessPoint(int employeeId)
        {
            Employee = Employee.GetEmployeeById(employeeId);
        }

        public Department Department => Employee.Department;

        public List<Compensation> GetAllCompensations()
        {
            return Employee.GetCompensations();
        }
    }
}