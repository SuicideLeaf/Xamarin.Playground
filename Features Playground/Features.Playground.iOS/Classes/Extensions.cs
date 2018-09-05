using System;
using UIKit;

namespace Features.Playground.iOS.Classes
{
	public static class Extensions
	{
		public static void ToColour( this UIImageView imageView, UIColor colour )
		{
			imageView.Image = imageView.Image.ImageWithRenderingMode( UIImageRenderingMode.AlwaysTemplate );
			imageView.TintColor = colour;
		}

		public static UIColor FromHex( this UIColor colour, string hexValue, float alpha = 1.0f )
		{
			var colourString = hexValue.Replace( "#", "" );

			if ( alpha > 1.0f )
			{
				alpha = 1.0f;
			}
			else if ( alpha < 0.0f )
			{
				alpha = 0.0f;
			}

			float red, green, blue;

			switch ( colourString.Length )
			{
				case 3: // #RGB
				{
					red = Convert.ToInt32( string.Format( "{0}{0}", colourString.Substring( 0, 1 ) ), 16 ) / 255f;
					green = Convert.ToInt32( string.Format( "{0}{0}", colourString.Substring( 1, 1 ) ), 16 ) / 255f;
					blue = Convert.ToInt32( string.Format( "{0}{0}", colourString.Substring( 2, 1 ) ), 16 ) / 255f;
					return UIColor.FromRGBA( red, green, blue, alpha );
				}
				case 6: // #RRGGBB
				{
					red = Convert.ToInt32( colourString.Substring( 0, 2 ), 16 ) / 255f;
					green = Convert.ToInt32( colourString.Substring( 2, 2 ), 16 ) / 255f;
					blue = Convert.ToInt32( colourString.Substring( 4, 2 ), 16 ) / 255f;
					return UIColor.FromRGBA( red, green, blue, alpha );
				}

				default:
					throw new ArgumentOutOfRangeException( $"Color value {hexValue} is invalid. It should be a hex value of the form #RBG, #RRGGBB" );
			}
		}
	}
}