using Ardalis.Specification;
using DayOffApplication.Core.Entities.User.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Core.Specifications.User.Employees
{
    /// <summary>
    /// Specification Pattern : iş kurallarının zincirlenmesiyle iş kurallarının yeniden birleştirilebildiği özel bir yazılım tasarım kalıbıdır. 
    /// Spesificationların Amacı karmaşık koşulları ve sorguları nesnelere izole etmektir. Bu, kodun daha okunabilir, sürdürülebilir ve esnek olmasını sağlar. 
    /// </summary>
    public class EmployeeSpecification : Specification<Employee>, ISingleResultSpecification<Employee>
    {
        /// <summary>
        /// Aktif olanları döner
        /// </summary>
        /// <param name="asNoTracking"></param>
        public EmployeeSpecification( bool asNoTracking)
        {
            Query.Where(e => e.Active && e.DeletionTime == null)
                .Include(e => e.Manager)
                .OrderByDescending(e => e.CreationTime)
                .AsNoTracking(asNoTracking);
        }
    }
}
