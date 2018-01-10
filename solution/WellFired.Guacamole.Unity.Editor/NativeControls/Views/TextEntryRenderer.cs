﻿using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using WellFired.Guacamole.Attributes;
using WellFired.Guacamole.Data;
using WellFired.Guacamole.Unity.Editor.Extensions;
using WellFired.Guacamole.Unity.Editor.NativeControls.Views;
using WellFired.Guacamole.Views;

[assembly: CustomRenderer(typeof(TextEntryView), typeof(TextEntryRenderer))]

namespace WellFired.Guacamole.Unity.Editor.NativeControls.Views
{
	public class TextEntryRenderer : BaseRenderer
	{
		public override UISize? NativeSize
		{
			get
			{
				var entry = Control as TextEntryView;
				// ReSharper disable once PossibleNullReferenceException
				return Style.CalcSize(new GUIContent(entry.Text)).ToUISize();
			}
		}

		protected override void SetupWithNewStyle()
		{
			base.SetupWithNewStyle();

			var entry = (TextEntryView)Control;
			Style.alignment = UITextAlignExtensions.Combine(entry.HorizontalTextAlign, entry.VerticalTextAlign);
			Style.focused.textColor = entry.TextColor.ToUnityColor();
			Style.active.textColor = entry.TextColor.ToUnityColor();
			Style.hover.textColor = entry.TextColor.ToUnityColor();
			Style.normal.textColor = entry.TextColor.ToUnityColor();
		}

		private bool _wasFocused;
		public override void Render(UIRect renderRect)
		{
			base.Render(renderRect);

			var entry = (TextEntryView)Control;
			entry.Text = EditorGUI.TextField(UnityRect, entry.Text, Style);

			var isFocused = GUI.GetNameOfFocusedControl() == entry.Id;
			if (!isFocused && _wasFocused)
			{
				entry.OnFocusLost?.Execute();
			}
			
			if (isFocused &&
			    UnityEngine.Event.current.isKey && UnityEngine.Event.current.keyCode == KeyCode.Return)
			{
				entry.OnInputEnter?.Execute();
			}

			_wasFocused = isFocused;
		}

		public override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(sender, e);

			var entry = (TextEntryView)Control;
			if (e.PropertyName == TextEntryView.HorizontalTextAlignProperty.PropertyName || e.PropertyName == TextEntryView.VerticalTextAlignProperty.PropertyName)
				Style.alignment = UITextAlignExtensions.Combine(entry.HorizontalTextAlign, entry.VerticalTextAlign);

			if (e.PropertyName == TextEntryView.TextColorProperty.PropertyName)
			{
				Style.focused.textColor = entry.TextColor.ToUnityColor();
				Style.active.textColor = entry.TextColor.ToUnityColor();
				Style.hover.textColor = entry.TextColor.ToUnityColor();
				Style.normal.textColor = entry.TextColor.ToUnityColor();
			}
		}
	}
}