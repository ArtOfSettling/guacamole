﻿using System.Collections.Generic;using System.ComponentModel;using WellFired.Guacamole.DataBinding.Exceptions;namespace WellFired.Guacamole.DataBinding{	public class BindableObject : INotifyPropertyChanged, IBindableObject	{		protected static readonly BindableProperty BindingContextProperty =			BindableProperty.Create<BindableObject, INotifyPropertyChanged>(null, BindingMode.OneWay,				bindableObject => bindableObject.BindingContext);		private readonly Dictionary<string, BindableProperty> _bindings = new Dictionary<string, BindableProperty>();		private readonly Dictionary<BindableProperty, BindableContext> _contexts =			new Dictionary<BindableProperty, BindableContext>();		private readonly Dictionary<string, BindableContext> _targetToContexts = new Dictionary<string, BindableContext>();		private INotifyPropertyChanged _bindingContext;		public INotifyPropertyChanged BindingContext		{			get { return _bindingContext; }			set			{				// Here we check for equality so we can avoid recursion.				if (Equals(_bindingContext, value))					return;				if (_bindingContext != null)					_bindingContext.PropertyChanged -= OnPropertyChanged;				_bindingContext = value;				foreach (var bindingKvp in _bindings)				{					var bindableProperty = bindingKvp.Value;					_contexts[bindableProperty].Object = _bindingContext;										var newValue = _contexts[bindableProperty].GetValue();					SetValue(_contexts[bindableProperty].Property, newValue);				}				OnPropertyChanged(this, new PropertyChangedEventArgs(BindingContextProperty.PropertyName));				_bindingContext.PropertyChanged += OnPropertyChanged;			}		}		public event PropertyChangedEventHandler PropertyChanged;		public void Bind(BindableProperty bindableProperty, string targetProperty,			BindingMode bindingMode = BindingMode.OneWay)		{			if (_bindings.ContainsKey(bindableProperty.PropertyName))				throw new BindingExistsException(bindableProperty.PropertyName);			bindableProperty.BindingMode = bindingMode;			_bindings[bindableProperty.PropertyName] = bindableProperty;			var context = GetOrCreateBindableContext(bindableProperty);			context.Object = BindingContext;			context.TargetProperty = targetProperty;			_targetToContexts[targetProperty] = context;			var initialValue = context.GetValue();			SetValue(bindableProperty, initialValue);		}		protected object GetValue(BindableProperty bindableProperty)		{			return GetOrCreateBindableContext(bindableProperty).Value;		}		protected bool SetValue(BindableProperty bindableProperty, object value)		{			var previous = GetOrCreateBindableContext(bindableProperty).Value;			if (Equals(previous, value))				return false;			GetOrCreateBindableContext(bindableProperty).Value = value;			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(bindableProperty.PropertyName));			return true;		}		private BindableContext GetOrCreateBindableContext(BindableProperty bindableProperty)		{			var bindablePropertyContext = GetContext(bindableProperty) ?? CreateAndAddContext(bindableProperty);			return bindablePropertyContext;		}		private BindableContext GetContext(BindableProperty bindableProperty)		{			try			{				return _contexts[bindableProperty];			}			catch			{				// ignored			}			return null;		}		private BindableContext CreateAndAddContext(BindableProperty bindableProperty)		{			var bindablePropertyContext = new BindableContext			{				Property = bindableProperty,				Value = bindableProperty.DefaultValue,				Object = _bindingContext			};						_contexts[bindableProperty] = bindablePropertyContext;			return bindablePropertyContext;		}		protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)		{			if (!_targetToContexts.ContainsKey(e.PropertyName))				return;			var context = _targetToContexts[e.PropertyName];			var newValue = context.GetValue();			SetValue(context.Property, newValue);		}	}}