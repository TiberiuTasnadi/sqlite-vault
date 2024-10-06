using SQLiteVault.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SQLiteVault.Services
{
    public class ConfigurationManager
    {
        private const string ConfigFileName = "fileconfig.json";

        private string ConfigPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SQLiteVault",
            ConfigFileName
        );

        public void SaveConfigurations(Configurations configurations)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));

            string jsonString = JsonSerializer.Serialize(configurations);
            File.WriteAllText(ConfigPath, jsonString);
        }

        public Configurations LoadConfigurations()
        {
            if (File.Exists(ConfigPath))
            {
                string jsonString = File.ReadAllText(ConfigPath);
                return JsonSerializer.Deserialize<Configurations>(jsonString) ?? new Configurations();
            }

            return new Configurations();
        }
    }
}
