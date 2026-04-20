using System;
using System.Collections.Generic;
using System.Globalization;

namespace SequenceProcessor.Core;

public sealed class IncreasingSequenceFinder
{
    public string FindLongestIncreasingSequence(string input)
    {
        IReadOnlyList<int> numbers = ParseNumbers(input);

        if (numbers.Count == 0)
        {
            throw new ArgumentException("Input must contain at least one integer.", nameof(input));
        }

        IReadOnlyList<int> run = FindLongestIncreasingRun(numbers);
        return string.Join(' ', run);
    }

    public IReadOnlyList<int> FindLongestIncreasingRun(IReadOnlyList<int> numbers)
    {
        ArgumentNullException.ThrowIfNull(numbers);

        if (numbers.Count == 0)
        {
            return Array.Empty<int>();
        }

        int bestStart = 0;
        int bestLength = 1;
        int currentStart = 0;
        int currentLength = 1;

        for (int index = 1; index < numbers.Count; index++)
        {
            if (numbers[index] > numbers[index - 1])
            {
                currentLength++;
            }
            else
            {
                currentStart = index;
                currentLength = 1;
            }

            if (currentLength > bestLength)
            {
                bestLength = currentLength;
                bestStart = currentStart;
            }
        }

        int[] result = new int[bestLength];
        for (int offset = 0; offset < bestLength; offset++)
        {
            result[offset] = numbers[bestStart + offset];
        }

        return result;
    }

    public IReadOnlyList<int> ParseNumbers(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (string.IsNullOrWhiteSpace(input))
        {
            return Array.Empty<int>();
        }

        string[] tokens = input.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
        int[] values = new int[tokens.Length];

        for (int index = 0; index < tokens.Length; index++)
        {
            if (!int.TryParse(tokens[index], NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
            {
                throw new FormatException($"Token '{tokens[index]}' is not a valid 32-bit integer.");
            }

            values[index] = value;
        }

        return values;
    }
}
