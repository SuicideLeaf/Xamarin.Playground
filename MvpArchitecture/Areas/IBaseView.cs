using System;

namespace MvpArchitecture.Areas
{
	public interface IBaseView
	{
		void RunOnUiThread( Action action );
		void SetPresenter( );
	}
}
