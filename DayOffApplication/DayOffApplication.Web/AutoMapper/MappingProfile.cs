using AutoMapper;
using DayOffApplication.Core.Entities.LeaveRequests;
using DayOffApplication.Core.Entities.Notifications;
using DayOffApplication.Core.Entities.User.Employees;
using DayOffApplication.Core.Entities.User.Managers;
using DayOffApplication.Web.Models.DataTransferObjects;

namespace DayOffApplication.Web.AutoMapper
{
	public class MappingProfile:Profile
	{
        /// <summary>
        /// AutoMapper: farklı veri nesnelerinin otomatik olarak eşleştirilerek dönüştürülmesini ve kopyalanmasını kolaylaştıran bir kütüphanedir.
        /// </summary>
        public MappingProfile()
        {
			CreateMap<Employee	,EmployeeDTO>().ReverseMap();

            CreateMap<LeaveRequest, CumulativeLeaveRequest>()
    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AssignedUserId)) //FOR MEMBER İLE: tablodaki prop baska bir tablodaki prop eşitleme
    .ForMember(dest => dest.TotalHours, opt => opt.MapFrom(src => src.TotalHours))
    .ForMember(dest => dest.Years, opt => opt.MapFrom(src => src.StartDate.Value.Year))
    .ReverseMap();


            CreateMap<List<Employee>, EmployeeDTO>().ReverseMap();
			CreateMap<Notification,NotificationDTO>().ReverseMap();
			CreateMap<Manager,ManagerDTO>().ReverseMap();
			CreateMap<List<Manager>,ManagerDTO>().ReverseMap();

			CreateMap<CumulativeLeaveRequest, CumulativeLeaveRequestDTO>().ReverseMap();
			CreateMap<List<CumulativeLeaveRequest>, CumulativeLeaveRequestDTO>().ReverseMap();

            CreateMap<List<LeaveRequest>, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest,LeaveRequestDTO>().ReverseMap();



		}
    }
}
