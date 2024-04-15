using System.ComponentModel.DataAnnotations;

namespace DayOffApplication.Web.Models.DataTransferObjects
{
	public class BaseDTO
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public bool Active { get; set; } = true;

		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime CreationTime { get; set; } = DateTime.Now;
		public DateTime? ModificationTime { get; set; }
		public DateTime? DeletionTime { get; set; }


		[MaxLength(1000)]
		public string CreatedByEmail { get; set; }

		[MaxLength(500)]
		public string ModificationByEmail { get; set; }

		[MaxLength(500)]
		public string DeletedByEmail { get; set; }
	}
}
