using System;
using Android.App;
using Android.Runtime;
using MvpArchitecture.Areas.Contacts;
using Unity;
using Unity.Injection;
using static MvpArchitecture.Areas.Contacts.ContactsContract.Data;

namespace MvpArchitecture.Android.Classes
{
	[Application]
	public class App : Application
	{
		public static UnityContainer Container { get; set; }

		public App( IntPtr javaRef, JniHandleOwnership transfer ) : base( javaRef, transfer ) { }

		public override void OnCreate( )
		{
			base.OnCreate( );

			Container = new UnityContainer( );

			Container.RegisterType<IContactsDataSource, ContactsApiDataSource>( "ContactsRemoteDataSource" );
			Container.RegisterType<IGetContactsCallback, ContactsViewCallback>( );
			Container.RegisterType<IContactsDataSource, ContactsRepository>( new InjectionConstructor( new ResolvedParameter<IContactsDataSource>( "ContactsRemoteDataSource" ) ) );
		}
	}
}
