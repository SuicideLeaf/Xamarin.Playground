namespace MvpArchitecture.Areas
{
	public enum DataError
	{
		None = 0,
		Connection = 1,
		NotFound = 2
	}

	public interface IBaseCallback
	{
		void OnDataNotAvailable( );
	}
}
