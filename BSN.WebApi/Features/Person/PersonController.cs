using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BSN.WebApi.Features.Person
{
    public class PersonController : BaseController
    {
        private readonly IMediator _mediator;
        
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _mediator.Send(new GetPersonList.GetPersonListQuery());
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePerson.CreatePersonCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
    }
}
