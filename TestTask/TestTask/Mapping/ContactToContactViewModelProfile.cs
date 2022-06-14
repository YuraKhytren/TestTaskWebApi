using AutoMapper;
using TestTask.Models;
using TestTask.ViewModel;

namespace TestTask.Mapping
{
    public class ContactToContactViewModelProfile : Profile
    {
        public ContactToContactViewModelProfile() 
        {
            CreateMap<Contact, ContactViewModel>()
               .ForMember("Email", opt => opt.MapFrom(src => src.Email))
               .ForMember("FirstName", opt => opt.MapFrom(src => src.FirstName))
               .ForMember("LastName", opt => opt.MapFrom(src => src.LastName));

            CreateMap<ContactViewModel, Contact>()
               .ForMember("Email", opt => opt.MapFrom(src => src.Email))
               .ForMember("FirstName", opt => opt.MapFrom(src => src.FirstName))
               .ForMember("LastName", opt => opt.MapFrom(src => src.LastName));

        }
    }
}
