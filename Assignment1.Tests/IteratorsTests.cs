namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void given_stream_of_a_stream_of_Ts_return_stream_of_ts() {
        //Arrange
        List<List<int>> streamStream = new List<List<int>>();
        List<int> list1 = new List<int>{1,2,3};
        List<int> list2 = new List<int>{4,5,6};
        List<int> list3 = new List<int>{7,8,9};
        //Act
        streamStream.Add(list1);
        streamStream.Add(list2);
        streamStream.Add(list3);
        var stream = Iterators.Flatten<int>(streamStream);
        List<int> numb = new List<int>{1,2,3,4,5,6,7,8,9};
        //Assert
        stream.Should().BeEquivalentTo<int>(numb);
        
    }
    
    [Fact]
    public void filter_even_test()
    {
        // Arrange
        List<int> list = new List<int> {1,2,3,4,5,6,7,8,9};

        // Act 
        var result = Iterators.Filter<int>(list, (int n) => n % 2 == 0);

        // Assert
        result.Should().BeEquivalentTo(new List<int> {2,4,6,8});
    }
}