using System;
using static MvpArchitecture.Helpers.ApiHelper;

namespace MvpArchitecture.Areas
{
	public interface IBaseView
	{
		void RunOnUiThread( Action action );
		void SetPresenter( );
	}
}
