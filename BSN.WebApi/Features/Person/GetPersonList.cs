using BSN.WebApi.Domain;
using MediatR;
using static BSN.WebApi.Features.Person.GetPersonList;

namespace BSN.WebApi.Features.Person
{
    public class GetPersonList
    {
        public class GetPersonListQuery : IRequest<List<Domain.Entity.Person>>
        {}

        public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<Domain.Entity.Person>>
        {
            private readonly IDbContext _context;
            public GetPersonListHandler(IDbContext context)
            {
                _context = context;
            }

            public async Task<List<Domain.Entity.Person>> Handle(
                GetPersonListQuery request, 
                CancellationToken cancellationToken = default)
            {
                return _context.Persons.ToList();
            }
        }
    }
}
