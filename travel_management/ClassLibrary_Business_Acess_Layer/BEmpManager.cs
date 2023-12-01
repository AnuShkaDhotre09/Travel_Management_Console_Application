using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Business_Acess_Layer;
using travel_management;
namespace ClassLibrary_Business_Acess_Layer
{
    public interface BEmpManager
    {
        int AddEmployee_BAL(int e_id, string F_nm, string L_nm, string address, long contact, string dob);

        
        int DeleteEmployee_BAL(int e_id);
        void ViewAllEmployees();
        void EditEmployee_BAL(Employee e);
        Employee GetEmployeeById_BAL(int id);
    }
}
