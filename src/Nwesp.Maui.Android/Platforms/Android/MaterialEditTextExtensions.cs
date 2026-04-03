using Android.Content.Res;
using Android.Graphics;
using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Widget;
using Java.Lang;
using Microsoft.Maui;
using Microsoft.Maui.Platform;
using Nwesp.Maui.Android.Abstractions;
using Nwesp.Maui.Android.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AResource = Android.Resource.Attribute;
using AView = Android.Views.View;
using APaint = Android.Graphics.Paint;
namespace Nwesp.Maui.Android.Platforms.Android
{
    public static class MaterialEditTextExtensions
    {
        public static void UpdateTextColor(this EditText editText, IMaterialEntry entry)
        {
            int[][] states =
            [
                [AResource.StateEnabled],
                [-AResource.StateEnabled]
            ];
            
            int[] colors =
            [
                entry.TextColor.ToPlatform(),
                entry.DisabledTextColor.WithAlpha(entry.DisabledTextColorOpacity).ToPlatform()
            ];

            editText.SetTextColor(new ColorStateList(states, colors));
        }
        
        public static void TogglePasswordOn(this EditText editText)
        {
            if (editText.InputType.HasFlag(InputTypes.ClassText))
                editText.InputType |= InputTypes.TextVariationPassword;
            if (editText.InputType.HasFlag(InputTypes.ClassNumber))
                editText.InputType |= InputTypes.NumberVariationPassword;
        }

        public static void TogglePasswordOff(this EditText editText)
        {
            if (editText.InputType.HasFlag(InputTypes.ClassText))
                editText.InputType &= ~InputTypes.TextVariationPassword;
            if (editText.InputType.HasFlag(InputTypes.ClassNumber))
                editText.InputType &= ~InputTypes.NumberVariationPassword;
        }

        //public static void TogglePasswordOn(this EditText editText)
        //{
        //    editText.TransformationMethod = new SpacedPasswordTransformationMethod("• ");
        //    editText.SetSelection(editText.Text?.Length ?? 0);
        //}

        //public static void TogglePasswordOff(this EditText editText)
        //{
        //    editText.TransformationMethod = null;
        //    editText.SetSelection(editText.Text?.Length ?? 0);
        //}
        public class SpacedPasswordTransformationMethod : PasswordTransformationMethod
        {
            private readonly string _mask;

            public SpacedPasswordTransformationMethod(string mask = "• ")
            {
                _mask = mask;
            }

            public override ICharSequence? GetTransformationFormatted(ICharSequence? source, AView? view)
            {
                if (source == null)
                    return null;

                var spannable = new SpannableString(source);

                for (int i = 0; i < source.Length(); i++)
                {
                    spannable.SetSpan(new DotSpan(), i, i + 1, SpanTypes.ExclusiveExclusive);
                }

                return spannable;
            }

            private class DotSpan : ReplacementSpan
            {

                
                private const float SpacingDp = 4f;     // horizontal spacing
                private const float Scale = 1.4f;      // 🔥 increase dot size (1.0 = normal)

                public override int GetSize(APaint paint, ICharSequence? text, int start, int end, APaint.FontMetricsInt? fm)
                {
                    var originalSize = paint.TextSize;
                    paint.TextSize = originalSize * Scale;

                    float width = paint.MeasureText("•");

                    float spacingPx = SpacingDp * 2.75f;

                    paint.TextSize = originalSize;

                    return (int)(width + spacingPx);
                }

                public override void Draw(Canvas canvas, ICharSequence? text, int start, int end,
    float x, int top, int y, int bottom, APaint paint)
                {
                    var originalSize = paint.TextSize;

                    float scaledSize = originalSize * Scale;
                    float offset = (scaledSize - originalSize) / 2f; // 👈 push DOWN

                    paint.TextSize = scaledSize;

                    canvas.DrawText("•", x, y + offset, paint);
                    // • ●
                    paint.TextSize = originalSize;
                }
            }
        }
    }
}
