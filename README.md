# SequenceProcessor

This repository contains my solution for the supplied coding exercise, implemented in C#/.NET.

## Important note about the official examples

Although the brief uses the term **subsequence**, the supplied expected outputs behave like the **longest strictly increasing contiguous run**.

Examples from the brief make this clear:

- `6 2 4 6 1 5 9 2` returns `2 4 6`, not `2 4 6 9`
- `6 2 4 3 1 5 9` returns `1 5 9`, not `2 4 5 9`

This solution follows the **official test cases**.

## Solution structure

- `src/SequenceProcessor.Core` - parsing and core algorithm
- `src/SequenceProcessor.Cli` - simple command-line entry point
- `tests/SequenceProcessor.Tests` - official and edge-case unit tests

## How to run

### Restore
```bash
dotnet restore SequenceProcessor.sln
```

### Build
```bash
dotnet build SequenceProcessor.sln --configuration Release --no-restore
```

### Run tests
```bash
dotnet test SequenceProcessor.sln --configuration Release --no-build
```

### Run the console app
```bash
dotnet run --project src/SequenceProcessor.Cli -- "6 1 5 9 2"
```

Expected output:
```text
1 5 9
```

You can also pipe input:
```bash
echo "6 2 4 3 1 5 9" | dotnet run --project src/SequenceProcessor.Cli
```

## Stretch goals included

- GitHub Actions CI
- Dockerfile for containerised execution
- EditorConfig-based linting/style consistency
- Code coverage collection and report generation in CI

## Docker

Build:
```bash
docker build -t sequence-processor .
```

Run:
```bash
docker run --rm sequence-processor "6 1 5 9 2"
```

Or with stdin:
```bash
echo "6 1 5 9 2" | docker run --rm -i sequence-processor
```
