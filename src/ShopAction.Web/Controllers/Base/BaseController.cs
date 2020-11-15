using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ShopAction.Web.Controllers.Base{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController: ControllerBase{
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}