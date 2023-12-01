using ClassLibrary_DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_management;

namespace ClassLibrary_Business_Acess_Layer
{
    public class Employee_BAL:BEmpManager
    {

        private readonly EmpDataManager _empData = new EmpDataManager();
       public int AddEmployee_BAL(int e_id, string F_nm, string L_nm, string address, long contact, string dob)
        {
  
            _empData.AddEmployee_DAL(e_id, F_nm, L_nm, address, contact, dob);
            return 1;
        }


   public int DeleteEmployee_BAL(int e_id)
        {
            
            _empData.DeleteEmployee_DAL(e_id);
            return 1;
        }
    public void ViewAllEmployees()
        {
            
            _empData.ViewAllEmployees();
        }
        public Employee GetEmployeeById_BAL(int id)
        {
            Employee e1 = _empData.GetEmployeeById_DAL(id);
            return e1;
        }

        public void EditEmployee_BAL(Employee emp_to_change)
        {
            _empData.EditEmployee_DAL(emp_to_change);
        }

    }
}
