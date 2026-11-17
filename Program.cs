using Lab_12;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("\n=== Лабораторна робота №12 (варіант 8, структурні шаблони) ===");
    Console.WriteLine("1 - Flyweight: авто на мапі міста");
    Console.WriteLine("2 - Composite: зони міста і тарифікація");
    Console.WriteLine("3 - Bridge: звіти для різних отримувачів");
    Console.WriteLine("0 - Вихід");
    Console.Write("Ваш вибір: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1": DemoRunner.RunFlyweight(); break;
        case "2": DemoRunner.RunComposite(); break;
        case "3": DemoRunner.RunBridge(); break;
        case "0": return;
        default: Console.WriteLine("Невірний вибір"); break;
    }
}