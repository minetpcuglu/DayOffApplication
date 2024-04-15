using DayOffApplication.Core.Entities.Base.Concrete;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Enums.LeaveRequests;
using DayOffApplication.Core.Enums.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Core.Entities.LeaveRequests
{
    /// <summary>
    /// İzin Talebi
    /// </summary>
	public class LeaveRequest:BaseEntity
	{
        public string FormNumber { get; set; }
        public string RequestNumber { get; set; }

        public LeaveType LeaveType { get; set; }    
        public string   Reason { get; set; }    
        public DateTime? StartDate { get; set; }    
        public DateTime? EndDate { get; set; }

		public Workflow WorkflowStatus { get; set; }
		public Employee Employee { get; set; }
		public Guid? AssignedUserId { get; set; }

        [NotMapped]
        public int? Hour { get; set; }

        [NotMapped]
        public int? Minute { get; set; }


        [NotMapped]
        public string TotalHours { get; set; }
    }
}
