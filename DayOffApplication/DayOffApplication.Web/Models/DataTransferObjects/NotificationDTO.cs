using DayOffApplication.Core.Entities.LeaveRequests;
using DayOffApplication.Core.Entities.User.Employees;

namespace DayOffApplication.Web.Models.DataTransferObjects
{
	public class NotificationDTO:BaseDTO
	{
		public string Message { get; set; }
		public Employee Employee { get; set; }
		public Guid? UserId { get; set; }

		public CumulativeLeaveRequest CumulativeLeaveRequest { get; set; }
		public Guid? CumulativeLeaveRequestId { get; set; }
	}
}
