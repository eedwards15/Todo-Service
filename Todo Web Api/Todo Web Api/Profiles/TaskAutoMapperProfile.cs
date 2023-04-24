using AutoMapper;
using Todo_Web_Api.ViewModel;


namespace Profiles
{
    public class TaskAutoMapperProfile : Profile
    {
        public TaskAutoMapperProfile()
        {
            CreateMap<Task, TaskViewModel>()
                .ForMember(dest => dest.Subtasks, opt => opt.MapFrom(src => src))
                .ReverseMap();
        }
    }
}
