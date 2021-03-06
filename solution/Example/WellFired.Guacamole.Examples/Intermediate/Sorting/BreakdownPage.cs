using WellFired.Guacamole.Data;
using WellFired.Guacamole.DataBinding;
using WellFired.Guacamole.Examples.Intermediate.Sorting.Cells;
using WellFired.Guacamole.Examples.Intermediate.Sorting.ViewModel;
using WellFired.Guacamole.Layouts;
using WellFired.Guacamole.Pages;
using WellFired.Guacamole.Views;

namespace WellFired.Guacamole.Examples.Intermediate.Sorting
{
    public class BreakdownPage : Page
    {
        public BreakdownPage()
        {
            Padding = 0;
            BackgroundColor = UIColor.White;

            var sortByPath = new ButtonView
            {
                Text = "Path",
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill
            };
            
            var sortByBefore = new ButtonView
            {
                Text = "Before",
                HorizontalLayout = LayoutOptions.Expand,
                VerticalLayout = LayoutOptions.Fill,
                MinSize = UISize.Of(80, 0)
            };
            
            var sortByAfter = new ButtonView
            {
                Text = "After",
                HorizontalLayout = LayoutOptions.Expand,
                VerticalLayout = LayoutOptions.Fill,
                MinSize = UISize.Of(80, 0)
            };
            
            var buttonView = new LayoutView
            {
                HorizontalLayout = LayoutOptions.Fill,
                Layout = AdjacentLayout.Of(OrientationOptions.Horizontal),
                Children = {
                    sortByPath,
                    sortByBefore,
                    sortByAfter
                }
            }; 
            
            var listView = new ListView {
                EntrySize = 20,
                Orientation = OrientationOptions.Vertical,
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill,
                ItemTemplate = DataTemplate.Of(typeof(AssetBreakdownCell)),
            };
            
            Content = new LayoutView
            {
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill,
                Layout = AdjacentLayout.Of(OrientationOptions.Vertical),
                Children = {
                    buttonView,
                    listView      
                }
            };
            
            BindingContext = new Breakdown();
            
            listView.Bind(ItemsView.ItemSourceProperty, "DisplayList");
            sortByPath.Bind(ButtonView.ButtonPressedCommandProperty, "SortByPath");
            sortByBefore.Bind(ButtonView.ButtonPressedCommandProperty, "SortByBefore");
            sortByAfter.Bind(ButtonView.ButtonPressedCommandProperty, "SortByAfter");
        }
    }
}