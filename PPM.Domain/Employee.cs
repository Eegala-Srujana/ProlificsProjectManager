using System.Security.Cryptography.X509Certificates;
using PPM.Model;

namespace PPM.Domain
{

    public class Employee : IEntityOperatio<EmployeeDetails>
    {
        public static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();

        public void AddEntity(EmployeeDetails employeeDetails)

        {

            employeeList.Add(employeeDetails);
        }
        public void DeleteById(int id)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].EmployeeId == id)
                {
                    employeeList.Remove(employeeList[i]);
                }
            }


        }
        public List<EmployeeDetails> ListAll()
        {
            return employeeList;
        }

        public EmployeeDetails ListById(int id)
        {
            return Employee.employeeList.SingleOrDefault(p => p.EmployeeId == id)!;


        }
    }
}