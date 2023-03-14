using Microsoft.Win32;
using Microsoft.Win32.Serialization;

namespace DBQueryConstructor;

[RegistrySerializable(RegistryHive.CurrentUser, @"SOFTWARE\DBQueryConstructor")]
internal class ConnectionSetting
{
    public string Server { get; set; }

    public string Database { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }
}