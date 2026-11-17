namespace Lab_12;

// Abstraction: що містить звіт; як доставляється вирішує канал
public abstract class Report
{
    public IDeliveryChannel Channel { get; set; }     // можна змінити під час виконання
    public string Recipient { get; }

    protected Report(string recipient, IDeliveryChannel channel)
    {
        Recipient = recipient;
        Channel = channel ?? throw new ArgumentNullException(nameof(channel));
    }

    protected abstract string Title { get; }
    protected abstract string BuildBody();

    public void Send()
    {
        Log.Write("Звіт", $"Формуємо «{Title}», канал: {Channel.Name}");
        Channel.Deliver(Recipient, Title, BuildBody());
    }
}

// Звіт про поїздку для клієнта
public class TripReport : Report
{
    private readonly string _plate;
    private readonly int _minutes;
    private readonly decimal _cost;

    public TripReport(string client, IDeliveryChannel channel, string plate, int minutes, decimal cost)
        : base(client, channel)
    {
        _plate = plate;
        _minutes = minutes;
        _cost = cost;
    }

    protected override string Title => "Звіт про поїздку";
    protected override string BuildBody() => $"авто {_plate}, {_minutes} хв, до сплати {_cost:F2} грн";
}

// Звіт про використання авто для служби обслуговування
public class VehicleUsageReport : Report
{
    private readonly string _plate;
    private readonly int _trips;
    private readonly int _kilometers;

    public VehicleUsageReport(string recipient, IDeliveryChannel channel, string plate, int trips, int kilometers)
        : base(recipient, channel)
    {
        _plate = plate;
        _trips = trips;
        _kilometers = kilometers;
    }

    protected override string Title => "Звіт про використання авто";
    protected override string BuildBody() => $"авто {_plate}: поїздок {_trips}, пробіг {_kilometers} км";
}

// Щомісячний звіт для корпоративного клієнта
public class CorporateMonthlyReport : Report
{
    private readonly string _month;
    private readonly int _trips;
    private readonly decimal _total;

    public CorporateMonthlyReport(string company, IDeliveryChannel channel, string month, int trips, decimal total)
        : base(company, channel)
    {
        _month = month;
        _trips = trips;
        _total = total;
    }

    protected override string Title => $"Щомісячний звіт, {_month}";
    protected override string BuildBody() => $"поїздок {_trips}, разом {_total:F2} грн";
}