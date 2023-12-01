using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travel_management
{
    public enum ApprovedStatus {Pendding,Approved, Not_Approved }
    public enum BookingStatus {Null, Available, Not_Available }

    public enum CurrentStatus { Open, Close }
    public class Travel
    {
        public int Req_id {  get; set; }    
        public DateTime Req_Date { get; set; }
        public string From_Location{ get; set; }
        public string To_Location { get; set; }

        public int Emp_id { get; set; }
        public ApprovedStatus Approved_status { get; set; }
        public BookingStatus Booking_status { get; set; }

        public CurrentStatus Cureent_status { get; set; }
        public object e_id { get; set; }

        public override string ToString()
        {
            return String.Format("\t{0,-12}|{1,-12}|{2,-15}|{3,-13}|{4,-10}|{5,-17}|{6,-16}|{7,-10}",
               Req_id, From_Location, To_Location, Req_Date, Emp_id, Approved_status, Booking_status, Cureent_status);
               
        }

    }
}
