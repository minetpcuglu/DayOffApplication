using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using Castle.Core.Resource;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Infrastructure.DataAccess.EntityFrameworkRepository;
using DayOffApplication.Web.Models.DataTransferObjects;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace DayOffApplication_Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly IMapper _mapper;
		private readonly IRepositoryBase<Employee> _employeeRepository;


		public HomeController(IRepositoryBase<Employee> employeeRepository, IMapper mapper)
		{
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}




		public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public async Task<object> Get(DataSourceLoadOptions loadOptions)
		{
			var value = await _employeeRepository.ListAsync();
			var customerDto = _mapper.Map<EmployeeDTO>(value);

			return DataSourceLoader.Load(value, loadOptions);

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View();
        }
    }
}
