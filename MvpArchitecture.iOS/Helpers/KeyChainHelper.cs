using System;
using Foundation;
using Security;

namespace Landlord.iOS.Helpers
{
	public static class KeyChainHelper
	{
		private const string ServiceName = "TestService";
		private const string TokenKey = "TestToken";

		public static Guid? GetToken( )
		{
			Guid? token = null;

			SecRecord record = GetTokenKeyChain( out SecRecord tokenQuery );

			if ( record != null )
			{
				token = Guid.Parse( NSString.FromData( record.ValueData, NSStringEncoding.UTF8 ) );
			}

			return token;
		}

		public static void StoreTokenKeyChain( Guid token )
		{
			var record = GetTokenKeyChain( out SecRecord tokenQuery );

			if ( record == null )
			{
				record = new SecRecord( SecKind.GenericPassword )
				{
					Service = ServiceName,
					Account = TokenKey,
					Label = TokenKey,
					ValueData = NSData.FromString( token.ToString( ) )
				};

				SecStatusCode statusCode = SecKeyChain.Add( record );
				Console.WriteLine( "KeyChain Status Code: " + statusCode );
				return;
			}

			record.ValueData = NSData.FromString( token.ToString( ) );
			SecKeyChain.Update( tokenQuery, record );
		}

		private static SecRecord GetTokenKeyChain( out SecRecord tokenQuery )
		{
			tokenQuery = new SecRecord( SecKind.GenericPassword )
			{
				Service = ServiceName,
				Account = TokenKey,
				Label = TokenKey
			};

			SecRecord tokenRec = SecKeyChain.QueryAsRecord( tokenQuery, out SecStatusCode code );

			if ( code == SecStatusCode.Success )
			{
				return tokenRec;
			}

			return null;
		}

		public static void RemoveTokenKeyChain( )
		{
			SecRecord secRecord = GetTokenKeyChain( out SecRecord tokenQuery );

			if ( secRecord != null )
			{
				SecKeyChain.Remove( secRecord );
			}
		}
	}
}
