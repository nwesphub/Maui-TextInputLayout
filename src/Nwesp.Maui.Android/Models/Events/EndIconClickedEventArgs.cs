using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android.Models.Events
{
    public class EndIconClickedEventArgs : EventArgs
    {
        public string? Text { get; }

        public EndIconClickedEventArgs(string? text)
        {
            Text = text;
        }
    }
}
