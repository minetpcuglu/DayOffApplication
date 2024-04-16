using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Ardalis.Specification;
using AutoMapper;
using Castle.Core.Resource;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Infrastructure.DataAccess.EntityFrameworkRepository;
using DayOffApplication.Web.Models.DataTransferObjects;
using DayOffApplication_Web.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DayOffApplication_Web.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

		private readonly IMapper _mapper;

		private readonly IRepositoryBase<Employee> _employeeRepository;

		[HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions) {
            var value =await _employeeRepository.ListAsync();
			var employeeDto = _mapper.Map<EmployeeDTO>(value);

			return DataSourceLoader.Load(value, loadOptions);
		
		}

    }
}