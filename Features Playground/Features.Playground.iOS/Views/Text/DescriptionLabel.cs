using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Features.Playground.iOS.Views.Text
{
	[Register( "DescriptionLabel" )]
	public class DescriptionLabel : UILabel
	{
		public static readonly UIColor TextColour = UIColor.DarkGray;

		public DescriptionLabel( IntPtr handle ) : base( handle )
		{
			Initialize( );
		}

		public DescriptionLabel( NSCoder coder ) : base( coder )
		{
			Initialize( );
		}


		public DescriptionLabel( CGRect frame ) : base( frame )
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
			Font = UIFont.SystemFontOfSize( 15, UIFontWeight.Regular );
			Lines = 0;
		}
	}
}