﻿using NUnit.Framework;
using WellFired.Guacamole.Data;

namespace WellFired.Guacamole.Integration.View.Slider.Bindable
{
	[TestFixture]
	public class SliderThumbBackgroundColorTests
	{
		[SetUp]
		public void Setup()
		{
			_sliderView = new Views.SliderView();
			_sliderContext = new SliderContextObject();
			_sliderView.BindingContext = _sliderContext;
		}

		private Views.SliderView _sliderView;
		private SliderContextObject _sliderContext;

		[Test]
		public void IsBindable()
		{
			_sliderView.ThumbBackgroundColor = UIColor.Aquamarine;
			_sliderContext.ThumbBackgroundColor = UIColor.Beige;
			Assert.That(_sliderContext.ThumbBackgroundColor != _sliderView.ThumbBackgroundColor);
			_sliderView.Bind(Views.SliderView.ThumbBackgroundColorProperty, nameof(_sliderContext.ThumbBackgroundColor));
			Assert.That(_sliderContext.ThumbBackgroundColor == _sliderView.ThumbBackgroundColor);
			_sliderContext.ThumbBackgroundColor = UIColor.Blue;
			Assert.That(_sliderContext.ThumbBackgroundColor == _sliderView.ThumbBackgroundColor);
		}
	}
}