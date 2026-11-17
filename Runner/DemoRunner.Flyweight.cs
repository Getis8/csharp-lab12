using System.Runtime.CompilerServices;

namespace Lab_12;

public static partial class DemoRunner
{
    public static void RunFlyweight()
    {
        Log.Section("Завдання 1. Flyweight: авто на мапі міста");

        const int markerCount = 100_000;
        string[] models = { "Renault Zoe", "Nissan Leaf", "Skoda Octavia", "Toyota Corolla" };
        string[] plates = Enumerable.Range(1, 20).Select(i => $"CE{1000 + i}AA").ToArray();

        var factory = new CarModelFactory();
        var random = new Random(42);
        var dayStart = new DateTime(2026, 12, 4, 0, 0, 0);
        var markers = new List<MapMarker>(markerCount);

        for (int i = 0; i < markerCount; i++)
        {
            int car = i % plates.Length;                       // 20 авто, по 5 на модель
            var model = factory.GetModel(models[car % models.Length]);
            markers.Add(new MapMarker(
                plates[car],
                48.25 + random.NextDouble() * 0.08,
                25.88 + random.NextDouble() * 0.10,
                dayStart.AddSeconds(i % 86_400),
                model));
        }

        Log.Write("Мапа", $"Позначок: {markers.Count}");
        Log.Write("Мапа", $"Об'єктів моделей: {factory.Count}");

        var first = markers[0];
        var second = markers.First(m => m.Model.Name == first.Model.Name && m.Plate != first.Plate);

        Log.Write("Позначка 1", $"{first.Plate}, {first.Model.Name}, {first.Latitude:F4}, {first.Longitude:F4}, {first.Time:HH:mm:ss}, id моделі {RuntimeHelpers.GetHashCode(first.Model)}");
        Log.Write("Позначка 2", $"{second.Plate}, {second.Model.Name}, {second.Latitude:F4}, {second.Longitude:F4}, {second.Time:HH:mm:ss}, id моделі {RuntimeHelpers.GetHashCode(second.Model)}");
        Log.Write("Перевірка", $"Той самий об'єкт моделі: {ReferenceEquals(first.Model, second.Model)}");

        var again = factory.GetModel(first.Model.Name);
        Log.Write("Перевірка", $"Повторний запит моделі нового об'єкта не створив: {ReferenceEquals(again, first.Model)}, моделей усе ще {factory.Count}");
    }
}