using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AccountantMVVM.Helpers
{
    class ResourceHelper
    {
        public static ImageSource LoadIcon(string imageName)
        {
            BitmapImage statusIcon = new BitmapImage();
            statusIcon.BeginInit();
            statusIcon.UriSource = new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"Sources\Icons\{imageName}"));
            statusIcon.EndInit();
            return statusIcon;
        }
    }
}
