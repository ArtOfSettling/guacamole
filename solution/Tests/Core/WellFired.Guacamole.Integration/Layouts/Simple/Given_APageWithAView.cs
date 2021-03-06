﻿using NUnit.Framework;
using WellFired.Guacamole.Data;
using WellFired.Guacamole.Pages;
using WellFired.Guacamole.Views;

namespace WellFired.Guacamole.Integration.Layouts.Simple
{
    public class GivenAPageWithAView
    {
        [Test]
        public void That_IsLayedoutTwice_Then_LayoutIsDoneCorrectly()
        {
            var view = new Views.View {
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill,
            };

            var page = new Page {
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill,
                Content = view
            };

            ViewSizingExtensions.DoSizingAndLayout(page, UIRect.With(100, 100));

            Assert.That(page.RectRequest, Is.EqualTo(UIRect.With(100, 100)));
            Assert.That(view.RectRequest, Is.EqualTo(UIRect.With(100, 100)));

            ViewSizingExtensions.DoSizingAndLayout(page, UIRect.With(100, 100));

            Assert.That(page.RectRequest, Is.EqualTo(UIRect.With(100, 100)));
            Assert.That(view.RectRequest, Is.EqualTo(UIRect.With(100, 100)));
        }

        [Test]
        public void That_HasASpecifiedMinSize_And_IsLayedoutTwice_Then_LayoutIsDoneCorrectly()
        {
            var view = new Views.View {
                MinSize = UISize.Of(50, 10),
                HorizontalLayout = LayoutOptions.Expand,
                VerticalLayout = LayoutOptions.Expand,
            };

            var page = new Page {
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill,
                Content = view
            };

            ViewSizingExtensions.DoSizingAndLayout(page, UIRect.With(500, 500));

            Assert.That(page.RectRequest, Is.EqualTo(UIRect.With(500, 500)));
            Assert.That(view.RectRequest, Is.EqualTo(UIRect.With(50, 10)));

            ViewSizingExtensions.DoSizingAndLayout(page, UIRect.With(500, 500));

            Assert.That(page.RectRequest, Is.EqualTo(UIRect.With(500, 500)));
            Assert.That(view.RectRequest, Is.EqualTo(UIRect.With(50, 10)));
        }
    }
}