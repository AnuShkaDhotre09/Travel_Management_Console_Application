using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using travel_management;

namespace ClassLibrary_DataAcessLayer


{
    public class TravelDataManager : IReqDataManager
{
        EmpDataManager empDataManager = new EmpDataManager();
        public List<Travel> ReqRaise = new List<Travel> {
            new Travel()
            {
               Req_id=1,From_Location="Pune",To_Location="Mumbai",Req_Date=DateTime.Parse("5/2/2021"),Emp_id=3,
               Approved_status=ApprovedStatus.Pendding,Booking_status=BookingStatus.Null,Cureent_status=CurrentStatus.Open
            }
            ,
            new Travel()
            {
               Req_id=2,From_Location="Chennai",To_Location="Aagra",Req_Date=DateTime.Parse("4/4/2023"),Emp_id=1,
               Approved_status=ApprovedStatus.Pendding,Booking_status=BookingStatus.Null,Cureent_status=CurrentStatus.Open
            },
              new Travel()
            {
                Req_id=3,From_Location="Banglore",To_Location="Kolkatta",Req_Date=DateTime.Parse("22/9/2022"),Emp_id=2,
                Approved_status=ApprovedStatus.Pendding,Booking_status=BookingStatus.Null,Cureent_status=CurrentStatus.Open
            }


        };

        public int RaiseRequest_DAL(int r_id, string lF, string lt, DateTime r_dt, int e_id)
        {
            // Travel t=new Travel( r_id,  lf,  lt, r_dt, e_id);

            ReqRaise.Add(new Travel() { Req_id = r_id, From_Location = lF, To_Location = lt, Req_Date = r_dt, Emp_id = e_id,
                Approved_status = ApprovedStatus.Pendding,
                Booking_status = BookingStatus.Null,
                Cureent_status = CurrentStatus.Open
            });

            //  Console.WriteLine(t.ToString());
            return 1;
        }
        public void EditRequest_DAL(Travel tr)
        {
            Travel Trv_Main = ReqRaise.FirstOrDefault(X => X.Req_id == tr.Req_id);

            int index = ReqRaise.IndexOf(Trv_Main);
            ReqRaise[index].From_Location = tr.From_Location;
            ReqRaise[index].To_Location = tr.To_Location;
            ReqRaise[index].Req_Date = tr.Req_Date;

        }

        public int DeleteRequest_DAL(int r_id)
        {
            var TravelDelete = ReqRaise.Find(tra => tra.Req_id == r_id);

            if (TravelDelete != null)
            {
                ReqRaise.Remove(TravelDelete);
                return 1;
            }

            return 0;
        }
        

        public int ApprovedRequest_DAL(int travel_id, ApprovedStatus appstatus)
        {


            var querymethodapprove = ReqRaise.FirstOrDefault(X => X.Req_id == travel_id);

            int index = ReqRaise.IndexOf(querymethodapprove);
            //var query = querymethodapprove.Approved_status = appstatus;
            ReqRaise[index].Approved_status = querymethodapprove.Approved_status;

            if (querymethodapprove != null)
            {
                if (querymethodapprove.Approved_status == ApprovedStatus.Approved)
                {
                    querymethodapprove.Cureent_status = CurrentStatus.Open;
                    approveView_DAL();
                }
                else if (querymethodapprove.Approved_status == ApprovedStatus.Not_Approved)
                {
                    querymethodapprove.Cureent_status = CurrentStatus.Close;
                    querymethodapprove.Booking_status = BookingStatus.Null;
                    NotApproveView_DAL();
                }
            }

            return 1;
        }

        public int ConfirmRequest_DAL(int travel_id, BookingStatus bookstatus)
        {

            var querymethodbooking = ReqRaise.FirstOrDefault(X => X.Req_id == travel_id);


            int index = ReqRaise.IndexOf(querymethodbooking);
            //var query = querymethodapprove.Approved_status = appstatus;
            ReqRaise[index].Booking_status = querymethodbooking.Booking_status;
            var query = querymethodbooking.Booking_status = bookstatus;

            if (querymethodbooking != null)
            {
                if (querymethodbooking.Booking_status == BookingStatus.Available)
                {
                    querymethodbooking.Cureent_status = CurrentStatus.Close;
                    bookingView_DAL();
                }
                else if (querymethodbooking.Booking_status == BookingStatus.Not_Available)
                {
                    querymethodbooking.Cureent_status = CurrentStatus.Close;

                    Not_bookingView_DAL();
                }
            }

            return 1;
        }



        public void ViewTravelRequest_DAL()
        {
            foreach (Travel t1 in ReqRaise)
            {
                Console.WriteLine(t1.ToString());
            }



        }


