﻿using NUnit.Framework;
using NUnit.Framework.Internal;
using WellFired.Guacamole.Types;
using WellFired.Guacamole.Views;

namespace WellFired.Guacamole.Integration.Layouts.Simple
{
    public class Given_AWindowWithContent
    {
        [Test]
        public void That_IsLayedoutTwice_Then_LayoutIsDoneCorrectly()
        {
            var view = new Slider {
                MinSize = UISize.Of(50, 10),
                MinValue = 0.0,
                MaxValue = 10.0,
                Value = 5.0
            };

            var logger = NSubstitute.Substitute.For<Diagnostics.ILogger>();
            var window = new Window (logger) {
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill,
                Content = view
            };

            window.Layout(UIRect.With(0, 0, 100, 100));
            Assert.That(view.RectRequest, Is.EqualTo(UIRect.With(0, 0, 100, 10)));

            window.Layout(UIRect.With(0, 0, 100, 100));
            Assert.That(view.RectRequest, Is.EqualTo(UIRect.With(0, 0, 100, 10)));
        }

        [Test]
        public void That_HasASpecifiedMinSize_And_IsLayedoutTwice_Then_LayoutIsDoneCorrectly()
        {
            var view = new Slider {
                MinSize = UISize.Of(50, 10),
                MinValue = 0.0,
                MaxValue = 10.0,
                Value = 5.0
            };

            var logger = NSubstitute.Substitute.For<Diagnostics.ILogger>();
            var window = new Window (logger) {
                HorizontalLayout = LayoutOptions.Fill,
                VerticalLayout = LayoutOptions.Fill,
                Content = view
            };

            ViewSizingExtensions.DoSizingAndLayout(window, UIRect.With(0, 0, 500, 500));
            Assert.That(view.RectRequest, Is.EqualTo(UIRect.With(0, 0, 500, 10)));

            ViewSizingExtensions.DoSizingAndLayout(window, UIRect.With(0, 0, 500, 500));
            Assert.That(view.RectRequest, Is.EqualTo(UIRect.With(0, 0, 500, 10)));
        }
    }
}