using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_management;

namespace ClassLibrary_DataAcessLayer
{
    public interface IEmpManager
    {
        int AddEmployee_DAL(int e_id, string F_nm, string L_nm, string address, long contact, string dob);
        void EditEmployee_DAL(Employee e);

        int DeleteEmployee_DAL(int e_id);
        void ViewAllEmployees();
        Employee GetEmployeeById_DAL(int id);
       

    }
}
