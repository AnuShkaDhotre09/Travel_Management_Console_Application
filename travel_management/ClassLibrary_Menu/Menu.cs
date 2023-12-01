using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Business_Acess_Layer;
using travel_management;
namespace ClassLibrary_Menu
{
    public class Menu
{
        private static readonly Employee_BAL emp=new Employee_BAL();
        private static readonly Travel_BAL _Trva = new Travel_BAL();
        public static int incrementID = 5;
        public static int incrementRId = 4;
        public void MainMenu()
        {
            int ch;
            try
            {
                do
            {
                
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("----------Welcome to Go Trip----------");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("---------------Main Menu--------------");
                    Console.WriteLine("1.Employee \n2.Travel \n3.AllView \n4.Exit");
                    Console.WriteLine("Enter Your Choice:");
                    ch = int.Parse(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Your Choice is Employee");
                            empMenu();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Your Choice is Travel");
                            travelMenu();
                            break;
                        case 3:
                        case 7:

                            Console.WriteLine("Your Choice is Join_EmpTra");
                            Join_EmpTra();
                            Console.ReadLine();

                            break;

                        case 4:
                            Console.WriteLine("Thank you visit again!!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter your Right Choice");
                            break;

                    }

                } while (ch == 4) ;

            }
             catch (Exception ex)
                {
                Console.WriteLine("Enter your Right Choice", ex.Message);


                Console.ReadLine();
            }
        }


        public void Emp_Add()
        {
            int ch;
             int id;
             long cont;
             string fn, ln, addr, dob;
           

            Console.WriteLine("Your Choice is Add");
            
            Console.WriteLine("Enter the First Name ");
            fn = Console.ReadLine();
            Console.WriteLine("Enter the Last Name ");
            ln = Console.ReadLine();
            Console.WriteLine("Enter the Address ");
            addr = Console.ReadLine();
            //cont
            Console.WriteLine("Enter the Contact ");
             cont = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Date of Birth ");
             dob = Console.ReadLine();
            emp.AddEmployee_BAL(incrementID++, fn, ln, addr, cont, dob);
        }
           


        
        public  void Emp_Update()
        {
           int ch;
            int id;
            long cont;
            string fn, ln, addr;
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Edit Employee Data");
            Console.WriteLine("-------------------------------------------------------------------------");
            emp.ViewAllEmployees();

            Console.WriteLine("\nEnter the Employee ID to Edit");

            id = int.Parse(Console.ReadLine());
            Employee emp_to_change = emp.GetEmployeeById_BAL(id);
            try
            {
                do
                {
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("Enter Your Choice:");


                    Console.WriteLine("***************************************************");
                    Console.WriteLine("************************* Employee Edit Page ********************");
                    Console.WriteLine("1.First Name \n2.Last Name \n3.Address \n4.Contact \n5 Back \n6 Exit");
                    Console.WriteLine("Enter Your Choice:");
                    ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:

                            Console.WriteLine("Enter the New First Name");
                            fn = Console.ReadLine();
                            emp_to_change.Fn = fn;
                            break;
                        case 2:

                            Console.WriteLine("Enter the New Last Name");
                            ln = Console.ReadLine();
                            emp_to_change.Ln = ln;
                            break;
                        case 3:

                            Console.WriteLine("Enter the New Address");

                            addr = Console.ReadLine();
                            emp_to_change.emp_add = addr;
                            break;
                        case 4:

                            Console.WriteLine("Enter the New Contanct");
                            cont = int.Parse(Console.ReadLine());
                            emp_to_change.emp_con = cont;

                            break;

                        case 5:
                            empMenu();
                            break;

                        case 6:

                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter Your Right Choice");
                            break;
                    }
                } while (ch != 6);
            }catch(Exception ex) {
                Console.WriteLine("Enter Your Right Choice");
                Console.WriteLine(ex.Message); }
            emp.EditEmployee_BAL(emp_to_change);

            Console.ReadLine();

        }
        public void Emp_Delete(int e_id)
        {
            emp.DeleteEmployee_BAL(e_id);

        }
        public  void Emp_View()
        {
            Console.WriteLine("\tView Employee Data");
            Console.WriteLine("\t-------------------------------------------------------------------------");
            Console.WriteLine("\t|{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|{5,-10}", "EmpID", "First Name", "Last Name", "Address", "Contact", "Date Of Birth");

            Console.WriteLine("\t-------------------------------------------------------------------------");
           
            emp.ViewAllEmployees();
        }


