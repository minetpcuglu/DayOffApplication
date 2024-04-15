using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Enums.LeaveRequests;
using DayOffApplication.Core.Enums.User;
using System.ComponentModel.DataAnnotations;

namespace DayOffApplication.Web.Models.DataTransferObjects
{
	public class LeaveRequestDTO:BaseDTO
	{
		public string FormNumber { get; set; }
		public string RequestNumber { get; set; }


        [Display(Name = "İzin Tipi")]
        public LeaveType LeaveType { get; set; }
		public string Reason { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

        [Display(Name = "Toplam Süre")]
        public string TotalHours
        {
            get
            {
                if (StartDate.HasValue && EndDate.HasValue)
                {
                    TimeSpan timeDifference = EndDate.Value - StartDate.Value;
                    int totalMinutes = (int)timeDifference.TotalMinutes;

                    int hours = totalMinutes / 60;
                    int minutes = totalMinutes % 60;

                    return $"{hours} saat {minutes} dakika";
                }
                else
                {
                    return "Start date or end date is missing.";
                }
            }
        }

        public int Hour { get; set; } = 0;

        public int Minute { get; set; } = 0;

        int _minute;
        public int totalMinute
        {
            get { return Hour * 60 + Minute; }
            set { _minute = (int)value; }
        }

        [Display(Name = "Talep Durum")]
        public Workflow WorkflowStatus { get; set; }
		public EmployeeDTO Employee { get; set; }
		public Guid? AssignedUserId { get; set; }


    }
}
