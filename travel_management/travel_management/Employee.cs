using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace travel_management
{
    public class Employee
    {

        public int Emp_id { get; set; }
     
        public string Fn { get; set; }

       
        public string Ln { set; get; }
        public string emp_add { get; set; }
        public long emp_con { get; set; }
        public string emp_dob { get; set; }

        /*public Employee(int id, string F_nm, string L_nm, string address, long contact, string dob) {
           Emp_id = id ;
            Fn = F_nm;
            Ln= L_nm;
            emp_add = address;
            emp_con=contact;
            emp_dob = dob;
               

        }*/
       
        
    public override string ToString()
        {
            return String.Format("\t{0,-11}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|{5,-10}",
                Emp_id, Fn, Ln, emp_add, emp_con, emp_dob);
        }

    }
}
