using System.Windows.Controls;

namespace SystemInfo;

public class DriveData
{
    public string Name { get; set; }
    public string DriveType { get; set; }
    public string FileSystem { get; set; }
    public float AvailableSpaceGB { get; set; }
    public float TotalDriveSizeGB { get; set; }
    public string AvailableSizePercentage { get; set; }

    public DriveData()
    {
            
    }
        
    public DriveData(string name, string driveType, string fileSystem, float availableSpace, float totalDriveSize)
    {
        Name = name;
        DriveType = driveType;
        FileSystem = fileSystem;
        AvailableSpaceGB = availableSpace;
        TotalDriveSizeGB = totalDriveSize;
        AvailableSizePercentage = (AvailableSpaceGB / TotalDriveSizeGB).ToString("P");
    }
}