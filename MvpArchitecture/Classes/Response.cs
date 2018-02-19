using System.Net;
using Refit;

namespace MvpArchitecture.Classes
{
	public class Response<T>
	{
		public bool Success { get; set; }
		public T Model { get; set; }
		public ApiException ApiException { get; set; }
	}
}
