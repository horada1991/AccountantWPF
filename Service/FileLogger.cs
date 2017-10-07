using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class FileLogger
    {
        public string LogPath { get; set; } = AppDomain.CurrentDomain.RelativeSearchPath;

        private static FileLogger instance;

        private FileLogger() { }

        public static FileLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileLogger();
                }
                return instance;
            }
        }
    }
}
