using System.Text.Json;
using Xunit;

namespace SequenceProcessor.Tests;

public static class OfficialTestCases
{
    public static TheoryData<string, string> Data
    {
        get
        {
            string dataFilePath = Path.Combine(AppContext.BaseDirectory, "TestData", "official-test-cases.json");
            string json = File.ReadAllText(dataFilePath);

            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };

            IReadOnlyList<OfficialTestCase> cases =
                JsonSerializer.Deserialize<List<OfficialTestCase>>(json, options)
                ?? throw new InvalidOperationException("Unable to deserialize official test case data.");

            TheoryData<string, string> theoryData = new();
            foreach (OfficialTestCase testCase in cases.OrderBy(testCase => testCase.Id))
            {
                theoryData.Add(testCase.Input, testCase.Expected);
            }

            return theoryData;
        }
    }
}
