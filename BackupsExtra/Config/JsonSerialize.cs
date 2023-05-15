using System.Configuration;
using Backups.Extra.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Backups.Extra.Configuration;

public class JsonSerialize
{
    public string GetAlgorithm()
    {
        IConfigurationSection mainSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MainSettings");
        string temp = mainSettingsConfig.GetSection("Algorithm").Value!;
        return temp;
    }

    public string GetSearchingAlgorithm()
    {
        IConfigurationSection mainSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MainSettings");
        string temp = mainSettingsConfig.GetSection("SearchingAlgorithm").Value!;
        return temp;
    }

    public string GetLogging()
    {
        IConfigurationSection mainSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MainSettings");
        string temp = mainSettingsConfig.GetSection("Logging").Value!;
        return temp;
    }

    public string GetArchiver()
    {
        IConfigurationSection mainSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MainSettings");
        string temp = mainSettingsConfig.GetSection("Archiver").Value!;
        return temp;
    }

    public string GetRepositoryType()
    {
        IConfigurationSection mainSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Repository");
        string temp = mainSettingsConfig.GetSection("Type").Value!;
        return temp;
    }

    public string GetPath()
    {
        IConfigurationSection mainSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Repository");
        string temp = mainSettingsConfig.GetSection("Path").Value!;
        return temp;
    }

    public string GetRestorePoints()
    {
        IConfigurationSection mainSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Backup");
        string temp = mainSettingsConfig.GetSection("RestorePoints").Value!;
        return temp;
    }

    public string GetPointsLimit()
    {
        IConfigurationSection mainSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Backup");
        string temp = mainSettingsConfig.GetSection("PointsLimit").Value!;
        return temp;
    }
}
