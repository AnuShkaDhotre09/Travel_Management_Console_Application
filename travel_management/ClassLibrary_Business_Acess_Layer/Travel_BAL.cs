using ClassLibrary_DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using travel_management;

namespace ClassLibrary_Business_Acess_Layer
{

   
    public class Travel_BAL : BReqManager
         
    {
        private readonly TravelDataManager _TrvData = new TravelDataManager();
        

        public int ApprovedRequest_BAL(int travel_id, ApprovedStatus appstatus)
        {
           int App =_TrvData.ApprovedRequest_DAL(travel_id,appstatus);
            return App;
        }

        public int ConfirmRequest_BAL(int travel_id, BookingStatus bookstatus)
        {
            int Conf=_TrvData.ConfirmRequest_DAL(travel_id,bookstatus);
            return Conf;
        }

       

        public int DeleteRequest_BAL(int r_id)
        {
            _TrvData.DeleteRequest_DAL(r_id);
            return 1;
        }

      
        public Travel GetTravelById_BAL(int id)
        {
            Travel t1 = _TrvData.GetTravelById_DAL(id);
            return t1;
        }

        public int RaiseRequest_BAL(int r_id, string lf, string lt, DateTime r_dt, int e_id)
        {
            _TrvData.RaiseRequest_DAL(r_id, lf, lt, r_dt, e_id);
            return 1;
        }

        public void ViewTravelRequest_BAL()
        {
            _TrvData.ViewTravelRequest_DAL();
        }

       public void EditRequest_BAL(Travel Trv_to_change)
        {
            _TrvData.EditRequest_DAL(Trv_to_change);
        }

        public void JoinEmpTra_BAL()
        {
            _TrvData.JoinEmpTra_DAL();
        }

     

        public void bookingView_BAL()
        {
            _TrvData.bookingView_DAL();
        }

        public void approveView_BAL()
        {

            _TrvData.approveView_DAL();
        }

        public void Not_bookingView_BAL()
        {
            _TrvData.Not_bookingView_DAL();
        }

        public void NotApproveView_BAL()
        {

            _TrvData.Not_bookingView_DAL();
        }
    }
}
