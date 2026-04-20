using SequenceProcessor.Core;
using Xunit;

namespace SequenceProcessor.Tests;

public sealed class IncreasingSequenceFinderOfficialTests
{
    private readonly IncreasingSequenceFinder _finder = new();

    [Theory]
    [MemberData(nameof(OfficialTestCases.Data), MemberType = typeof(OfficialTestCases))]
    public void FindLongestIncreasingSequence_OfficialCases_ReturnsExpected(string input, string expected)
    {
        string actual = _finder.FindLongestIncreasingSequence(input);
        Assert.Equal(expected, actual);
    }
}
