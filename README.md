# Chocolatey Package Installer
![Chocolatey Package Installer](/snap.png)

This is a small desktop application for Windows written in WPF and NET 8.0. The program is an application installation manager using Chocolatey.  
The application is always run as an administrator.

## Assembly
Install .NET 8.0 SDK and complete the build.

## Usage

Before launching, you need to prepare a special one.An xml file with a list of programs to install.  
Visit https://community.chocolatey.org/packages and find the software you need.  
Save it.an xml file in the program directory according to this template:

``
<?xml version="1.0" encoding="UTF-8"?>
<applications>
    <application named "7zip">7zip</application>
    <application named "Paint.NET ">paint.net </application>
    <application named "Libre Office">libreoffice-fresh</application>
    <application named "Arduino IDE">arduino</application>
    <application named "VS Code">vscode</application>
    <application named "qBittorrent">qbittorrent</application>
    <application named "WinSCP">winscp</application>
</applications>
```

Launch ChocolateyPackageInstaller.exe .
If Chocolatey is not installed on your system, click Install Chocolatey.  
Now you can install your own programs.
