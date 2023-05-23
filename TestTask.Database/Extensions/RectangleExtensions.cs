using TestTask.Domain;
using TestTask.Model;

namespace TestTask.Database.Extensions;
public static class RectangleExtensions {
    public static IEnumerable<Rectangle> ContainsPoint(this IEnumerable<Rectangle> rectangles, PointModel p) =>
        rectangles.Where(r =>
            r.X1 <= p.X && r.Y1 <= p.Y &&
            r.X2 >= p.X && r.Y2 >= p.Y
        );

    public static RectangleModel MapToModel(this Rectangle rectangle) =>
        new RectangleModel(
            new PointModel(rectangle.X1, rectangle.Y1),
            new PointModel(rectangle.X2, rectangle.Y2)
        );

    public static IEnumerable<RectangleModel> MapToModel(this IEnumerable<Rectangle> rectangles) =>
        rectangles.Select(map => map.MapToModel());
}
