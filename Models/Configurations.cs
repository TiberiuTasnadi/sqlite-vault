using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteVault.Models
{
    public class Configurations
    {
        public List<FileConfiguration> FileConfigurations { get; set; } = new List<FileConfiguration>();
    }
}
