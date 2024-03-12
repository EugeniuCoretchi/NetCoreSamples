using AutoMapper;
using AutoMapperSample.Converters;
using AutoMapperSample.Models;
using AutoMapperSample.ViewModel;

namespace AutoMapperSample.Profiles;

public class PersonMapperProfile : Profile
{
    public PersonMapperProfile()
    {
        CreateMap<Person, PersonViewModel>()
            .ForMember(x => x.Name, o => o.MapFrom(p => $"{p.FirstName} {p.LastName}"))
            .ForMember(x => x.BirthDay, o => o.ConvertUsing<DateTimeToDateOnlyConverter, DateTime>());
    }
}