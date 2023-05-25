using DotNetCore.Results;
using FluentAssertions;
using Moq;
using TestTask.App.Rectangle;
using TestTask.Database.Repositories;
using TestTask.Domain;
using TestTask.Model;

namespace TestTask.Tests;
public class FindRectanglesByPointsHandlerTests {
    private readonly Mock<IRectangleRepository> _rectangleRepositoryMock;
    private readonly Mock<IResultService> _resultServiceMock;
    private readonly FindRectanglesByPointsHandler _handler;

    public FindRectanglesByPointsHandlerTests() {
        _rectangleRepositoryMock = new Mock<IRectangleRepository>();
        _resultServiceMock = new Mock<IResultService>();
        _handler = new FindRectanglesByPointsHandler(_rectangleRepositoryMock.Object, _resultServiceMock.Object);

        SetupMocks();
    }

    private void SetupMocks() {
        _rectangleRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(GetTestRectangles());
        _resultServiceMock.Setup(s => s.Success(It.IsAny<FindRectanglesByPointsResponse>()))
            .Returns((FindRectanglesByPointsResponse value) => Result<FindRectanglesByPointsResponse>.Success(value));
    }

    private static Rectangle[] GetTestRectangles() {
        return new[] {
            new Rectangle {
                Id = 1,
                X1 = 1,
                Y1 = 1,
                X2 = 3,
                Y2 = 3
            },
            new Rectangle {
                Id = 2,
                X1 = 2,
                Y1 = 2,
                X2 = 4,
                Y2 = 4
            },
            new Rectangle {
                Id = 3,
                X1 = 3,
                Y1 = 3,
                X2 = 5,
                Y2 = 5
            },
        };
    }

    [Fact]
    public async Task HandleAsync_Returns_ExpectedResult_When_CalledWithValidRequest() {
        // Arrange
        var request = new FindRectanglesByPointsRequest(new[] {
            new PointModel(2, 2),
            new PointModel(4, 5),
        });
        var expectedResponse = new FindRectanglesByPointsResponse(new[] {
            new RectanglesByPoint(
                new PointModel(2, 2),
            new [] {
                new RectangleModel(
                    new PointModel(1,1),
                    new PointModel(3,3)
                ),
                new RectangleModel(
                    new PointModel(2,2),
                    new PointModel(4,4)
                ),
            }),
            new RectanglesByPoint(
                new PointModel(4, 5),
            new [] {
                new RectangleModel(
                    new PointModel(3,3),
                    new PointModel(5,5)
                )
            })
        });

        // Act
        var result = await _handler.HandleAsync(request);

        // Assert
        result.Value.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task HandleAsync_Returns_ExpectedResult_When_CalledWithEmptyRequest() {
        // Arrange
        var request = new FindRectanglesByPointsRequest(Array.Empty<PointModel>());

        var expectedResponse = new FindRectanglesByPointsResponse(
            Array.Empty<RectanglesByPoint>()
        );

        // Act
        var result = await _handler.HandleAsync(request);

        // Assert
        result.Value.Should().BeEquivalentTo(expectedResponse);
    }


    [Fact]
    public async Task HandleAsync_Returns_ValidResult_When_CalledWithPointOutsideAnyRectangles() {
        // Arrange
        var request = new FindRectanglesByPointsRequest(new[] {
            new PointModel(6, 6),
        });

        var expectedResponse = new FindRectanglesByPointsResponse(new[] {
            new RectanglesByPoint(
                new PointModel(6, 6),
            Array.Empty<RectangleModel>()
            )
        });

        // Act
        var result = await _handler.HandleAsync(request);

        // Assert
        result.Value.Should().BeEquivalentTo(expectedResponse);
    }
}
