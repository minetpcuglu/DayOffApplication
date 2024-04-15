using DayOffApplication.Core.Entities.Base.Concrete;
using DayOffApplication.Core.Entities.LeaveRequests;
using DayOffApplication.Core.Entities.User.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Core.Entities.Notifications
{
	/// <summary>
	/// Bildirimler
	/// </summary>
	public class Notification:BaseEntity
	{
        public string Message { get; set; }
        public Employee Employee { get; set; }
		public Guid? UserId { get; set; }

		public CumulativeLeaveRequest CumulativeLeaveRequest { get; set; }
		public Guid? CumulativeLeaveRequestId { get; set; }
	}
}
