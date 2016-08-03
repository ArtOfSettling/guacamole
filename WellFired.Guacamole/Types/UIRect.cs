﻿using WellFired.Guacamole.Annotations;

namespace WellFired.Guacamole.Types
{
    // ReSharper disable once InconsistentNaming
	public struct UIRect
	{
		private int _x;
		private int _y;
		private int _width;
		private int _height;
	    private UILocation _location;
	    private UISize _size;

	    // ReSharper disable once InconsistentNaming
		private static readonly UIRect min = new UIRect (0, 0, 0, 0);
	    // ReSharper disable once InconsistentNaming
		private static readonly UIRect max = new UIRect (0, 0, int.MaxValue, int.MaxValue);
	    // ReSharper disable once InconsistentNaming
		private static readonly UIRect one = new UIRect (0, 0, 1, 1);

        [PublicAPI]
        public static UIRect Min { get { return min; } }
        [PublicAPI]
        public static UIRect Max { get { return max; } }
        [PublicAPI]
        public static UIRect One { get { return one; } }

        [PublicAPI]
        public int X 
		{
			get { return _x; }
			set 
			{ 
				_x = value; 
				_location.X = _x;
			}
		}

        [PublicAPI]
        public int Y 
		{
			get { return _y; }
			set 
			{ 
				_y = value; 
				_location.Y = _y;
			}
		}

        [PublicAPI]
        public int Width 
		{
			get { return _width; }
			set 
			{ 
				_width = value; 
				_size.Width = _width;
			}
		}

        [PublicAPI]
        public int Height 
		{
			get { return _height; }
			set 
			{ 
				_height = value; 
				_size.Height = _height;
			}
		}

        [PublicAPI]
        public UILocation Location
		{
			get { return _location; }
			set 
			{ 
				_location = value; 
				_x = _location.X;
				_y = _location.Y;
			}
		}

        [PublicAPI]
        public UISize Size
		{
			get { return _size; }
			set 
			{ 
				_size = value; 
				_width = _size.Width;
				_height = _size.Height;
			}
		}

		public UIRect(int x, int y, int width, int height)
		{
			_x = x;
			_y = y;
			_width = width;
			_height = height;
			_location = new UILocation(x, y);
			_size = new UISize(width, height);
		}

		public override bool Equals(object obj)
		{
			var compareTo = (UIRect)obj;
			return compareTo.X == X && compareTo.Y == Y && compareTo.Width == Width && compareTo.Height == Height;
		}

		public override int GetHashCode()
		{
			return X ^ Y ^ Width ^ Height;
		}

		public static bool operator==(UIRect a, UIRect b)
		{
			return a.Equals(b);
		}

		public static bool operator!=(UIRect a, UIRect b)
		{
			return !(a == b);
		}

		public static UIRect operator+(UIRect rect, UIPadding padding)
		{
			return new UIRect(
				rect.X, 
				rect.Y, 
				rect.Width + padding.Width, 
				rect.Height + padding.Height);
		}

		public static UIRect operator-(UIRect rect, UIPadding padding)
		{
			return new UIRect(
				rect.X + padding.Left, 
				rect.Y + padding.Top, 
				rect.Width - padding.Width, 
				rect.Height - padding.Height);
		}

	    public override string ToString()
	    {
	        return string.Format("x: {0}, y: {1}, width: {2}, height: {3}", X, Y, Width, Height);
	    }
	}
}