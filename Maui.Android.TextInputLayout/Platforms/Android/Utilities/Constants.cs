using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AResource = Android.Resource.Attribute;
namespace Maui.Android.TextInputLayout.Platforms.Android.Utilities
{
    public static class Constants
    {
        /// <summary>
        /// 1. Disabled
        /// 2. Enabled and Focused
        /// 3. Normal
        /// </summary>
        /// <returns></returns>
        public static int[][] GetCommonStates()
        {
            return
            [
                [-AResource.StateEnabled],                        // Disabled
                [AResource.StateEnabled, AResource.StateFocused], // Enabled & Focused
                [AResource.StateEnabled],                         // Normal
            ];
        }

        public static int Zero => (int)decimal.Zero;
    }
}
