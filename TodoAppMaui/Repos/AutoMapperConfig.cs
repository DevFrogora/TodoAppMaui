using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Domainmodel;
using TodoAppMaui.model;

namespace TodoAppMaui.Repos
{
    public class AutoMapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<TblTodo, Todo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Datetime, opt => opt.MapFrom(src => src.dateTime))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.isCompleted));

                cfg.CreateMap<Todo, TblTodo>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.dateTime, opt => opt.MapFrom(src => src.Datetime))
                .ForMember(dest => dest.title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.isCompleted, opt => opt.MapFrom(src => src.IsCompleted));

                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
