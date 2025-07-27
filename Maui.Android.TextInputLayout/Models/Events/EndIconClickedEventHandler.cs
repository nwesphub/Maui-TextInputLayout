using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout.Models.Events
{
    public class EndIconClickedEventHandler
    {
        // Define the event
        public event EventHandler<EndIconClickedEventArgs>? EndIconClicked;

        // Method to trigger the event
        public void RaiseEvent(object? sender, string? text)
        {
            EndIconClicked?.Invoke(sender, new EndIconClickedEventArgs(text));
        }
    }
    public class EndIconClickedEventArgs : EventArgs
    {
        public string? Text { get; }

        public EndIconClickedEventArgs(string? text)
        {
            Text = text;
        }
    }
}
