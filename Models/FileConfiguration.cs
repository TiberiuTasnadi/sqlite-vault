using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteVault.Models
{
    public class FileConfiguration
    {
        public string SourcePath { get; set; } = string.Empty;
        public string DestinationPath { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{SourcePath} -> {DestinationPath}";
        }
    }
}
