using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Features.Playground.iOS.Views.Text
{
	[Register( "DetailsTitleLabel" )]
	public class DetailsTitleLabel : UILabel
	{
		public static readonly UIColor TextColour = UIColor.Black;

		public DetailsTitleLabel( IntPtr handle ) : base( handle )
		{
			Initialize( );
		}

		public DetailsTitleLabel( NSCoder coder ) : base( coder )
		{
			Initialize( );
		}


		public DetailsTitleLabel( CGRect frame ) : base( frame )
		{
			Initialize( );
		}

		public override void AwakeFromNib( )
		{
			base.AwakeFromNib( );

			Initialize( );
		}

		private void Initialize( )
		{
			TextColor = TextColour;
			Font = UIFont.SystemFontOfSize( 19, UIFontWeight.Regular );
			Lines = 2;
		}
	}
}