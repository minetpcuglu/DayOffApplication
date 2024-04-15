using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using DayOffApplication.Core.Entities.Base.Abstract;
using DayOffApplication.Infrastructure.DataAccess.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Infrastructure.DataAccess.EntityFrameworkRepository
{
	public class EfRepository<T> : RepositoryBase<T>, IRepositoryBase<T> where T : class,IBaseEntity
	{
		public EfRepository(DayOffApplicationContext dbContext) : base(dbContext)
		{
		}
	}
}
