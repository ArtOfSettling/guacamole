﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WellFired.Guacamole.Attributes;

namespace WellFired.Guacamole.Renderer
{
	public static class NativeRendererHelper
	{
		private static Dictionary<Type, ConstructorInfo> _typeMap;
		public static Assembly LaunchedAssembly { private get; set; }

		public static INativeRenderer CreateNativeRendererFor(Type controlType)
		{
			if (_typeMap == null)
			{
				// This is shit.
				var assemblies = AppDomain.CurrentDomain.GetAssemblies();
				var exampleAssembly = assemblies.FirstOrDefault(o => o.FullName.Contains("WellFired.Guacamole.Examples.Unity.Editor"));
				
				var attributes = LaunchedAssembly
					.GetCustomAttributes(typeof(CustomRendererAttribute), false)
					.Cast<CustomRendererAttribute>();
				
				var exampleAttributes = exampleAssembly?
					.GetCustomAttributes(typeof(CustomRendererAttribute), false)
					.Cast<CustomRendererAttribute>();

				_typeMap = new Dictionary<Type, ConstructorInfo>();
				foreach (var attribute in attributes)
					_typeMap[attribute.ControlType] = attribute.RendererType.GetConstructor(Type.EmptyTypes);
				
				if (exampleAttributes != null)
					foreach (var attribute in exampleAttributes)
						_typeMap[attribute.ControlType] = attribute.RendererType.GetConstructor(Type.EmptyTypes);
			}

			var checkType = controlType;
			while (!_typeMap.ContainsKey(checkType))
			{
				checkType = checkType.BaseType;
				if (checkType == null)
					break;
			}

			// ReSharper disable once CoVariantArrayConversion
			// ReSharper disable once AssignNullToNotNullAttribute
			return _typeMap[checkType].Invoke(Type.EmptyTypes) as INativeRenderer;
		}
	}
}