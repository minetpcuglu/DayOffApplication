using DayOffApplication.Core.Entities.User.Managers;
using DayOffApplication.Core.Enums.User;
using System.ComponentModel.DataAnnotations;

namespace DayOffApplication.Web.Models.DataTransferObjects
{
	public class EmployeeDTO:BaseDTO
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; }

        [Display(Name = "Tip")]
        public UserType UserType { get; set; }
		public ManagerDTO Manager { get; set; }

		[Display(Name="Yönetici Bölümü")]
		public Guid? ManagerId { get; set; }

	}
}
