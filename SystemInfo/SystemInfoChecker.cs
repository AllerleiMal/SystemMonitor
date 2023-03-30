﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Documents;

namespace SystemInfo;

public class SystemInfoChecker
{
    private PerformanceCounter _cpuCounter;
    private PerformanceCounter _ramCounter;
    private string _cpuInfo;

    public SystemInfoChecker()
    {
        _cpuCounter = new PerformanceCounter("Processor Information", "% Processor Utility","_Total", true);
        _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        _cpuInfo = RetrieveCpuInfo();
    }

    private string RetrieveCpuInfo()
    {
        var cpu =
            new ManagementObjectSearcher( "select * from Win32_Processor" )
                .Get()
                .Cast<ManagementObject>()
                .First();
        
        var name = (string)cpu["Name"];
        var cores = (uint)cpu["NumberOfCores"];
        var threads = (uint)cpu["NumberOfLogicalProcessors"];
        
        name =  name
                .Replace( "(TM)", "™" )
                .Replace( "(tm)", "™" )
                .Replace( "(R)", "®" )
                .Replace( "(r)", "®" )
                .Replace( "(C)", "©" )
                .Replace( "(c)", "©" )
                .Replace( "    ", " " )
                .Replace( "  ", " " );
        return $"{name}\nCores: {cores} Threads: {threads}";
    }

    public float GetCpuUsage()
    {
        return _cpuCounter.NextValue();
    }

    public string GetCpuInfo()
    {
        return _cpuInfo;
    }

    public float GetRamUsage()
    {
        return _ramCounter.NextValue();
    }

    public List<DriveData> GetDrivesInfo()
    {
        const long bytesInGigabytes = 1073741824;
        List<DriveData> result = new List<DriveData>();
        
        DriveInfo[] allDrives = DriveInfo.GetDrives();

        foreach (DriveInfo d in allDrives)
        {
            DriveData drive = new DriveData();
            if (d.IsReady)
            {
                drive = new DriveData(d.Name, d.DriveType.ToString(), d.DriveFormat,
                    (float)d.TotalFreeSpace / bytesInGigabytes, (float)d.TotalSize / bytesInGigabytes);
            }
            else
            {
                drive.Name = d.Name;
                drive.DriveType = d.DriveType.ToString();
            }
            result.Add(drive);
        }

        return result;
    }
}