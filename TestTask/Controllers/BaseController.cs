using DotNetCore.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers {
    [ApiController]
    public abstract class BaseController : ControllerBase {
        protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    }

}
