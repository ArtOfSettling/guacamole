﻿using WellFired.Guacamole.Types;
using WellFired.Guacamole.Views;

namespace WellFired.Guacamole.Styling.Styles
{
    internal static class ImageCell
    {
        private static readonly UIColor DarkerColor = UIColor.FromRGB(200, 200, 200);

        public static readonly Style Style = new Style
        {
            Setters =
            {
                new Setter {Property = View.BackgroundColorProperty, Value = DarkerColor},
                new Setter {Property = View.OutlineColorProperty, Value = DarkerColor},
                new Setter {Property = View.HorizontalLayoutProperty, Value = LayoutOptions.Expand},
                new Setter {Property = View.VerticalLayoutProperty, Value = LayoutOptions.Expand}
            }
        };
    }
}