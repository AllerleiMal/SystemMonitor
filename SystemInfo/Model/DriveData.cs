namespace SystemInfo.Model;

public class DriveData
{
    public string Name { get; set; }
    public string DriveType { get; set; }
    public string FileSystem { get; set; }
    public float AvailableSpaceGb { get; set; }
    public float TotalDriveSizeGb { get; set; }
    public string AvailableSizePercentage { get; set; }

    public DriveData()
    {
            
    }
        
    public DriveData(string name, string driveType, string fileSystem, float availableSpace, float totalDriveSize)
    {
        Name = name;
        DriveType = driveType;
        FileSystem = fileSystem;
        AvailableSpaceGb = availableSpace;
        TotalDriveSizeGb = totalDriveSize;
        AvailableSizePercentage = (AvailableSpaceGb / TotalDriveSizeGb).ToString("P");
    }
}