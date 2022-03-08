using AutoMapper;
using Livia.Application.ViewModels;

namespace Livia.Application.MapperProfiles
{
    using Task = Domain.Models.Task.Task;
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskViewModel, Task>()
                .ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(tvm => tvm.Title))
                .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(tvm => tvm.Description)
                )
                .ForMember(
                dest => dest.Deadline,
                opt => opt.MapFrom(tvm => tvm.Deadline)
                );


        }
    }
}
