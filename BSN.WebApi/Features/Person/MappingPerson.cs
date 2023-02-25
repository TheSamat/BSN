using AutoMapper;

namespace BSN.WebApi.Features.Person
{
    public class MappingPerson : Profile
    {
        public MappingPerson()
        {
            CreateMap<CreatePerson.CreatePersonCommand, Domain.Entity.Person>(MemberList.Source);
        }
    }
}
