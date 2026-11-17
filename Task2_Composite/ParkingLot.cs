namespace Lab_12;

// Leaf
public class ParkingLot : IZoneComponent
{
    private readonly int _cars;
    private readonly decimal _revenue;

    public string Name { get; }
    public string Kind => "Майданчик";
    public IReadOnlyList<IZoneComponent> Children => Array.Empty<IZoneComponent>();

    public ParkingLot(string name, int cars, decimal revenue)
    {
        Name = name;
        _cars = cars;
        _revenue = revenue;
    }

    public int GetCarCount() => _cars;
    public decimal GetRevenue() => _revenue;
}