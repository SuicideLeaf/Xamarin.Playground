using Foundation;
using UIKit;

namespace Features.Playground.iOS.Views.Cards
{
	[Register( "CardViewRound" )]
	public class CardViewRound : UIView
	{
		public override void AwakeFromNib( )
		{
			base.AwakeFromNib( );

			Layer.CornerRadius = Frame.Height / 2;
		}
	}
}