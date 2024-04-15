using Ardalis.Specification;
using DayOffApplication.Core.Entities.LeaveRequests;
using DayOffApplication.Core.Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DayOffApplication.Core.Specifications.LeaveRequests
{
    /// <summary>
	/// Specification Pattern : iş kurallarının zincirlenmesiyle iş kurallarının yeniden birleştirilebildiği özel bir yazılım tasarım kalıbıdır. 
    /// Spesificationların Amacı karmaşık koşulları ve sorguları nesnelere izole etmektir. Bu, kodun daha okunabilir, sürdürülebilir ve esnek olmasını sağlar. İ
    /// </summary>
    public class CumulativeLeaveRequestSpecification : Specification<CumulativeLeaveRequest>, ISingleResultSpecification<CumulativeLeaveRequest>
	{
		/// <summary>
		/// Aktif olanları döner
		/// </summary>
		/// <param name="asNoTracking"></param>
		public CumulativeLeaveRequestSpecification( bool asNoTracking)
		{
			Query.Where(e => e.Active && e.DeletionTime == null)
				.Include(e => e.Employee)
                .OrderByDescending(e => e.CreationTime)
				.AsNoTracking(asNoTracking);
		}
	}
}
