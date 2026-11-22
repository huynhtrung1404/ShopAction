using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAction.Web.Commons
{
    [Route("api/[controller]")]
    public class BaseController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator _mediator = mediator;
    }
}
