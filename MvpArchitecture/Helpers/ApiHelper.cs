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

namespace MvpArchitecture.Helpers
{
	public static class ApiHelper
	{
		private static HttpClient GetHttpClient( Guid consumerKey, string mediaType, int timeoutSeconds )
		{
			HttpClient httpClient = new HttpClient( );

			httpClient.DefaultRequestHeaders.Accept.Clear( );
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", consumerKey.ToString( CoreConstants.FormattingConstants.Dashes ) );

			if ( !string.IsNullOrWhiteSpace( mediaType ) )
			{
				httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( mediaType ) );
			}

			httpClient.Timeout = TimeSpan.FromSeconds( timeoutSeconds );

			return httpClient;
		}

		public static async Task<Response<TOutputModel>> GetAsync<TOutputModel>( string endPoint, Guid consumerKey, CancellationToken ct = default( CancellationToken ) )
		{
			Response<TOutputModel> responseModel;

			using ( HttpClient httpClient = GetHttpClient( consumerKey, "application/json", CoreConstants.TimeoutConstants.ConnectionSeconds ) )
			{
				try
				{
					await Task.Delay( 150 );
					HttpResponseMessage response = await httpClient.GetAsync( endPoint, ct );

					if ( response.IsSuccessStatusCode )
					{
						string json = await response.Content.ReadAsStringAsync( );
						TOutputModel model = JsonConvert.DeserializeObject<TOutputModel>( json );
						responseModel = new Response<TOutputModel>( model, response.StatusCode, true );
					}
					else
					{
						responseModel = new Response<TOutputModel>( default( TOutputModel ), response.StatusCode, false );
					}
				}
				catch ( Exception )
				{
					responseModel = new Response<TOutputModel>( default( TOutputModel ), HttpStatusCode.ServiceUnavailable, false );
				}
			}

			return responseModel;
		}

		public static string GetEndPoint( IRequestHandler requestHandler, string controller, string[ ] extraParams, Guid? tokenOverride = null )
		{
			// If we do not have an instance url yet, use the global api instance url.
			string instanceUrl = requestHandler.InstanceUrl;
			if ( string.IsNullOrWhiteSpace( instanceUrl ) )
			{
				//instanceUrl = CoreConfig.GlobalApiInstanceUrl;
			}

			Guid token = requestHandler.AuthenticationToken ?? Guid.Empty;
			if ( tokenOverride != null )
			{
				token = tokenOverride.Value;
			}

			// Generate our checksum based on the new request, device id & secret.
			Guid requestIdentifier = Guid.NewGuid( );
			string checkSum = CryptoHelper.GenerateApiSignedHash( requestIdentifier, requestHandler.DeviceIdentifier, requestHandler.Secret );

			List<string> allParameters = new List<string> {
				$"token={token}",
				$"requestIdentifier={requestIdentifier}",
				$"deviceIdentifier={requestHandler.DeviceIdentifier}",
				$"checksum={checkSum}"
			};
			allParameters.AddRange( extraParams );

			return $"{instanceUrl}Api/{controller}?" + string.Join( "&", allParameters );
		}
	}
}
