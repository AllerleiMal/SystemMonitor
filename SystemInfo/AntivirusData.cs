namespace SystemInfo;

public class AntivirusData
{
    public string Name { get; set; }
    public string InstanceGuid { get; set; }
    public string PathToSignedProductExe { get; set; }
    public string PathToSignedReportingExe { get; set; }
    public string Timestamp { get; set; }
    public bool UpToDate { get; set; }
    public bool Enabled { get; set; }

    public AntivirusData()
    {
        
    }

    public AntivirusData(string name, string instanceGuid, string pathToSignedProductExe, string pathToSignedReportingExe, string timestamp, bool upToDate, bool enabled)
    {
        Name = name;
        InstanceGuid = instanceGuid;
        PathToSignedProductExe = pathToSignedProductExe;
        PathToSignedReportingExe = pathToSignedReportingExe;
        Timestamp = timestamp;
        UpToDate = upToDate;
        Enabled = enabled;
    }
}