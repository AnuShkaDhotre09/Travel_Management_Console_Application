using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_management;
using ClassLibrary_DataAcessLayer;
using ClassLibrary_Business_Acess_Layer;
using ClassLibrary_Menu;
namespace Employee
{
    enum ApprovedStatus { Approved, Not_Approved }
    enum BookingStatus { Available, Not_Available }

    enum CurrentStatus { Open, Close }
    internal class Program
    {


        public static void Main(string[] args)
        {
            Menu m1 = new Menu();
           m1.MainMenu();

           
            /* Console.WriteLine("\t------------------------------- EMPLOYEE VIEW ------------------------------");
             Console.WriteLine("\t----------------------------------------------------------------------------");
             Console.WriteLine("\t{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|{5,-10}","Emp_ID","First_Name","Last_Name","Address","Contact","DateOfBirth");
             Console.WriteLine("\t----------------------------------------------------------------------------");
             EmpDataManager e2=new EmpDataManager();
             e2.ViewAllEmployees();
             Console.WriteLine("\n\t----------------------- TRAVEL VIEW ---------------------------");
             Console.WriteLine("\t---------------------------------------------------------------");
             Console.WriteLine("\t{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-10}","Req_ID","From_Location","To_Location","Req_Date for Travel","Emp_ID ");
             Console.WriteLine("\t---------------------------------------------------------------");
             TravelDataManager t2 = new TravelDataManager();
             t2.ViewTravelRequest();

             EmpDataManager e3= new EmpDataManager();
             e3.DeleteEmployee_DAL(1);
             Console.WriteLine("\n\t--------------Show the data after deleting the id---------------");
             e3.ViewAllEmployees();*/

        }
    }
}

