using G4L.UserManagement.BL.Entities;
using G4L.UserManagement.BL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4L.UserManagement.BL.Models
{
    public class Attendance_Register
    {
    
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public  DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
        public DateTime CheckInTime { get; set; } 
        public DateTime CheckOutTime { get; set; }
        public Leave Leave { get; set; }
        public Status LeaveStatus { get; set; }

    }
}
