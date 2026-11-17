namespace Lab_12;

public interface IDeliveryChannel
{
    string Name { get; }
    void Deliver(string recipient, string subject, string body);
}