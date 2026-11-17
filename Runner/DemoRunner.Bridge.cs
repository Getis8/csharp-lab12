namespace Lab_12;

public static partial class DemoRunner
{
    public static void RunBridge()
    {
        Log.Section("Завдання 3. Bridge: звіти для різних отримувачів");

        // 1. Звіт про поїздку: застосунок, потім e-mail (той самий звіт, інший канал)
        var tripReport = new TripReport("Ткачук", new AppChannel(), "CE1234AA", 30, 90m);
        tripReport.Send();
        tripReport.Channel = new EmailChannel();
        tripReport.Send();

        // 2. Корпоративний звіт у бухгалтерію клієнта
        new CorporateMonthlyReport("ТОВ «Буковина»", new AccountingSystemChannel(),
            "листопад 2026", 42, 18_600m).Send();

        // 3. Новий канал (один новий клас TelegramBotChannel), інші класи не змінювались
        Log.Write("Система", "Підключено канал «Telegram-бот»");
        tripReport.Channel = new TelegramBotChannel();
        tripReport.Send();

        // Будь-який вид звіту з будь-яким каналом
        Log.Write("Система", "Перевірка: усі види звітів з усіма каналами");
        var channels = new IDeliveryChannel[]
        {
            new AppChannel(), new EmailChannel(), new AccountingSystemChannel(), new TelegramBotChannel()
        };
        var reports = new Report[]
        {
            new TripReport("Мельник", channels[0], "CE2345BB", 45, 135m),
            new VehicleUsageReport("Служба обслуговування", channels[0], "CE2345BB", 6, 212),
            new CorporateMonthlyReport("ТОВ «Прут»", channels[0], "листопад 2026", 17, 7_450m)
        };

        foreach (var report in reports)
            foreach (var channel in channels)
            {
                report.Channel = channel;
                report.Send();
            }
    }
}