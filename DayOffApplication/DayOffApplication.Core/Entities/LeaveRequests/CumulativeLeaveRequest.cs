using DayOffApplication.Core.Entities.Base.Concrete;
using DayOffApplication.Core.Entities.Notifications;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Enums.LeaveRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Core.Entities.LeaveRequests
{
    /// <summary>
    /// Kümülatif İzin Talebi
    /// </summary>
	public class CumulativeLeaveRequest:BaseEntity
	{
        public LeaveType LeaveType  { get; set; }

        public Employee Employee { get; set; }
        public Guid? UserId { get; set; }

        public string? TotalHours { get; set; }
        public int? Years { get; set; }

        public ICollection<Notification> Notification { get; set; }
    }
}
