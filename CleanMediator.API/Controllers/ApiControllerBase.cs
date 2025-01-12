using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : Controller
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
