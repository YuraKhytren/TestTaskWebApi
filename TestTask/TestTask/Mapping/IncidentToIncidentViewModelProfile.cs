using AutoMapper;
using TestTask.Models;
using TestTask.ViewModel;

namespace TestTask.Mapping
{
    public class IncidentToIncidentViewModelProfile : Profile
    {
        public IncidentToIncidentViewModelProfile() 
        {
            CreateMap<Incident, IncidentViewModel>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                .ForMember("Description", opt => opt.MapFrom(src => src.Description));

            CreateMap<IncidentViewModel, Incident>()
              .ForMember("Name", opt => opt.MapFrom(src => src.Name))
              .ForMember("Description", opt => opt.MapFrom(src => src.Description));

        }
    }
}
