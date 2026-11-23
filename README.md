# SunamoNumbers

## Short description

Knihovna číselných operací: statistické výpočty (medián, průměr), normalizace čísel, parsování intervalů a matematické pomůcky. Obsahuje Runner a testy.


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

## Projects

| Project | Description |
|---|---|
| SunamoNumbers | Main library with number utilities |
| SunamoNumbers.Tests | Unit tests using xUnit |
| RunnerNumbers | Console runner for manual test execution |

## License

MIT

<!-- sunamo:test-coverage:start -->
## Test coverage

| Metric | Value |
|---|---|
| Method | static |
| Test projects | 1 |
| Public types referenced by tests | 1/12 (8.3 %) |
| Public methods referenced by tests | 1/39 (2.6 %) |
| Line coverage | n/a |
| Branch coverage | n/a |
| Generated (UTC) | 2026-11-22 21:24 |

<!-- sunamo:test-coverage:data {"package":"SunamoNumbers","container":"pinp","testProjects":1,"publicTypes":12,"typesReferencedByTests":1,"publicMethods":39,"methodsReferencedByTests":1,"lineRate":null,"branchRate":null,"method":"static","generatedUtc":"2026-11-22 21:24"} -->
<!-- sunamo:test-coverage:end -->
