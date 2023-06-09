﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SystemInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SystemInfoChecker _systemInfoChecker;
        private OsInfo _osInfo;
        private FirewallInfo _firewall;
        public MainWindow()
        {
            InitializeComponent();
            _systemInfoChecker = new SystemInfoChecker();
            _osInfo = new OsInfo();
            InitializeFirewallData();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateSystemData;
            timer.Start();
            CpuInfo.Text = _systemInfoChecker.GetCpuInfo();
            DriveData.ItemsSource = _systemInfoChecker.GetDrivesInfo();
            AntivirusDataGrid.ItemsSource = _systemInfoChecker.GetSystemAntivirus();
            OsUpdatesDataGrid.ItemsSource = _osInfo.Updates;
            OsVersionDesc.Text = _osInfo.ToString();
        }

        private void InitializeFirewallData()
        {
            _firewall = new FirewallInfo();
            FirewallDesc.Text = $"Profile type: {_firewall.ProfileType}\nActive: {_firewall.IsEnabled}";
            FirewallPortsDataGrid.ItemsSource = _firewall.Ports;
            FirewallAppsDataGrid.ItemsSource = _firewall.Apps;
        }

        private void UpdateSystemData(object? sender, EventArgs e)
        {
            var cpuData = _systemInfoChecker.GetCpuUsage();
            CpuUsagePercentage.Text = cpuData.ToString("0.00") + "%";
            CpuUsage.Value = cpuData;
            RamUsage.Value = (1 - _systemInfoChecker.GetRamUsage() / _systemInfoChecker.GetTotalRam()) * 100;
            RamUsagePercentage.Text = RamUsage.Value.ToString("0.00") + "%";
            RamInfo.Text = $"Total: {_systemInfoChecker.GetTotalRam()} MB\nAvailable: {_systemInfoChecker.GetRamUsage()} MB";
        }

        private void RefreshDrivesButtonOnClick(object sender, RoutedEventArgs e)
        {
            DriveData.ItemsSource = _systemInfoChecker.GetDrivesInfo();
        }

        private void RefreshAntivirusButtonOnClick(object sender, RoutedEventArgs e)
        {
            AntivirusDataGrid.ItemsSource = _systemInfoChecker.GetSystemAntivirus();
        }

        private void RefreshUpdatesButtonOnClick(object sender, RoutedEventArgs e)
        {
            _osInfo = new OsInfo();
            OsUpdatesDataGrid.ItemsSource = _osInfo.Updates;
            OsVersionDesc.Text = _osInfo.ToString();
        }

        private void RefreshFirewallButtonOnClick(object sender, RoutedEventArgs e)
        {
            InitializeFirewallData();
        }
    }
}