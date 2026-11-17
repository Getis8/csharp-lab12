🇬🇧 **English** | 🇺🇦 [Українська](README.uk.md)

# 🚗 Lab12: Structural Patterns in a Car-Sharing Service

A **C# / .NET** console project: three problem situations of "Miskavto" solved with **Flyweight**, **Composite** and **Bridge**. Events are logged as `[time] [source] event`.

| Task | Problem | Pattern | Solution |
|---|---|---|---|
| 1 | 100,000 map markers each copied the car model data | **Flyweight** | `CarModelFactory` shares one `CarModel` per model |
| 2 | Nested city zones, separate loops per level | **Composite** | `IZoneComponent`, `ParkingLot`, `Zone` |
| 3 | A class for every report x channel combination | **Bridge** | `Report` holds an `IDeliveryChannel` |

**Authors:** Katya, Stas. **Run:** `dotnet build`, `dotnet run`, choose `1`-`3`. Diagrams: `docs/diagrams/`. Peer review: `REVIEW.md`.