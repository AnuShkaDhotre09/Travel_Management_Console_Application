using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_management;



namespace ClassLibrary_Business_Acess_Layer
{
    internal interface BReqManager
    {
        int RaiseRequest_BAL(int r_id, string lf, string lt, DateTime r_dt, int e_id);
        void EditRequest_BAL(Travel tr);

        int DeleteRequest_BAL(int r_id);

        int ApprovedRequest_BAL(int travel_id, ApprovedStatus appstatus);
        int ConfirmRequest_BAL(int travel_id, BookingStatus bookstatus);        //confirmed booking


       
        void ViewTravelRequest_BAL();

        Travel GetTravelById_BAL(int id);

        void JoinEmpTra_BAL();

        void bookingView_BAL();
        void approveView_BAL();
        void Not_bookingView_BAL();
        void NotApproveView_BAL();

    }
}
