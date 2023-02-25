using Microsoft.AspNetCore.Mvc;

namespace BSN.WebApi.Features
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
