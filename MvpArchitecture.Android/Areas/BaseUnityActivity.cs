using Android.Support.V7.App;
using MvpArchitecture.Android.Classes;
using MvpArchitecture.Android.Handlers;
using MvpArchitecture.Areas;
using MvpArchitecture.Areas.Contacts;
using MvpArchitecture.Interfaces;
using Unity;

namespace MvpArchitecture.Android.Areas
{
	public abstract class BaseUnityActivity<T> : AppCompatActivity, IBaseView
		where T : BasePresenter
	{
		public T Presenter { get; set; }

		public abstract void RegisterView( );

		public void SetPresenter( )
		{
			RegisterView( );
			App.Container.RegisterInstance<IRequestHandler>( new RequestHandler( this ) );

			Presenter = App.Container.Resolve<T>( );
			Presenter.Start( );
		}
	}
}
