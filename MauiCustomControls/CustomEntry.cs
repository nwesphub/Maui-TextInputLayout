using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCustomControls
{
    public class CustomEntry : Entry
    {
        public CustomEntry()
        {
            
            this.Focused += CustomEntry_Focused;
        }

        private void CustomEntry_Focused(object? sender, FocusEventArgs e)
        {

        }
    }
}
