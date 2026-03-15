using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwesp.Maui.Android.Models.Exceptions
{
    public class IllegalContentException : Exception
    {
        public IllegalContentException(string message) :base(message) { }
        public static Exception ThrowTextInputLayoutIllegalContent() => new IllegalContentException("TextInputLayout content must be a subclass of EditText.");
    }
}
