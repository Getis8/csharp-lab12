namespace Lab_12;

// Flyweight: незмінні дані моделі, спільні для всіх позначок
public sealed class CarModel
{
    public string Name { get; }
    public string Icon { get; }
    public string Specs { get; }
    public string Photo { get; }

    public CarModel(string name, string icon, string specs, string photo)
    {
        Name = name;
        Icon = icon;
        Specs = specs;
        Photo = photo;
    }
}