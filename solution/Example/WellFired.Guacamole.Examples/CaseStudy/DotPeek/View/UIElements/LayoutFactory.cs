using WellFired.Guacamole.Data;
using WellFired.Guacamole.Layouts;
using WellFired.Guacamole.Views;

namespace WellFired.Guacamole.Examples.CaseStudy.DotPeek.View.UIElements
{
    public static class LayoutFactory
    {
        public static LayoutView CreateVerticalLayout(params ILayoutable[] children)
        {
            return new LayoutView
            {
                Layout = new AdjacentLayout {Orientation = OrientationOptions.Vertical},
                Children = children
            };
        }

        public static LayoutView CreateHorizontalLayout(params ILayoutable[] children)
        {
            return new LayoutView
            {
                Layout = new AdjacentLayout {Orientation = OrientationOptions.Horizontal},
                Children = children
            };
        }
    }
}