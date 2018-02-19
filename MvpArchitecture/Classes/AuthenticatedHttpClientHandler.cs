using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MvpArchitecture.Classes
{
	public class AuthenticatedHttpClientHandler : HttpClientHandler
	{
		private readonly string _consumerKey;

		public AuthenticatedHttpClientHandler( string consumerKey )
		{
			_consumerKey = consumerKey;
		}

		protected override async Task<HttpResponseMessage> SendAsync( HttpRequestMessage request, CancellationToken cancellationToken )
		{
			// See if the request has an authorize header
			AuthenticationHeaderValue auth = request.Headers.Authorization;
			if ( auth != null )
			{
				request.Headers.Authorization = new AuthenticationHeaderValue( auth.Scheme, _consumerKey );
			}

			//try
			//{
				return await base.SendAsync( request, cancellationToken ).ConfigureAwait( false );
			//}
			//catch ( Exception ) // Todo better exception handling here, this is too generic.
			//{
			//	return new HttpResponseMessage( HttpStatusCode.ServiceUnavailable );
			//}
		}
	}
}
