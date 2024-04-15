using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Core.Entities.Base.Abstract
{
	public interface IBaseEntity
	{
		
		public Guid Id { get; set; } 
		public bool Active { get; set; } 

		public DateTime CreationTime { get; set; } 
		public DateTime? ModificationTime { get; set; }
		public DateTime? DeletionTime { get; set; }
		public string CreatedByEmail { get; set; }
		public string ModificationByEmail { get; set; }
		public string DeletedByEmail { get; set; }

	}
}
