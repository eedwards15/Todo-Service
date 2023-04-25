using AutoMapper;
using Todo_Web_Api.ViewModel;


namespace Profiles
{
    public class TaskAutoMapperProfile : Profile
    {
        public TaskAutoMapperProfile()
        {
            CreateMap<Database.tables.TodoTask, TaskViewModel>()
                .ReverseMap();
        }
    }
}
