namespace SystemInfo.Model;

public class FirewallPort
{
    public int Port { get; set; }
    public string Name { get; set; }
    public string IpVersion { get; set; }

    public FirewallPort()
    {
        
    }

    public FirewallPort(int port, string name, string ipVersion)
    {
        Port = port;
        Name = name;
        IpVersion = ipVersion;
    }
}