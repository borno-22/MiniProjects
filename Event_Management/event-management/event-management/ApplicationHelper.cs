using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace event_management
{
    internal static class ApplicationHelper
    {
        public static string connectionPath = @"Data Source=DESKTOP-0E77KI6\SQLEXPRESS;Initial Catalog=EventDB;Integrated Security=True;Encrypt=False";
        public static string FullName = ""; //for greetings
        public static string UserType = ""; // for role based login
        public static string UserID = ""; //to get current user's id-- used in settings,ClientBooking
        public static string BookingID = ""; //to get the bookingid in ClientBilling
        public static string Amount = ""; //to get amount in ClientBilling
        public static string BookingStaus = ""; //for ClientBilling
    }
}
