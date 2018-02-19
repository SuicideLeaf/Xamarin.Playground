using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MvpArchitecture.Classes;
using MvpArchitecture.Interfaces;
using Newtonsoft.Json;
using Refit;

namespace MvpArchitecture.Helpers
{
	public static class ApiHelper
	{
		public static HttpClient GetHttpClient( string instanceUrl, string consumerKey )
		{
			AuthenticatedHttpClientHandler authenticatedHttpClientHandler = new AuthenticatedHttpClientHandler( consumerKey );
			HttpClient httpClient = new HttpClient( authenticatedHttpClientHandler ) { BaseAddress = new Uri( instanceUrl ) };

			//if ( !string.IsNullOrWhiteSpace( mediaType ) )
			//{httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( mediaType ) );
			//}

			//httpClient.Timeout = TimeSpan.FromSeconds( timeoutSeconds );

			return httpClient;
		}

		//public static async Task<Response<TOutputModel>> GetAsync<TOutputModel>( string endPoint, Guid consumerKey, CancellationToken ct = default( CancellationToken ) )
		//{
		//	Response<TOutputModel> responseModel;

		//	using ( HttpClient httpClient = GetHttpClient( consumerKey, "application/json", CoreConstants.TimeoutConstants.ConnectionSeconds ) )
		//	{
		//		try
		//		{
		//			await Task.Delay( 150 );
		//			HttpResponseMessage response = await httpClient.GetAsync( endPoint, ct );

		//			if ( response.IsSuccessStatusCode )
		//			{
		//				string json = await response.Content.ReadAsStringAsync( );
		//				TOutputModel model = JsonConvert.DeserializeObject<TOutputModel>( json );
		//				responseModel = new Response<TOutputModel>( model, response.StatusCode, true );
		//			}
		//			else
		//			{
		//				responseModel = new Response<TOutputModel>( default( TOutputModel ), response.StatusCode, false );
		//			}
		//		}
		//		catch ( Exception )
		//		{
		//			responseModel = new Response<TOutputModel>( default( TOutputModel ), HttpStatusCode.ServiceUnavailable, false );
		//		}
		//	}

		//	return responseModel;
		//}

		//public static string GetEndPoint( IRequestHandler requestHandler, string controller, string[ ] extraParams, Guid? tokenOverride = null )
		//{
		//	// If we do not have an instance url yet, use the global api instance url.
		//	string instanceUrl = requestHandler.InstanceUrl;
		//	if ( string.IsNullOrWhiteSpace( instanceUrl ) )
		//	{
		//		//instanceUrl = CoreConfig.GlobalApiInstanceUrl;
		//	}

		//	Guid token = requestHandler.AuthenticationToken ?? Guid.Empty;
		//	if ( tokenOverride != null )
		//	{
		//		token = tokenOverride.Value;
		//	}

		//	// Generate our checksum based on the new request, device id & secret.
		//	Guid requestIdentifier = Guid.NewGuid( );
		//	string checkSum = CryptoHelper.GenerateApiSignedHash( requestIdentifier, requestHandler.DeviceIdentifier, requestHandler.Secret );

		//	List<string> allParameters = new List<string> {
		//		$"token={token}",
		//		$"requestIdentifier={requestIdentifier}",
		//		$"deviceIdentifier={requestHandler.DeviceIdentifier}",
		//		$"checksum={checkSum}"
		//	};
		//	allParameters.AddRange( extraParams );

		//	return $"{instanceUrl}Api/{controller}?" + string.Join( "&", allParameters );
		//}

		public class QueryParameters
		{
			[AliasAs( "token" )]
			public string Token { get; set; }
			[AliasAs( "requestIdentifier" )]
			public string RequestIdentifier { get; set; }
			[AliasAs( "deviceIdentifier" )]
			public string DeviceIdentifier { get; set; }
			[AliasAs( "checksum" )]
			public string Checksum { get; set; }

			public void SetupBaseQueryParameters( string token, string requestIdentifier, string deviceIdentifier, string checksum )
			{
				Token = token;
				RequestIdentifier = requestIdentifier;
				DeviceIdentifier = deviceIdentifier;
				Checksum = checksum;
			}
		}
	}
}
