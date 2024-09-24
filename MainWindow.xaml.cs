using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Windows.Navigation;

namespace ChocolateyPackageInstaller
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> applications = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
            LoadApplications();
            SetupUI();
        }

        private void LoadApplications()
        {
            XElement root = XElement.Load(GetXmlFilePath());
            foreach (var app in root.Elements("app"))
            {
                string name = app.Attribute("name").Value;
                string id = app.Value;
                applications[name] = id;
            }
        }

        private string GetXmlFilePath()
        {
            return "apps.xml";
        }

        private void SetupUI()
        {
            foreach (var app in applications)
            {
                CheckBox checkBox = new CheckBox { Content = app.Key, Tag = app.Value };
                CheckBoxPanel.Children.Add(checkBox);
            }
        }

        private void SetCheckBoxes(bool isChecked)
        {
            foreach (var item in CheckBoxPanel.Children)
            {
                if (item is CheckBox checkBox)
                {
                    checkBox.IsChecked = isChecked;
                }
            }
        }

        private void InstallChocolatey(object sender, RoutedEventArgs e)
        {
            string command = "@powershell -NoProfile -ExecutionPolicy unrestricted -Command \"iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))\" && SET PATH=%PATH%;%ALLUSERSPROFILE%\\chocolatey\\bin";
            Process.Start("cmd.exe", $"/C {command}");
        }

        private void UninstallChocolatey(object sender, RoutedEventArgs e)
        {
            string command = "rmdir /S /Q \"%ProgramData%\\chocolatey\" & rmdir /S /Q \"%ProgramData%\\ChocolateyHttpCache\"";
            Process.Start("cmd.exe", $"/C {command}");
        }

        private void RunCmd(object sender, RoutedEventArgs e)
        {
            List<string> selectedApps = new List<string>();
            foreach (var item in CheckBoxPanel.Children)
            {
                if (item is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    selectedApps.Add(checkBox.Tag.ToString());
                }
            }

            if (selectedApps.Count > 0)
            {
                string command = "choco install " + string.Join(" ", selectedApps) + " -y";
                Process.Start("cmd.exe", $"/C {command}");
            }
        }

        private void SelectAll(object sender, RoutedEventArgs e)
        {
            SetCheckBoxes(true);
        }

        private void DeselectAll(object sender, RoutedEventArgs e)
        {
            SetCheckBoxes(false);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
