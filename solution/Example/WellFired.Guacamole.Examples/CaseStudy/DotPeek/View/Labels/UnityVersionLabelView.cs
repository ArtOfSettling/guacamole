﻿using WellFired.Guacamole.DataBinding;
using WellFired.Guacamole.Examples.CaseStudy.DotPeek.View.Styles;
using WellFired.Guacamole.Views;

namespace WellFired.Guacamole.Examples.CaseStudy.DotPeek.View.Labels
{
	public class UnityVersionLabelView : LabelView
	{
		public UnityVersionLabelView()
		{
			Style = NoBackgroundNoOutline.Style;
			Bind(TextProperty, "UnityVersion", BindingMode.ReadOnly);
		}
	}
}