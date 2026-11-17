namespace Lab_12;

// Context: лише власні дані + посилання на спільну модель
public sealed class MapMarker
{
    public string Plate { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public DateTime Time { get; }
    public CarModel Model { get; }

    public MapMarker(string plate, double latitude, double longitude, DateTime time, CarModel model)
    {
        Plate = plate;
        Latitude = latitude;
        Longitude = longitude;
        Time = time;
        Model = model;
    }
}