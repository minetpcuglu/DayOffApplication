using Ardalis.Specification;
using AutoMapper;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Entities.User.Managers;
using DayOffApplication.Core.Specifications.User.Employees;
using DayOffApplication.Core.Specifications.User.Managers;
using DayOffApplication.Web.Models.DataTransferObjects;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DayOffApplication.Web.Controllers
{
	public class EmployeeController : Controller
	{

		private readonly IMapper _mapper;
		private readonly IRepositoryBase<Employee> _employeeRepository;


		public EmployeeController(IRepositoryBase<Employee> employeeRepository, IMapper mapper)
		{
			_employeeRepository = employeeRepository;
		
			_mapper = mapper;
		}



		/// <summary>
		/// Çalışanlar Ekranı
		/// </summary>
		/// <returns></returns>

		public ActionResult Index()
		{
			return View();
		}



		/// <summary>
		/// Çalışanlar Listesi
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<object> GetList(DataSourceLoadOptions loadOptions)
		{
            var specification = new EmployeeSpecification(true);
            var res = await _employeeRepository.ListAsync(specification);
            _mapper.Map<List<EmployeeDTO>>(res);
            return DataSourceLoader.Load(res, loadOptions);
        }




        /// <summary>
        /// Personel Silme Active Bool=False and Silinme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
       
        [HttpPost]
        public async Task<IActionResult> Delete(Guid Key)
        {
            var delete = await _employeeRepository.GetByIdAsync(Key);
            delete.Active = false;
            delete.DeletionTime = DateTime.Now;
            await _employeeRepository.DeleteAsync(delete);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Personllerin Güncelleme Güncelleme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
      
        [HttpPost]
        public async Task<IActionResult> Edit(Guid key, string values)
        {
            var update =  await _employeeRepository.GetByIdAsync(key);
            update.ModificationTime = DateTime.Now;
            JsonConvert.PopulateObject(values, update);
           await _employeeRepository.UpdateAsync(update);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Personel Ekleme  Aktif Bool=True and Eklenme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
      
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newEmployee = new Employee();
            JsonConvert.PopulateObject(values, newEmployee);
            _employeeRepository.AddAsync(newEmployee);

            return RedirectToAction("Index");
        }

    }
}
