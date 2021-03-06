﻿//#define DEBUG_TEXTURE_CREATION
#if DEBUG_TEXTURE_CREATION
using System.IO;
#endif
using System;
using System.Collections.Generic;
using UnityEngine;
using WellFired.Guacamole.Data;
using JetBrains.Annotations;
using WellFired.Guacamole.Image;

namespace WellFired.Guacamole.Unity.Editor.Extensions
{
	public static class Texture2DExtensions
	{
		private static readonly Dictionary<ShapeParameters, Texture2D> Map = new Dictionary<ShapeParameters, Texture2D>();
		
		[PublicAPI]
		public static Texture2D CreateTexture(int width, int height, Color colour)
		{
			var pixelColors = new Color[width*height];
			for (var i = 0; i < pixelColors.Length; i++)
				pixelColors[i] = colour;

			var result = new Texture2D(width, height)
			{
				wrapMode = TextureWrapMode.Repeat
			};

			result.SetPixels(pixelColors);
			result.Apply();
			result.hideFlags = HideFlags.HideAndDontSave;

			return result;
		}

#if DEBUG_TEXTURE_CREATION
		private static int _counter;
#endif

		[PublicAPI]
		public static Texture2D CreateRoundedTexture(
			int width,
			int height,
			UIColor backgroundColor,
			UIColor outlineColor,
			double radius,
			double thickness,
			CornerMask cornerMask,
			OutlineMask outlineMask)
		{
			var parameters = ShapeParameters.Create(width, height, backgroundColor, outlineColor, radius, thickness, cornerMask, outlineMask);

			if (Map.TryGetValue(parameters, out var textureResult))
				return textureResult;
			
			var result = new Texture2D(width, height) {
				wrapMode = TextureWrapMode.Clamp
			};

			// If we have a thickness of 0, we should set the outline and background color to be the same, thickness of 0 is effectively no outline
			if (Math.Abs(thickness) < 0.01)
				outlineColor = backgroundColor;
			
			var pixelData = radius < 1 || cornerMask == CornerMask.None
				? ImageData.BuildRect(width, height, backgroundColor, outlineColor, thickness, outlineMask) 
				: ImageData.BuildRounded(width, height, backgroundColor, outlineColor, radius, thickness, cornerMask, outlineMask);
			
			var unityPixelData = new Color[pixelData.Length / 4];
			var byteIndex = 0;
			for (var index = 0; index < unityPixelData.Length; index++)
			{
				unityPixelData[index] = new Color32(
					pixelData[byteIndex+0], 
					pixelData[byteIndex+1], 
					pixelData[byteIndex+2], 
					pixelData[byteIndex+3]);

				byteIndex += 4;
			}

			result.SetPixels(unityPixelData);
			result.Apply();
			result.hideFlags = HideFlags.HideAndDontSave;

#if DEBUG_TEXTURE_CREATION
			var bytes = result.EncodeToPNG();
			File.WriteAllBytes($"Assets/file{_counter}.png", bytes);
			_counter++;
#endif

			Map[parameters] = result;
			return Map[parameters];
		}
	}
}