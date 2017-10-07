using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AccountantMVVM.View.PopUp;
using DALayer.Model;

namespace AccountantMVVM.Helpers
{
    public class ResponseHelper
    {
        public User User { get; set; }
        public List<string> Info { get; set; }
        public List<string> Error { get; set; }

        public ResponseHelper()
        {
            Info = new List<string>();
            Error = new List<string>();
        }   

        public void HandleResponse()
        {
            MessageWindow messageWindow = new MessageWindow();
            if (Error.Count > 0)
            {
                messageWindow.StatusText.Text = string.Join("\n", Error);
                messageWindow.StatusIcon.Source = ResourceHelper.LoadIcon("danger.png");
                messageWindow.ShowDialog();
                return;
            }
            messageWindow.StatusText.Text = string.Join("\n", Info);
            messageWindow.StatusIcon.Source = ResourceHelper.LoadIcon("kuba-icon-ok.png");
            messageWindow.ShowDialog();
        }
    }
}