        public void empMenu()
        {
            int ch;
            try { 
            do
            {
                Console.WriteLine("***************************************************");
                Console.WriteLine("************ Welocome to Employee Screen **********");
                Console.WriteLine("***************************************************");
                Console.WriteLine("************************* Menu ********************");
                Console.WriteLine("1.Add \n2.Update \n3.Delete \n4.View \n5.Exit \n6.Back");
                Console.WriteLine("Enter Your Choice:");
                ch = int.Parse(Console.ReadLine());
             
                    switch (ch)
                    {
                        case 1:
                            Console.Clear();

                            Emp_Add();
                            Console.WriteLine("Data Added Successfully");

                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Your Choice is Update");
                            Emp_Update();
                            Console.WriteLine("Data Update Successfully");
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Your Choice is Delete");
                            Console.WriteLine("Enter ID");
                            int e_id = int.Parse(Console.ReadLine());
                            Emp_Delete(e_id);
                            Emp_View();
                            empMenu();
                            Console.WriteLine("\nData delete Successfully");
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Your Choice is View");
                            Emp_View();

                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        case 6:
                            MainMenu();
                            break;



                        default:
                            Console.WriteLine("Enter Your Right Choice");
                            break;
                    }
                } while (ch != 5) ;
            }catch(Exception ex)
            {
                Console.WriteLine("Enter Your Right Choice");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }




        public void Raise_Req()
        {
            int req_id;
            string fl; string tl; DateTime date; int e_id;

            Console.WriteLine("Your Choice is Raise Request");
          
            Console.WriteLine("Enter the From Location ");
            fl = Console.ReadLine();
            Console.WriteLine("Enter the To Location ");
            tl = Console.ReadLine();
        
            Console.WriteLine("Enter the request date ");
            date=DateTime.Parse( Console.ReadLine());
            Console.WriteLine("Enter your employee ID");
            e_id=int.Parse(Console.ReadLine());
            _Trva.RaiseRequest_BAL(incrementRId++, fl,tl,date,e_id);

        }
        public void Approve_Req()
        {

            int req_id;
            int ch;
            ApprovedStatus status=ApprovedStatus.Pendding;
            View_Req();
          
            Console.WriteLine("Your Choice is Approved");
            
            Console.WriteLine("Enter the Request Id ");
            req_id = int.Parse(Console.ReadLine());
            
            Travel emp_to_change = _Trva.GetTravelById_BAL(req_id);

            Console.WriteLine("1.Approved \n2.Not Approve  \n3.Exit\n4.Back");
                Console.WriteLine("Enter Your Choice:");
                ch = int.Parse(Console.ReadLine());
            try
            {
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Your Choice is Approved");
                        status = ApprovedStatus.Approved;
                        emp_to_change.Approved_status = status;
                        break;
                    case 2:
                        Console.WriteLine("Your Choice is Not Approved");
                        status = ApprovedStatus.Not_Approved;
                        emp_to_change.Approved_status = status;
                        break;

                    case 3:

                        Environment.Exit(0);
                        Console.WriteLine("Exit");
                        break;



                    case 4:
                        travelMenu();
                        break;


                    default:
                        Console.WriteLine("Enter your Right Choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter your Right Choice");
            }


            _Trva.ApprovedRequest_BAL(req_id, status);

        }
        public void Book_Req()
        {
            int req_id;
            int ch;
            BookingStatus Bstatus = BookingStatus.Available;
            View_Req();
            Console.WriteLine("Your Choice is Approved");
            Console.WriteLine("Enter the Request Id ");
            req_id = int.Parse(Console.ReadLine());
            Travel emp_to_change = _Trva.GetTravelById_BAL(req_id);
           
                Console.WriteLine("1.Available \n2.Not Available \n3.Exit\n4.Back");
                Console.WriteLine("Enter Your Choice:");
                ch = int.Parse(Console.ReadLine());
            try
            {
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Your Choice is Available");
                        Bstatus = BookingStatus.Available;
                        emp_to_change.Booking_status = Bstatus;
                        break;
                    case 2:
                        Console.WriteLine("Your Choice is Not Available");
                        Bstatus = BookingStatus.Not_Available;
                        emp_to_change.Booking_status = Bstatus;
                        break;


                    case 3:

                        Environment.Exit(0);
                        Console.WriteLine("Exit");
                        break;



                    case 4:
                        travelMenu();
                        break;


                    default:
                        Console.WriteLine("Enter your Right Choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter your Right Choice");
            }
            _Trva.ConfirmRequest_BAL(req_id, Bstatus);


        }
     
        public  void View_Req()
        {
            Console.WriteLine("\tView Travel Data");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t{0,-11} | {1,-10} | {2,-10} | {3,-17} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");

            _Trva.ViewTravelRequest_BAL();

        }

       
        public void Delete_Req(int r_id)
        {
            _Trva.DeleteRequest_BAL(r_id);

        }
       
        public void Update_Req()
        {
            int ch;
            int r_id;
            DateTime date;
            string fl, tl;
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Edit Travel Data");
            Console.WriteLine("-------------------------------------------------------------------------");
            _Trva.ViewTravelRequest_BAL();

            Console.WriteLine("\nEnter the Request ID to Edit");

            r_id = int.Parse(Console.ReadLine());
            Travel Trv_to_change = _Trva.GetTravelById_BAL(r_id);
            try
            {
                do
                {
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("Enter Your Choice:");


                    Console.WriteLine("***************************************************");
                    Console.WriteLine("************************* Travel Edit Page ********************");
                    Console.WriteLine("1.From Location \n2.To Location \n3.Date \n4.Back \n5 Exit");
                    Console.WriteLine("Enter Your Choice:");
                    ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:

                            Console.WriteLine("Enter the New From location");
                            fl = Console.ReadLine();
                            Trv_to_change.From_Location = fl;
                            break;
                        case 2:

                            Console.WriteLine("Enter the New To Location");
                            tl = Console.ReadLine();
                            Trv_to_change.To_Location = tl;
                            break;
                        case 3:

                            Console.WriteLine("Enter the New Date");

                            date = DateTime.Parse(Console.ReadLine());
                            Trv_to_change.Req_Date = date;
                            break;



                        case 4:
                            travelMenu();
                            break;

                        case 5:

                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter Your Right Choice");
                            break;
                    }
                } while (ch != 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter your Right Choice");
            }
            _Trva.EditRequest_BAL(Trv_to_change);

            Console.ReadLine();
        }

public void Join_EmpTra()
        {
            Console.WriteLine("\n\n {0,100}", "WELCOME ON MY VIEW ALL PAGE");
            Console.WriteLine("****************************************************************************************************************************************************************");
            Console.WriteLine("|{0,-6}|{1,-10}|{2,-8}|{3,-11}|{4,-20}|{5,-12}|{6,-6}|{7,-10}|{8,-10}|{9,-20}|{10,-10}|{11,-10}|{12,-10}", "ID",
                "F_Name", "L_Name", "Address", "D-O-B", "Contact", "R_ID", "Departure", "Arrival", "Date", "R_Status", "Booking", "Current Status");
            Console.WriteLine("****************************************************************************************************************************************************************");
            

            _Trva.JoinEmpTra_BAL();
            

        }
        public void travelMenu()
        {

            int ch;
            try
            {
                do
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("************ Welocome to Travel Screen ************");
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("************************* Menu ********************");

                    Console.WriteLine("1.Raise Request \n2.Approve Request \n3.Booking Status \n4.Delete \n5.View \n6.Edit \n7.Back\n8.Exit");
                    Console.WriteLine("Enter Your Choice:");
                    ch = int.Parse(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Your Choice is Raise Request");
                            Raise_Req();
                            View_Req();
                            Console.WriteLine("Request Raised Successfully");
                            break;
                        case 2:
                            Console.WriteLine("Your Choice is Approve Request");
                            Approve_Req();

                            Console.WriteLine("Request Approved Successfully");
                            
                            break;

                        case 3:
                            Console.WriteLine("Your Choice is Booking Status");
                            Book_Req();
                            
                            Console.WriteLine("Request Booked Successfully");
                            break;
                        case 4:

                            Console.WriteLine("Your Choice is Delete");
                            Console.WriteLine("Enter ID");
                            int r_id = int.Parse(Console.ReadLine());
                            Emp_Delete(r_id);
                            Emp_View();
                            empMenu();
                            Console.WriteLine("\nData delete Successfully");
                            break;

                        case 5:
                            Console.WriteLine("Your Choice is View");
                            View_Req();

                            break;
                          
                        case 6:

                            Console.WriteLine("Your Choice is Update");
                            Update_Req();
                            Console.WriteLine("Data Update Successfully");
                            break;

                     
                        case 7:
                            MainMenu();

                            break;
                        case 8:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter your Right Choice");
                            break;
                    }
                } while (ch != 8);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Enter your Right Choice");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();


        }

    }
}
