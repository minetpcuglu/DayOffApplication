using DayOffApplication.Core.Entities.Base.Concrete;
using DayOffApplication.Core.Entities.User.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Core.Entities.User.Managers
{
    /// <summary>
    /// Yönetici 
    /// </summary>
	public class Manager:BaseEntity
	{
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
