using Nwesp.Maui.Android.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android.Samples.Services
{
    public class BoxBackgroundService
    {
        private BoxBackgroundMode _boxBackgroundMode;

        public BoxBackgroundMode GetBackground()
        {
            return _boxBackgroundMode;
        }

        public void SetBackground(BoxBackgroundMode boxBackgroundMode)
        {
            _boxBackgroundMode = boxBackgroundMode;
        }
    }
}
