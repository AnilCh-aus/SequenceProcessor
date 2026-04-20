using SequenceProcessor.Core;

var finder = new IncreasingSequenceFinder();

try
{
    string input = args.Length > 0
        ? string.Join(' ', args)
        : await Console.In.ReadToEndAsync();

    string result = finder.FindLongestIncreasingSequence(input);
    Console.WriteLine(result);
    return 0;
}
catch (Exception exception) when (
    exception is ArgumentException or
    ArgumentNullException or
    FormatException)
{
    Console.Error.WriteLine(exception.Message);
    return 1;
}
