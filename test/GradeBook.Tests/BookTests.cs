using Xunit;

namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void ShouldCalculateStatistics()
    {
        // arrange
        var book = new Book("");
        book.AddGrades(4.5, 6.8, 9.0);

        // act
        var result = book.GetStatistics();

        // assert
        Assert.Equal(result.Lower, 4.5, 1);
        Assert.Equal(result.Higher, 9.0, 1);
        Assert.Equal(result.Average, 6.8, 1);
        Assert.Equal(result.Letter, 'D');
    }
}