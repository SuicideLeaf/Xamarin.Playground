using System;
using Android.Content;
using Android.Provider;
using Android.OS;
using MvpArchitecture.Interfaces;
using MvpArchitecture.Classes;
using MvpArchitecture.Android.Helpers;

namespace MvpArchitecture.Android.Handlers
{
	public class RequestHandler : IRequestHandler
	{
		private readonly Context _context;

		public RequestHandler( Context context )
		{
			_context = context;
		}

		public string DeviceIdentifier => Settings.Secure.GetString( _context.ContentResolver, Settings.Secure.AndroidId );

		public string InstanceUrl => PreferencesHelper.GetInstanceUrl( _context );

		public Guid? AuthenticationToken => PreferencesHelper.GetAuthenticationToken( _context );

		public string DeviceInfo => $"{Build.Manufacturer} {Build.Model} API {Build.VERSION.SdkInt} {Build.VERSION.Sdk} v{Build.VERSION.Release}";

		public Guid ConsumerKey => CoreConfig.TestConsumerKey;

		public Guid Secret => CoreConfig.TestConsumerSecret;
	}
}
