namespace SystemInfo.Model;

public class FirewallApp
{
    public string Name { get; set; }
    public string IpVersion { get; set; }

    public FirewallApp()
    {
        
    }

    public FirewallApp(string name, string ipVersion)
    {
        Name = name;
        IpVersion = ipVersion;
    }
}