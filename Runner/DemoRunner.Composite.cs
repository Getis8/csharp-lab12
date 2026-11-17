namespace Lab_12;

public static partial class DemoRunner
{
    public static void RunComposite()
    {
        Log.Section("Завдання 2. Composite: зони міста і тарифікація");

        var businessCenter = new Zone("БЦ Ренесанс", "Бізнес-центр")
            .Add(new ParkingLot("Паркінг А", 8, 15_200m))
            .Add(new ParkingLot("Паркінг Б", 5, 9_100m));

        var centerBlock = new Zone("Центр", "Квартал")
            .Add(new ParkingLot("Центральна площа", 12, 18_400m))
            .Add(businessCenter);                                    // БЦ всередині кварталу

        var mainBlock = new Zone("Проспектний", "Квартал")
            .Add(new ParkingLot("Вулиця Головна", 10, 14_500m));

        var shevchenkivskyi = new Zone("Шевченківський", "Район")
            .Add(centerBlock)
            .Add(mainBlock);

        var sadgoraBlock = new Zone("Садгора", "Квартал")
            .Add(new ParkingLot("Ринок", 9, 11_200m))
            .Add(new ParkingLot("Вокзал", 14, 21_000m));

        var sadhirskyi = new Zone("Садгірський", "Район")
            .Add(sadgoraBlock);

        var city = new Zone("Чернівці", "Місто")
            .Add(shevchenkivskyi)
            .Add(sadhirskyi);

        ZoneAnalytics.PrintTree(city);

        Log.Write("Аналітика", "Один і той самий виклик для різних вузлів:");
        ZoneAnalytics.Report(city);
        ZoneAnalytics.Report(shevchenkivskyi);
    }
}