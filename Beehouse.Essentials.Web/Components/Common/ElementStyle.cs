using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Web.Components.Common
{
    public enum ElementStyle
    {
        Primary,
        Secondary,
        Success,
        Danger,
        Warning,
        Info,
        Light,
        Dark
    }

    public static class ElementStyleExtensions
    {
        public static string ToClassString(this ElementStyle t)
        {
            switch (t)
            {
                case ElementStyle.Primary: return "primary";
                case ElementStyle.Secondary: return "secondary";
                case ElementStyle.Success: return "success";
                case ElementStyle.Danger: return "danger";
                case ElementStyle.Warning: return "warning";
                case ElementStyle.Info: return "info";
                case ElementStyle.Light: return "light";
                case ElementStyle.Dark: return "dark";
            }

            return "primary";
        }
    }
}
