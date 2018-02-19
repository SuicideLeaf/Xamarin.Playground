using System;
using Landlord.iOS.Classes;
using Landlord.iOS.Helpers;
using MvpArchitecture.Classes;
using MvpArchitecture.Interfaces;
using UIKit;

namespace MvpArchitecture.iOS.Handlers
{
	public class RequestHandler : IRequestHandler
	{
		public Guid? AuthenticationToken => KeyChainHelper.GetToken( );

		public string DeviceIdentifier =>  UIDevice.CurrentDevice.IdentifierForVendor.AsString( );

		public string DeviceInfo => $"{UIDevice.CurrentDevice.Model} iOS{UIDevice.CurrentDevice.SystemVersion} - {UIDevice.CurrentDevice.Name}";

		public string InstanceUrl => UserDefaults.InstanceUrl;

		public Guid Secret => CoreConfig.TestConsumerSecret;

		public Guid ConsumerKey => CoreConfig.TestConsumerKey;
	}
}
