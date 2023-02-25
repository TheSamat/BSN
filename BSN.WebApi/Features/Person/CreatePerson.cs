using AutoMapper;
using BSN.WebApi.Domain;
using BSN.WebApi.Domain.Entity;
using MediatR;
using System.Reflection.Metadata;
using static BSN.WebApi.Features.Person.CreatePerson;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BSN.WebApi.Features.Person
{
    public class CreatePerson
    {
        public class CreatePersonCommand : IRequest<Domain.Entity.Person>
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string? Bio { get; set; }
            public string? Image { get; set; }
            public string? Hash { get; set; }
        }

        public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Domain.Entity.Person>
        {
            private readonly IDbContext _context;
            private readonly IMapper _mapper;
            public CreatePersonHandler(IDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Domain.Entity.Person> Handle(
                CreatePersonCommand request, 
                CancellationToken cancellationToken = default)
            {
                var person = _mapper.Map<CreatePersonCommand, Domain.Entity.Person>(request);
                _context.Persons.Add(person);
                _context.SaveChanges();
                return person;
            }
        }
    }
}
