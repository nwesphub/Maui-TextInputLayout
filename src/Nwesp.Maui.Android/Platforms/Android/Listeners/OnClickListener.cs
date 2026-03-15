using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AView = Android.Views.View;

namespace Nwesp.Maui.Android.Platforms.Android.Listeners
{
    public class OnClickListener : Java.Lang.Object, AView.IOnClickListener
    {
        private readonly Action _action;
        public OnClickListener(Action action)
        {
            _action = action;
        }

        public void OnClick(AView? v)
        {
            _action?.Invoke();
        }
    }
}
