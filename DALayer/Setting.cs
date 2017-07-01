using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Serialization.Configuration;

namespace DALayer
{
    public class Setting
    {
        public static readonly string RootPath = AppDomain.CurrentDomain.BaseDirectory;

        public static string DataFolderPath = Path.Combine(RootPath, @"Data");
    }
}
