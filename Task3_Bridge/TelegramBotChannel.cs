namespace Lab_12;

public class TelegramBotChannel : IDeliveryChannel
{
    public string Name => "Telegram-бот";

    public void Deliver(string recipient, string subject, string body) =>
        Log.Write("Telegram-бот", $"Повідомлення для {recipient}: «{subject}» - {body}");
}