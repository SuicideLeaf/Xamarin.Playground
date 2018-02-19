using System;
using Landlord.iOS.Helpers;
using MvpArchitecture.Areas;
using MvpArchitecture.Classes;
using MvpArchitecture.Helpers;
using UIKit;
using static MvpArchitecture.Helpers.ApiHelper;

namespace MvpArchitecture.iOS.Areas
{
	public class BaseApiViewController<T, TParams> : BaseViewController<T>, IApiView<TParams>
		where T : BasePresenter
		where TParams : QueryParameters
	{
		public bool InitialLoadComplete { get; set; }
		public TParams QueryParameters { get; set; }

		public BaseApiViewController( IntPtr handle ) : base( handle ) { }

		public override void RegisterView( )
		{
			// Do nothing
		}

		public override void ViewDidLoad( )
		{
			base.ViewDidLoad( );

			SetupQueryParameters( );
		}

		public void SetupQueryParameters( Guid? tokenOverride = null )
		{
			Guid token = tokenOverride ?? KeyChainHelper.GetToken( ) ?? Guid.Empty;
			Guid requestIdentifier = Guid.NewGuid( );
			string deviceIdentifier = UIDevice.CurrentDevice.IdentifierForVendor.AsString( );
			string checkSum = CryptoHelper.GenerateApiSignedHash( requestIdentifier, deviceIdentifier, CoreConfig.TestConsumerSecret );

			QueryParameters.SetupBaseQueryParameters( token.ToString( ), requestIdentifier.ToString( ), deviceIdentifier, checkSum );
		}
	}
}
