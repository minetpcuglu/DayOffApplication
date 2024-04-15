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
    public class ManagerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Manager> _managerRepository;


        public ManagerController( IMapper mapper, IRepositoryBase<Manager> managerRepository)
        {
            _managerRepository = managerRepository;
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
        /// Yönetici Departman
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetList(DataSourceLoadOptions loadOptions)
        {
            var specification = new ManagerSpecification(true);
            var res = await _managerRepository.ListAsync(specification);
            _mapper.Map<List<ManagerDTO>>(res);
            return DataSourceLoader.Load(res, loadOptions);
        }




        /// <summary>
        /// Yönetici Departman Silme Active Bool=False and Silinme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Key)
        {
            var delete = await _managerRepository.GetByIdAsync(Key);
            delete.Active = false;
            delete.DeletionTime = DateTime.Now;
            await _managerRepository.DeleteAsync(delete);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Yönetici Departman Güncelleme Güncelleme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Edit(Guid key, string values)
        {
            var update = await _managerRepository.GetByIdAsync(key);
            update.ModificationTime = DateTime.Now;
            JsonConvert.PopulateObject(values, update);
            await _managerRepository.UpdateAsync(update);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Yönetici Departman Ekleme  Aktif Bool=True and Eklenme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newS = new Manager();
            JsonConvert.PopulateObject(values, newS);
            _managerRepository.AddAsync(newS);

            return RedirectToAction("Index");
        }
    }
}
