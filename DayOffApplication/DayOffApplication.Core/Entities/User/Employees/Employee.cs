using DayOffApplication.Core.Entities.Base.Concrete;
using DayOffApplication.Core.Entities.LeaveRequests;
using DayOffApplication.Core.Entities.Notifications;
using DayOffApplication.Core.Entities.User.Managers;
using DayOffApplication.Core.Enums.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Core.Entities.User.Employees
{
    /// <summary>
    /// Personel
    /// </summary>
	public class Employee:BaseEntity
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

		public UserType UserType { get; set; }
		public Manager? Manager { get; set; }
		public Guid? ManagerId { get; set; }

        public ICollection<LeaveRequest> LeaveRequest { get; set; }
        public ICollection<CumulativeLeaveRequest> CumulativeLeaveRequest { get; set; }
        public ICollection<Notification> Notification { get; set; }
    }
}
