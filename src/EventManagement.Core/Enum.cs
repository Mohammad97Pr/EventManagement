using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement
{
    public class Enum
    {
        public enum UserType : byte
        {
            Admin = 1,
            BasicUser = 2,
        } 
        public enum TicketStatus : byte
        {
            Booked = 1,
            Canceled = 2,
        }
    }
}
