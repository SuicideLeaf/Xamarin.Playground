using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Features.Playground.iOS.Views.Text
{
	public partial class SecondaryCellLabel : UILabel
	{
		public static readonly UIColor TextColour = UIColor.Gray;

		public SecondaryCellLabel( IntPtr handle ) : base( handle )
		{
			Initialize( );
		}

		public SecondaryCellLabel( NSCoder coder ) : base( coder )
		{
			Initialize( );
		}


		public SecondaryCellLabel( CGRect frame ) : base( frame )
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
			Font = UIFont.SystemFontOfSize( 13, UIFontWeight.Regular );
			Lines = 0;
		}
	}
}
