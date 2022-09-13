namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void given_input_of_1920x1080_returns_1920_1080() {
        //arrange
        var resolution = "1920x1080";
        IEnumerable<(int width, int height)> list;
        var res1 = new List<Tuple<int, int>>
        {
            Tuple.Create(1920, 1080)
        };
        //act
        list = RegExpr.Resolution(resolution);
        //assert
        list.Should().BeEquivalentTo<Tuple<int, int>>(res1);
    }

    [Fact]
    public void Splitline()
    {
        // Arrange
        List<string> list = new List<string> {"Hello world", "Lorem Ipsum", "Hi there Bob", "Bob is 9 years old"};

        // Act
        var result = RegExpr.SplitLine(list);

        // Assert
        var expected = new List<string> {"Hello", "world", "Lorem", "Ipsum", "Hi", "there", "Bob", "Bob", "is", "9", "years", "old"};
        result.Should().BeEquivalentTo(expected);
    }
}