using SequenceProcessor.Core;
using Xunit;

namespace SequenceProcessor.Tests;

public sealed class IncreasingSequenceFinderTests
{
    private readonly IncreasingSequenceFinder _finder = new();

    [Fact]
    public void FindLongestIncreasingSequence_WhenInputIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _finder.FindLongestIncreasingSequence(null!));
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenInputIsEmpty_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _finder.FindLongestIncreasingSequence(string.Empty));
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenInputContainsOnlyWhitespace_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _finder.FindLongestIncreasingSequence("   \t  "));
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenInputContainsInvalidToken_ThrowsFormatException()
    {
        Assert.Throws<FormatException>(() => _finder.FindLongestIncreasingSequence("1 two 3"));
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenSingleValue_ReturnsThatValue()
    {
        string actual = _finder.FindLongestIncreasingSequence("42");
        Assert.Equal("42", actual);
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenAllValuesDecrease_ReturnsEarliestSingleValue()
    {
        string actual = _finder.FindLongestIncreasingSequence("9 8 7 6 5");
        Assert.Equal("9", actual);
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenRunsTie_ReturnsEarliestRun()
    {
        string actual = _finder.FindLongestIncreasingSequence("1 2 0 3 4");
        Assert.Equal("1 2", actual);
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenValuesRepeat_BreaksTheRun()
    {
        string actual = _finder.FindLongestIncreasingSequence("5 5 6 6 7");
        Assert.Equal("5 6", actual);
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenInputIncludesNegativeValues_ReturnsLongestRun()
    {
        string actual = _finder.FindLongestIncreasingSequence("-5 -3 -1 -2 0 1");
        Assert.Equal("-5 -3 -1", actual);
    }

    [Fact]
    public void FindLongestIncreasingSequence_WhenWhitespaceVaries_ParsesSuccessfully()
    {
        string actual = _finder.FindLongestIncreasingSequence("10\n11\t12 5");
        Assert.Equal("10 11 12", actual);
    }

    [Fact]
    public void FindLongestIncreasingSequence_FollowsOfficialBehaviourRatherThanClassicLis()
    {
        string actual = _finder.FindLongestIncreasingSequence("1 3 2 4 5");
        Assert.Equal("2 4 5", actual);
    }

    [Fact]
    public void FindLongestIncreasingRun_WhenSequenceIsEmpty_ReturnsEmptyArray()
    {
        IReadOnlyList<int> actual = _finder.FindLongestIncreasingRun(Array.Empty<int>());
        Assert.Empty(actual);
    }
}
