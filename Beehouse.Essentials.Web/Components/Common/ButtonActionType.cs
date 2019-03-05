using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Web.Components.Common
{
    public enum ButtonActionType
    {
        Create,
        Edit,
        Delete
    }

    public static class ButtonActionTypeExtensions
    {
        public static string ToIconClass(this ButtonActionType t)
        {
            switch (t)
            {
                case ButtonActionType.Create: return "plus";
                case ButtonActionType.Edit: return "pencil";
                case ButtonActionType.Delete: return "trash";
            }

            return "";
        }

        public static ElementStyle ToElementStyle(this ButtonActionType t)
        {
            switch (t)
            {
                case ButtonActionType.Create: return ElementStyle.Primary;
                case ButtonActionType.Edit: return ElementStyle.Primary;
                case ButtonActionType.Delete: return ElementStyle.Danger;
            }

            return ElementStyle.Primary;
        }
    }

}
