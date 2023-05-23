using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using TestTask.App.Rectangle;

namespace TestTask.Controllers {

    [ApiController]
    [Route("api/rectangle")]
    public class RectangleController : BaseController {

        [HttpPost("findRectanglesByPoints")]
        public IActionResult FindRectanglesByPoints(FindRectanglesByPointsRequest request) => Mediator.HandleAsync<FindRectanglesByPointsRequest, FindRectanglesByPointsResponse>(request).ApiResult();
    }
}
