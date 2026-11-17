namespace Lab_12;

// Component
public interface IZoneComponent
{
    string Name { get; }
    string Kind { get; }
    int GetCarCount();
    decimal GetRevenue();
    IReadOnlyList<IZoneComponent> Children { get; }   // у майданчика порожній
}