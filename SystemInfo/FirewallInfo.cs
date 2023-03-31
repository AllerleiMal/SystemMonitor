using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.Common;
using SystemInfo.Model;

namespace SystemInfo;

public class FirewallInfo
{
    public string ProfileType { get; set; }
    public bool IsEnabled { get; set; }
    public List<FirewallPort> Ports { get; set; }
    public List<FirewallApp> Apps { get; set; }
    
    public FirewallInfo()
    {
        Ports = new List<FirewallPort>();
        Apps = new List<FirewallApp>();
        Type netFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);
        INetFwMgr manager = (INetFwMgr)Activator.CreateInstance(netFwMgrType);
        ProfileType = manager.CurrentProfileType.ToString();
        IsEnabled = manager.LocalPolicy.CurrentProfile.FirewallEnabled;

        foreach (INetFwOpenPort port in manager.LocalPolicy.CurrentProfile.GloballyOpenPorts)
        {
            Ports.Add(new FirewallPort(port.Port, port.Name, port.IpVersion.ToString()));
        }

        foreach (INetFwAuthorizedApplication app in manager.LocalPolicy.CurrentProfile.AuthorizedApplications)
        {
            Apps.Add(new FirewallApp(app.Name, app.IpVersion.ToString()));
        }
    }
}