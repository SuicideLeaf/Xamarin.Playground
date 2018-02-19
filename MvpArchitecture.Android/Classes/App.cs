using System;
using Android.App;
using Android.Runtime;
using MvpArchitecture.Android.Helpers;
using MvpArchitecture.Areas.Contacts;
using MvpArchitecture.Classes;
using MvpArchitecture.Helpers;
using MvpArchitecture.Interfaces;
using Refit;
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

			PreferencesHelper.SetIsAuthenticated( ApplicationContext, true );
			PreferencesHelper.SetInstanceUrl( ApplicationContext, "http://192.168.108.219:57204/" );

			string instanceUrl = PreferencesHelper.GetIsAuthenticated( ApplicationContext ) ? PreferencesHelper.GetInstanceUrl( ApplicationContext ) : "todo";
			string consumerKey = CoreConfig.TestConsumerKey.ToString( );

			Container = new UnityContainer( );

			Container.RegisterInstance( RestService.For<IApi>( ApiHelper.GetHttpClient( instanceUrl, consumerKey ) ) );
			Container.RegisterType<IContactsDataSource, ContactsApiDataSource>( "ContactsRemoteDataSource" );
			Container.RegisterType<IGetContactsCallback, ContactsViewCallback>( );
			Container.RegisterType<IContactsDataSource, ContactsRepository>( new InjectionConstructor( new ResolvedParameter<IContactsDataSource>( "ContactsRemoteDataSource" ) ) );
		}
	}
}
