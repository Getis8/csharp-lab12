namespace Lab_12;

// Flyweight Factory: тримає пул моделей, не створює дублікатів
public sealed class CarModelFactory
{
    private readonly Dictionary<string, CarModel> _models = new();

    // Імітація джерела даних про моделі
    private readonly Dictionary<string, (string Icon, string Specs, string Photo)> _catalog = new()
    {
        ["Renault Zoe"]    = ("zoe.svg",     "електро, 135 к.с., запас ходу 390 км", "photos/zoe.jpg"),
        ["Nissan Leaf"]    = ("leaf.svg",    "електро, 150 к.с., запас ходу 270 км", "photos/leaf.jpg"),
        ["Skoda Octavia"]  = ("octavia.svg", "бензин, 150 к.с., АКПП",               "photos/octavia.jpg"),
        ["Toyota Corolla"] = ("corolla.svg", "гібрид, 122 к.с., АКПП",               "photos/corolla.jpg"),
    };

    public int Count => _models.Count;

    public CarModel GetModel(string name)
    {
        if (_models.TryGetValue(name, out var existing))
            return existing;                       // вже була: новий об'єкт не створюється

        if (!_catalog.TryGetValue(name, out var data))
            throw new ArgumentException($"Невідома модель: {name}", nameof(name));

        var model = new CarModel(name, data.Icon, data.Specs, data.Photo);
        _models[name] = model;
        Log.Write("Фабрика моделей", $"Створено об'єкт моделі {name}");
        return model;
    }
}