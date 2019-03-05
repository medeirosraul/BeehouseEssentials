using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Beehouse.Essentials.Web.Components.Common
{
    public enum ElementSize
    {
        None,
        ExtraSmall,
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public static class ElementSizeExtensions
    {
        public static string ToClassString(this ElementSize t)
        {
            switch (t)
            {
                case ElementSize.ExtraSmall: return "xs";
                case ElementSize.Small: return "sm";
                case ElementSize.Medium: return "md";
                case ElementSize.Large: return "lg";
                case ElementSize.ExtraLarge: return "xl";
            }

            return "sm";
        }

        public static string ToClassString(this ElementSize t, string prefix)
        {
            if (t == ElementSize.None) return "";

            return prefix + ToClassString(t);
        }
    }
}
