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
using System.Collections.Generic;

namespace DayOffApplication.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<LeaveRequest> _leaveRequestRepository;
        private readonly IRepositoryBase<CumulativeLeaveRequest> _cumulativeLeaveRequestRepository;


        public RequestController(IRepositoryBase<LeaveRequest> leaveRequestRepository, IRepositoryBase<CumulativeLeaveRequest> cumulativeLeaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _cumulativeLeaveRequestRepository=cumulativeLeaveRequestRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Talepler Ekranı
        /// </summary>
        /// <returns></returns>

        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Taleplerin Listesi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetList(DataSourceLoadOptions loadOptions)
        {
            var res = await _leaveRequestRepository.ListAsync();
            var list = new List<LeaveRequestDTO>();
            _mapper.Map(res, list);
            return DataSourceLoader.Load(list, loadOptions);
        }




        /// <summary>
        /// İzin Talep Silme Active Bool=False and Silinme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Key)
        {
            var delete = await _leaveRequestRepository.GetByIdAsync(Key);
            await _leaveRequestRepository.DeleteAsync(delete);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// İzin Talep Güncelleme Güncelleme Zamanı = Datetime.Now 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Edit(Guid key, string values)
        {
            var update = await _leaveRequestRepository.GetByIdAsync(key);
            JsonConvert.PopulateObject(values, update);
            await _leaveRequestRepository.UpdateAsync(update);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// İzin Talep Ekleme 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {

            var newsDTO = new LeaveRequestDTO();
            var news = new LeaveRequest();

            JsonConvert.PopulateObject(values, newsDTO);
            var leaveRequest =    _mapper.Map( newsDTO, news);
            var succes=  await  _leaveRequestRepository.AddAsync(leaveRequest);
            if (succes.Id != null)
            {
                var cumulativeLeaveRequest = _mapper.Map<LeaveRequest, CumulativeLeaveRequest>(leaveRequest);
                JsonConvert.PopulateObject(values, news);
                await _cumulativeLeaveRequestRepository.AddAsync(cumulativeLeaveRequest);

            }
            return RedirectToAction("Index");
        }

    }
}
