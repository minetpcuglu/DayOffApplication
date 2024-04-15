using Ardalis.Specification;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Entities.User.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DayOffApplication.Core.Specifications.User.Managers
{
    /// <summary>
    /// Specification Pattern : iş kurallarının zincirlenmesiyle iş kurallarının yeniden birleştirilebildiği özel bir yazılım tasarım kalıbıdır. 
    /// Spesificationların Amacı karmaşık koşulları ve sorguları nesnelere izole etmektir. Bu, kodun daha okunabilir, sürdürülebilir ve esnek olmasını sağlar. 
    /// </summary>
    public class ManagerSpecification : Specification<Manager>, ISingleResultSpecification<Manager>
	{
		/// <summary>
		/// Aktif olanları döner
		/// </summary>
		/// <param name="asNoTracking"></param>
		public ManagerSpecification( bool asNoTracking)
		{
			Query.Where(e => e.Active && e.DeletionTime == null)
				.OrderByDescending(e => e.CreationTime)
                .AsNoTracking(asNoTracking);
		}
	}
}
