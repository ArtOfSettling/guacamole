﻿using WellFired.Guacamole.Cells;
using WellFired.Guacamole.Data;
using WellFired.Guacamole.DataBinding;
using WellFired.Guacamole.Layouts;
using WellFired.Guacamole.Styling;
using WellFired.Guacamole.Views;

namespace WellFired.Guacamole.Examples.CaseStudy.Taskist.View.Cells
{
    public class TaskCell : Cell
    {
        public TaskCell()
        {
            Style = Styles.FilterCell.Style;
            
            var doneNotDone = new ToggleView
            {
                HorizontalLayout = LayoutOptions.Expand,
                VerticalLayout = LayoutOptions.Center,
                MinSize = UISize.Of(24, 24)
            };

            var filterName = new LabelView
            {
                BackgroundColor = UIColor.Clear,
                HorizontalTextAlign = UITextAlign.Start,
                VerticalTextAlign = UITextAlign.Middle,
                TextColor = UIColor.FromRGB(62, 62, 62),
                VerticalLayout = LayoutOptions.Fill,
                OutlineMask = OutlineMask.Bottom,
                FontSize = 14,
                OutlineThickness = 1.0
            };
            
            var layoutView = new LayoutView
            {
                BackgroundColor = UIColor.Clear,
                OutlineColor = UIColor.Clear,
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill,
                Layout = AdjacentLayout.Of(OrientationOptions.Horizontal, 16),
                Children = {
                    doneNotDone,
                    filterName
                }
            };
            
            doneNotDone.Style = default(Style); // Clear the default style on this because we don't want it to act like regular ToggleView
            filterName.Style = default(Style);  // Clear the default style on this because we don't want it to act like regular Label
            layoutView.Style = default(Style);  // Clear the default style on this because we don't want it to act like regular LayoutView

            Content = layoutView;
            
            filterName.Bind(LabelView.TextProperty, "Description");
            filterName.Bind(ToggleView.OnProperty, "Done", BindingMode.TwoWay);
        }
    }
}