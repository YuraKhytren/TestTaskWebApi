using AutoMapper;
using TestTask.DTO;
using TestTask.Models;
using TestTask.ViewModel;

namespace TestTask.Mapping
{
    public class ContactToContactDTOProfile : Profile
    {
        public ContactToContactDTOProfile() 
        {
            CreateMap<Contact, ContactDTO>()
              .ForMember("Email", opt => opt.MapFrom(src => src.Email))
              .ForMember("FirstName", opt => opt.MapFrom(src => src.FirstName))
              .ForMember("LastName", opt => opt.MapFrom(src => src.LastName))
              .ForMember("AccountName", opt => opt.MapFrom(src => src.Account.Name))
              .ForMember("IncidentDescription", opt => opt.MapFrom(src => src.Account.Incident.Description));

            CreateMap<ContactDTO, Contact>()
              .ForMember("Email", opt => opt.MapFrom(src => src.Email))
              .ForMember("FirstName", opt => opt.MapFrom(src => src.FirstName))
              .ForMember("LastName", opt => opt.MapFrom(src => src.LastName));
            
        }
    }
}
