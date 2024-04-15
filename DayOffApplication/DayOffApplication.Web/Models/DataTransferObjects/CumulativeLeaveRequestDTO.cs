using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Enums.LeaveRequests;

namespace DayOffApplication.Web.Models.DataTransferObjects
{
	public class CumulativeLeaveRequestDTO:BaseDTO
	{
		public LeaveType LeaveType { get; set; }

		public EmployeeDTO Employee { get; set; }
		public Guid? UserId { get; set; }

		public string? TotalHours { get; set; }
		public int? Years { get; set; }

	}
}
