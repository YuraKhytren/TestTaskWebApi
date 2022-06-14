using AutoMapper;
using TestTask.Models;
using TestTask.ViewModel;

namespace TestTask.Mapping
{
    public class AccountToAccountViewModelProfile : Profile
    {
        public AccountToAccountViewModelProfile() 
        {
            CreateMap<Account, AccountViewModel>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                .ForMember("IncidentName", opt => opt.MapFrom(src => src.IncidentName));


            CreateMap<AccountViewModel, Account>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                .ForMember("IncidentName", opt => opt.MapFrom(src => src.IncidentName));
                
        }
    }
}
