using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout.Models.Events
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
