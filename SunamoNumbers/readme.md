# SunamoNumbers

A platform-independent .NET library for numeric operations including statistical calculations, number normalization, interval parsing, and mathematical utilities.

## Features

- **Statistical Calculations**: Median, average, min/max computations with `NH` (Number Helper)
- **Interval Parsing**: Parse numeric intervals and single values from strings with `NumberService`
- **Number Normalization**: Convert signed numeric types to unsigned equivalents with `NormalizeNumbers`
- **Math Utilities**: Highest Common Factor (HCF) and Lowest Common Factor (LCF) with `MH`
- **Range Generation**: Generate sequential number lists and intervals with `LinearHelper`
- **Value Tracking**: Track minimum/maximum values with `LowHighHelper`

## Installation

```bash
dotnet add package SunamoNumbers
```

## Target Frameworks

- .NET 10.0
- .NET 9.0
- .NET 8.0

## Usage

### Statistical Calculations

```csharp
var list = new List<int> { 4, 4, 250, 500, 500 };
var median = NH.Median(list); // Returns 250

var doubles = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
var stats = NH.CalculateMedianAverage(doubles, shouldThrowOnSingleElement: false);
```

### Interval Parsing

```csharp
var service = new NumberService();
var interval = service.ParseInterval("120000-150000");
var singleValue = service.ParseInterval("150000");
```

### Number Normalization

```csharp
uint normalized = NormalizeNumbers.NormalizeInt(-100);
```

### Math Utilities

```csharp
int hcf = MH.HCF(12, 8);  // Returns 4
int lcf = MH.LCF(12, 8);  // Returns 2
```

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

## License

MIT
