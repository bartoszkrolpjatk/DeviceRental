namespace DeviceRental.Model;

public class Camera : Device
{
    private int Resolution { get; }
    private string VideoQuality { get; }
    
    public Camera(string name, int resolution, string videoQuality) : base(name)
    {
        Resolution = resolution;
        VideoQuality = videoQuality;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Camera [Resolution: {Resolution}, VideoQuality: {VideoQuality}]";
    }
}