        public Travel GetTravelById_DAL(int id)
        {
            Travel tr = ReqRaise.FirstOrDefault(t => t.Req_id == id);
            if (tr != null)
            {
                return tr;
            }
            return null;



        }
         public void approveView_DAL()
        {
            var trv = from tr in ReqRaise
                      where tr.Approved_status==ApprovedStatus.Approved
                      select new
                      {
                         
                          r = tr.Req_id,
                          fl = tr.From_Location,
                          tl = tr.To_Location,
                          t_d = tr.Req_Date,
                          e = tr.Emp_id,
                          sa = tr.Approved_status,
                          sc = tr.Cureent_status,
                          sb = tr.Booking_status
                      };

            foreach (var em in trv)
            {


                Console.WriteLine("\tApproved View Travel Data");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\t{0,-11} | {1,-10} | {2,-13} | {3,-19} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");

                Console.WriteLine("\t{0,-11} | {1,-10} | {2,-13} | {3,-15} | {4,-8} | {5,-15} | {6,-14} | {7,-10}",
                  em.r, em.fl, em.tl, em.t_d, em.e, em.sa, em.sb, em.sc);
            }
        }

        public void NotApproveView_DAL()
        {
            var trv = from tr in ReqRaise
                      where tr.Approved_status == ApprovedStatus.Not_Approved
                      select new
                      {
                          
                          r = tr.Req_id,
                          fl = tr.From_Location,
                          tl = tr.To_Location,
                          t_d = tr.Req_Date,
                          e = tr.Emp_id,
                          sa = tr.Approved_status,
                          sc = tr.Cureent_status,
                          sb = tr.Booking_status
                      };

            foreach (var em in trv)
            {
                Console.WriteLine("\tNot Approved View Travel Data");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\t{0,-11} | {1,-10} | {2,-13} | {3,-19} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");

                Console.WriteLine("\t{0,-11} | {1,-10} | {2,-13} | {3,-15} | {4,-8} | {5,-15} | {6,-14} | {7,-10}",
                  em.r, em.fl, em.tl, em.t_d, em.e, em.sa, em.sb, em.sc);
            }
        }
        public void bookingView_DAL()
        {
            var trv = from tr in ReqRaise
                      where tr.Booking_status == BookingStatus.Available
                      select new
                      {
                          
                          r = tr.Req_id,
                          fl = tr.From_Location,
                          tl = tr.To_Location,
                          t_d = tr.Req_Date,
                          e = tr.Emp_id,
                          sa = tr.Approved_status,
                          sc = tr.Cureent_status,
                          sb = tr.Booking_status
                      };

            foreach (var em in trv)
            {
                Console.WriteLine("\t Booking View Travel Data");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\t{0,-11} | {1,-10} | {2,-13} | {3,-19} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");

                Console.WriteLine("\t{0,-11} | {1,-10} | {2,-13} | {3,-15} | {4,-8} | {5,-15} | {6,-14} | {7,-10}",
                  em.r, em.fl, em.tl, em.t_d, em.e, em.sa, em.sb, em.sc);
            }
        }
       public void Not_bookingView_DAL()
        {
            var trv = from tr in ReqRaise
                      where tr.Booking_status == BookingStatus.Not_Available
                      select new
                      {
                          
                          r = tr.Req_id,
                          fl = tr.From_Location,
                          tl = tr.To_Location,
                          t_d = tr.Req_Date,
                          e = tr.Emp_id,
                          sa = tr.Approved_status,
                          sc = tr.Cureent_status,
                          sb = tr.Booking_status
                      };

            foreach (var em in trv)
            {
                Console.WriteLine("\t Not Booking Travel Data");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\t{0,-11} | {1,-10} | {2,-13} | {3,-19} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------------------------");

                Console.WriteLine("\t{0,-11} | {1,-10} | {2,-13} | {3,-15} | {4,-8} | {5,-15} | {6,-14} | {7,-10}",
                  em.r, em.fl, em.tl, em.t_d, em.e, em.sa, em.sb, em.sc);
            }
        }
        public void JoinEmpTra_DAL()
        {
            var travEmp = from emp in empDataManager.lstEmployee
                          join
                        travel in ReqRaise on emp.Emp_id equals travel.Emp_id
                          select new
                          {
                              e = emp.Emp_id,
                              f = emp.Fn,
                              l = emp.Ln,
                              a = emp.emp_add,
                              d = emp.emp_dob,
                              c = emp.emp_con,

                              r = travel.Req_id,
                              fl = travel.From_Location,
                              tl = travel.To_Location,
                              t_d = travel.Req_Date,
                              sa = travel.Approved_status,
                              sc = travel.Cureent_status,
                              sb = travel.Booking_status

                          };

            foreach (var emps in travEmp)
            {
                Console.WriteLine("|{0,-6}|{1,-10}|{2,-8}|{3,-11}|{4,-20}|{5,-12}|{6,-6}|{7,-10}|{8,-10}|{9,-20}|{10,-10}|{11,-10}|{12,-10}", emps.e,
     emps.f, emps.l, emps.a, emps.d, emps.c, emps.r, emps.fl, emps.tl, emps.t_d, emps.sa, emps.sb, emps.sc);
            }
          
        }

            
        }
    }
