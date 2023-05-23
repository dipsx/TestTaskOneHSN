using TestTask.Model;

namespace TestTask.App.Rectangle;

public sealed record FindRectanglesByPointsResponse(RectanglesByPoint[] RectanglesByPoints);
public sealed record RectanglesByPoint(PointModel point, RectangleModel[] rectangles);
