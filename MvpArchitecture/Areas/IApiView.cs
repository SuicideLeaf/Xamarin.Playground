namespace MvpArchitecture.Areas
{
	public interface IApiView<TParams> : IBaseView
	{
		TParams QueryParameters { get; set; }
	}
}
