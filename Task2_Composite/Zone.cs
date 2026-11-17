namespace Lab_12;

// Composite: місто, район, квартал, бізнес-центр - усе це Zone з іншою міткою Kind
public class Zone : IZoneComponent
{
    private readonly List<IZoneComponent> _children = new();

    public string Name { get; }
    public string Kind { get; }
    public IReadOnlyList<IZoneComponent> Children => _children;

    public Zone(string name, string kind)
    {
        Name = name;
        Kind = kind;
    }

    public Zone Add(IZoneComponent child)
    {
        _children.Add(child ?? throw new ArgumentNullException(nameof(child)));
        return this;
    }

    public int GetCarCount() => _children.Sum(c => c.GetCarCount());
    public decimal GetRevenue() => _children.Sum(c => c.GetRevenue());
}