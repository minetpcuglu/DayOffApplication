using Ardalis.Specification;
using AutoMapper;
using DayOffApplication.Core.Entities.LeaveRequests;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Entities.User.Managers;
using DayOffApplication.Core.Specifications.LeaveRequests;
using DayOffApplication.Core.Specifications.User.Employees;
using DayOffApplication.Web.Models.DataTransferObjects;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DayOffApplication.Web.Controllers
{
    public class CumulativeLeaveRequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<CumulativeLeaveRequest> _cumulativeLeaveRequestRepository;


        public CumulativeLeaveRequestController(IRepositoryBase<CumulativeLeaveRequest> cumulativeLeaveRequestRepository, IMapper mapper)
        {
            _cumulativeLeaveRequestRepository = cumulativeLeaveRequestRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Kümülatif Talepler Ekranı
        /// </summary>
        /// <returns></returns>

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Kümülatif Taleplerin Listesi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetList(DataSourceLoadOptions loadOptions)
        {
            var specification = new CumulativeLeaveRequestSpecification(true);
            var res = await _cumulativeLeaveRequestRepository.ListAsync(specification);
            _mapper.Map<List<CumulativeLeaveRequestDTO>>(res);
            return DataSourceLoader.Load(res, loadOptions);
        }



        /// <summary>
        ///Kümülatif  İzin Talep Silme Active Bool=False and Silinme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Key)
        {
            var delete = await _cumulativeLeaveRequestRepository.GetByIdAsync(Key);
            delete.Active = false;
            delete.DeletionTime =DateTime.Now;
            await _cumulativeLeaveRequestRepository.DeleteAsync(delete);

            return RedirectToAction("Index");
        }

        /// <summary>
        ///Kümülatif İzin Talep Güncelleme Güncelleme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Edit(Guid key, string values)
        {
            var update = await _cumulativeLeaveRequestRepository.GetByIdAsync(key);
            update.ModificationTime=DateTime.Now;
            JsonConvert.PopulateObject(values, update);
            await _cumulativeLeaveRequestRepository.UpdateAsync(update);

            return RedirectToAction("Index");
        }


        /// <summary>
        ///Kümülatif İzin Talep Ekleme 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var insert = new CumulativeLeaveRequest();
            JsonConvert.PopulateObject(values, insert);
            await _cumulativeLeaveRequestRepository.AddAsync(insert);

            return RedirectToAction("Index");
        }

    }
}
