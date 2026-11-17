namespace Lab_12;

public class AppChannel : IDeliveryChannel
{
    public string Name => "застосунок";

    public void Deliver(string recipient, string subject, string body) =>
        Log.Write("Застосунок", $"Push для {recipient}: «{subject}» - {body}");
}

public class EmailChannel : IDeliveryChannel
{
    public string Name => "e-mail";

    public void Deliver(string recipient, string subject, string body) =>
        Log.Write("E-mail", $"Лист для {recipient}, тема «{subject}»: {body}");
}

public class AccountingSystemChannel : IDeliveryChannel
{
    public string Name => "система бухгалтерії";

    public void Deliver(string recipient, string subject, string body) =>
        Log.Write("Бухгалтерія", $"Запис у системі {recipient}, документ «{subject}»: {body}");
}