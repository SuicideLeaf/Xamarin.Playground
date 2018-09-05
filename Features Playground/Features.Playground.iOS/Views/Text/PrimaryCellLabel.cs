using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Features.Playground.iOS.Views.Text
{
	public partial class PrimaryCellLabel : UILabel
	{
		public static readonly UIColor TextColour = UIColor.DarkGray;

		public PrimaryCellLabel( IntPtr handle ) : base( handle )
		{
			Initialize( );
		}

		public PrimaryCellLabel( NSCoder coder ) : base( coder )
		{
			Initialize( );
		}


		public PrimaryCellLabel( CGRect frame ) : base( frame )
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