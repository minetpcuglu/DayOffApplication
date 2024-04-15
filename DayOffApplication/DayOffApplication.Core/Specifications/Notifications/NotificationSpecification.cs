using Ardalis.Specification;
using DayOffApplication.Core.Entities.Notifications;
using DayOffApplication.Core.Entities.User.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DayOffApplication.Core.Specifications.Notifications
{
    /// <summary>
    /// Specification Pattern : iş kurallarının zincirlenmesiyle iş kurallarının yeniden birleştirilebildiği özel bir yazılım tasarım kalıbıdır. 
    /// Spesificationların Amacı karmaşık koşulları ve sorguları nesnelere izole etmektir. Bu, kodun daha okunabilir, sürdürülebilir ve esnek olmasını sağlar. 
    /// </summary>
    public class NotificationSpecification : Specification<Notification>, ISingleResultSpecification<Notification>
	{
		/// <summary>
		/// Aktif olanları döner
		/// </summary>
		/// <param name="asNoTracking"></param>
		public NotificationSpecification(Guid? id, bool asNoTracking)
		{
			Query.Where(e => e.Id == id && e.Active && e.DeletionTime == null)
				.Include(e => e.Employee)
                .OrderByDescending(e => e.CreationTime)
                .AsNoTracking(asNoTracking);
		}
	}
}
