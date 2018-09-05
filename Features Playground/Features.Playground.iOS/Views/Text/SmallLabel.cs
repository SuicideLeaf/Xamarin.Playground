using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Features.Playground.iOS.Views.Text
{
	[Register( "SmallLabel" )]
	public class SmallLabel : UILabel
	{
		public static readonly UIColor TextColour = UIColor.LightGray;

		public SmallLabel( IntPtr handle ) : base( handle )
		{
			Initialize( );
		}

		public SmallLabel( NSCoder coder ) : base( coder )
		{
			Initialize( );
		}


		public SmallLabel( CGRect frame ) : base( frame )
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
			Font = UIFont.SystemFontOfSize( 11, UIFontWeight.Regular );
			Lines = 2;
		}
	}
}