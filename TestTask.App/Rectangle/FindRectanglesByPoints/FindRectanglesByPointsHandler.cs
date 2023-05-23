using DotNetCore.Mediator;
using DotNetCore.Results;
using TestTask.Database.Extensions;
using TestTask.Database.Repositories;

namespace TestTask.App.Rectangle;

/// <summary>
/// Finding rectangles for each given point
/// </summary>
public sealed record FindRectanglesByPointsHandler : IHandler<FindRectanglesByPointsRequest, FindRectanglesByPointsResponse> {
    private readonly IRectangleRepository _rectangleRepository;
    private readonly IResultService _resultService;

    public FindRectanglesByPointsHandler
    (
        IRectangleRepository rectangleRepository,
        IResultService resultService
    ) {
        _rectangleRepository = rectangleRepository;
        _resultService = resultService;
    }

    public async Task<Result<FindRectanglesByPointsResponse>> HandleAsync(FindRectanglesByPointsRequest request) {
        var rectangles = await _rectangleRepository.GetAllAsync();

        var rectanglesByPoints = request.Points.Select(p => {
            var rectanglesByPoint = rectangles.ContainsPoint(p).MapToModel().ToArray();
            return new RectanglesByPoint(p, rectanglesByPoint);
        }).ToArray();

        return _resultService.Success(new FindRectanglesByPointsResponse(rectanglesByPoints));
    }
}
