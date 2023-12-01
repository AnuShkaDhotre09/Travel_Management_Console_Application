using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_management;

namespace ClassLibrary_DataAcessLayer
{
    internal interface IReqDataManager
    {
        int RaiseRequest_DAL(int r_id, string lf, string lt, DateTime r_dt,int e_id);
        void EditRequest_DAL(Travel tr);

        int DeleteRequest_DAL(int r_id);

        int ApprovedRequest_DAL(int travel_id, ApprovedStatus appstatus);
        int ConfirmRequest_DAL(int travel_id, BookingStatus bookstatus);        //confirmed booking

       
        void ViewTravelRequest_DAL();
         Travel GetTravelById_DAL(int id);

        
        void bookingView_DAL();
        void approveView_DAL();
        void NotApproveView_DAL();
        void JoinEmpTra_DAL();
    }
}
