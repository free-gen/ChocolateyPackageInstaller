# Chocolatey Package Installer
![ChocolateyPackageInstaller](/snap.png)

Это небольшое десктопное приложение для Windows, написанное на WPF и NET 8.0. Программа представляет из себя менеджер установки приложений при помощи Chocolatey.  
Приложение всегда запускается от имени администратора.

## Сборка
Установите .NET 8.0 SDK и произведите сборку.

## Использование

Перед запуском нужно подготовить специальный .xml файл со список программ для установки.  
Посетите https://community.chocolatey.org/packages и найдите нужный вам софт.  
Сохраните .xml файл в директории программы по этому шаблону:

```
<?xml version="1.0" encoding="UTF-8"?>
<applications>
    <app name="7zip">7zip</app>
    <app name="Paint.NET">paint.net</app>
    <app name="Libre Office">libreoffice-fresh</app>
    <app name="Arduino IDE">arduino</app>
    <app name="VS Code">vscode</app>
    <app name="qBitTorrent">qbittorrent</app>
    <app name="WinSCP">winscp</app>
</applications>
```

Запустите ChocolateyPackageInstaller.exe.
Если Chocolatey не установлен в вашей системе, нажмите Chocolatey Install.  
Теперь вы можете устанавливать ваши программы. 
