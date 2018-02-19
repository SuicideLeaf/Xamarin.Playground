using System;
using Android.App;
using Android.OS;
using Android.Provider;
using Android.Support.V7.App;
using MvpArchitecture.Android.Helpers;
using MvpArchitecture.Areas;
using MvpArchitecture.Classes;
using MvpArchitecture.Helpers;
using static MvpArchitecture.Helpers.ApiHelper;

namespace MvpArchitecture.Android.Areas
{
	[Activity( Label = "BaseApiActivity" )]
	public class BaseApiActivity<T, TParams> : BaseUnityActivity<T>, IApiView<TParams>
		where T : BasePresenter
		where TParams : QueryParameters
	{
		public TParams QueryParameters { get; set; }

		public override void RegisterView( )
		{
			// Not needed, this will be registered further up the chain.
		}

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			SetupQueryParameters( );
		}

		private void SetupQueryParameters( Guid? tokenOverride = null )
		{
			Guid token = tokenOverride ?? PreferencesHelper.GetAuthenticationToken( this ) ?? Guid.Empty;
			Guid requestIdentifier = Guid.NewGuid( );
			string deviceIdentifier = Settings.Secure.GetString( ContentResolver, Settings.Secure.AndroidId );
			string checkSum = CryptoHelper.GenerateApiSignedHash( requestIdentifier, deviceIdentifier, CoreConfig.TestConsumerSecret );

			QueryParameters.SetupBaseQueryParameters( token.ToString( ), requestIdentifier.ToString( ), deviceIdentifier, checkSum );
		}
	}
}
