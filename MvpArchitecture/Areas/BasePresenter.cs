using System.Threading.Tasks;

namespace MvpArchitecture.Areas
{
	public abstract class BasePresenter : IBasePresenter
	{
		public IBaseView View { get; set; }
		public abstract Task Start( );

		protected internal BasePresenter( IBaseView view )
		{
			View = view;
		}
	}

	public abstract class BasePresenter<V> : BasePresenter
		where V : IBaseView
	{
		protected internal BasePresenter( V view ) : base( view ) { }

		public new V View
		{
			get
			{
				return ( V )base.View;
			}
			set
			{
				base.View = value;
			}
		}
	}
}
