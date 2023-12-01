using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_management;

namespace ClassLibrary_DataAcessLayer
{
    public class EmpDataManager : IEmpManager

    {
      
        public List<Employee> lstEmployee = new List<Employee> {
             new Employee()
            {
                Emp_id = 1,Fn="Saad",Ln="Khan",emp_add= "Karachi",emp_con= 9518609671, emp_dob= "5/012/1988"
            },
            new Employee()
            {
                Emp_id = 2,Fn="Samriddhi",Ln="Singh",emp_add="Aagra",emp_con=9119744358,emp_dob="30/08/2002"
            }
            ,
            new Employee()
            {
                Emp_id = 3,Fn="Geet",Ln="Pandit",emp_add= "Akkalkot",emp_con= 8945762344, emp_dob= "26/06/1996"
            },
              new Employee()
            {
                Emp_id = 4,Fn="Wahaj",Ln="Ali",emp_add= "Lahore",emp_con= 8945762343, emp_dob= "22/08/1998"
            },

             


        };
        
        public int AddEmployee_DAL(int e_id, string F_nm, string L_nm, string address, long contact, string dob)
        {
           // Employee emp=new Employee( e_id,  F_nm,  L_nm, address, contact, dob);

            lstEmployee.Add(new Employee(){ Emp_id = e_id, Fn = F_nm, Ln = L_nm, emp_add = address, emp_con = contact, emp_dob = dob });
           
            //  Console.WriteLine(emp.ToString());
            return 1;
        }
        public void ViewAllEmployees()
        {
            foreach (Employee e in lstEmployee)
            {
                Console.WriteLine(e.ToString());
            }
        }

    public void EditEmployee_DAL(Employee e)
        {
            Employee emp_Main=lstEmployee.FirstOrDefault(X => X.Emp_id == e.Emp_id);

            int index = lstEmployee.IndexOf(emp_Main);
            lstEmployee[index].Fn = e.Fn;
            lstEmployee[index].Ln = e.Ln;
            lstEmployee[index].emp_add = e.emp_add;
            lstEmployee[index].emp_con = e.emp_con;
}

       
        public  int DeleteEmployee_DAL(int e_id)
        {

             var employeeToDelete = lstEmployee.Find(emp =>emp.Emp_id == e_id);



            if (employeeToDelete != null)
            {
                lstEmployee.Remove(employeeToDelete);

                return 1;
            }
            return 0;
            
        }

        public Employee GetEmployeeById_DAL(int id)
        {
            Employee employees=lstEmployee.FirstOrDefault(e=>e.Emp_id==id);
            if (employees !=null)
            {
                return employees;
            }
            return null;
        }
    }


}
