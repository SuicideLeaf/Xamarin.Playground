namespace MvpArchitecture.Areas
{
	public abstract class BasePresenter
	{
		public IBaseView View { get; set; }
		public abstract void Start( );

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
