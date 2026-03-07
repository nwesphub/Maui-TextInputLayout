using Android.Text;
using Android.Widget;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Android.TextInputLayout.Platforms.Android.Managers
{
    // Taken from Microsoft.Maui.Platform.EditTextExtensions
    public static class TextManager
    {
        internal static void UpdateTextFromPlatform(this EditText editText, InputView inputView)
        {
            (var oldText, var newText) = GetTexts(editText, inputView);

            if (oldText != newText)
            {
                // This update is happening while inputting text into the EditText, so we want to avoid 
                // resettting the cursor position and selection
                editText.SetTextKeepState(newText);
            }
        }
        static (string oldText, string newText) GetTexts(EditText editText, InputView inputView)
        {
            var oldText = editText.Text ?? string.Empty;

            var inputType = editText.InputType;

            bool isPasswordEnabled =
                (inputType & InputTypes.TextVariationPassword) == InputTypes.TextVariationPassword ||
                (inputType & InputTypes.NumberVariationPassword) == InputTypes.NumberVariationPassword;

            var newText = GetTransformedText(inputView?.Text,
                    isPasswordEnabled ? TextTransform.None : inputView.TextTransform);

            return (oldText, newText);
        }

        public static string GetTransformedText(string source, TextTransform textTransform)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            switch (textTransform)
            {
                case TextTransform.None:
                default:
                    return source;
                case TextTransform.Lowercase:
                    return source.ToLowerInvariant();
                case TextTransform.Uppercase:
                    return source.ToUpperInvariant();
            }
        }

        public static void UpdateTex(this EditText editText, IEntry entry)
        {
            editText.UpdateText(entry);
        }
    }
}
