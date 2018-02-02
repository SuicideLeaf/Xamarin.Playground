using System;
using Android.Content;
using Android.Preferences;
using MvpArchitecture.Android.Classes;

namespace MvpArchitecture.Android.Helpers
{
	public static class PreferencesHelper
	{
		private const string ProfileNameKey = "ProfileNameKey";

		public static Guid? GetAuthenticationToken( Context context )
		{
			Guid token;
			Guid.TryParse( GetSharedPreferenceString( context, Constants.PreferenceKeys.AuthTokenKey, string.Empty ), out token );

			return token == Guid.Empty ? ( Guid? )null : token;
		}

		public static bool GetIsAuthenticated( Context context )
			=> GetSharedPreferenceBoolean( context, Constants.PreferenceKeys.IsAuthenticatedKey, false );

		public static string GetInstanceUrl( Context context )
			=> GetSharedPreferenceString( context, Constants.PreferenceKeys.InstanceUrlKey, string.Empty );

		public static void SetAuthenticationToken( Context context, Guid token )
		{
			SetSharedPreferenceString( context, Constants.PreferenceKeys.AuthTokenKey, token.ToString( ) );
		}

		public static void SetIsAuthenticated( Context context, bool isAuthenticated )
		{
			SetSharedPreferenceBoolean( context, Constants.PreferenceKeys.IsAuthenticatedKey, isAuthenticated );
		}

		public static void SetInstanceUrl( Context context, string endPoint )
		{
			SetSharedPreferenceString( context, Constants.PreferenceKeys.InstanceUrlKey, endPoint );
		}

		/// <summary>
		/// Set a string shared preference
		/// </summary>
		/// <param name="context">Context used to intialise the shared preferences.</param>
		/// <param name="key">Key to set shared preference.</param>
		/// <param name="value">Value for the key.</param>
		public static void SetSharedPreferenceString( Context context, string key, string value )
		{
			ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences( context );
			ISharedPreferencesEditor editor = settings.Edit( );
			editor.PutString( key, value );
			editor.Apply( );
		}

		/// <summary>
		/// Set an integer shared preference
		/// </summary>
		/// <param name="context">Context used to intialise the shared preferences.</param>
		/// <param name="key">Key to set shared preference.</param>
		/// <param name="value">Value for the key.</param>
		public static void SetSharedPreferenceInt( Context context, string key, int value )
		{
			ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences( context );
			ISharedPreferencesEditor editor = settings.Edit( );
			editor.PutInt( key, value );
			editor.Apply( );
		}

		/// <summary>
		/// Set a boolean shared preference
		/// </summary>
		/// <param name="context">Context used to intialise the shared preferences.</param>
		/// <param name="key">Key to set shared preference.</param>
		/// <param name="value">Value for the key.</param>
		public static void SetSharedPreferenceBoolean( Context context, string key, bool value )
		{
			ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences( context );
			ISharedPreferencesEditor editor = settings.Edit( );
			editor.PutBoolean( key, value );
			editor.Apply( );
		}

		/// <summary>
		/// Get a string shared preference
		/// </summary>
		/// <param name="context">Context used to intialise the shared preferences.</param>
		/// <param name="key">Key to look up in shared preferences.</param>
		/// <param name="defValue">Default value to be returned if shared preference isn't found.</param>
		public static string GetSharedPreferenceString( Context context, string key, string defValue )
		{
			ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences( context );
			return settings.GetString( key, defValue );
		}

		/// <summary>
		/// Get an integer shared preference
		/// </summary>
		/// <param name="context">Context used to intialise the shared preferences.</param>
		/// <param name="key">Key to look up in shared preferences.</param>
		/// <param name="defValue">Default value to be returned if shared preference isn't found.</param>
		public static int GetSharedPreferenceInt( Context context, string key, int defValue )
		{
			ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences( context );
			return settings.GetInt( key, defValue );
		}

		/// <summary>
		/// Get a boolean shared preference
		/// </summary>
		/// <param name="context">Context used to intialise the shared preferences.</param>
		/// <param name="key">Key to look up in shared preferences.</param>
		/// <param name="defValue">Default value to be returned if shared preference isn't found.</param>
		public static bool GetSharedPreferenceBoolean( Context context, string key, bool defValue )
		{
			ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences( context );
			return settings.GetBoolean( key, defValue );
		}

		public static void ClearSharedPreference( Context context, string key )
		{
			ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences( context );
			ISharedPreferencesEditor editor = settings.Edit( );
			editor.Remove( key );
			editor.Apply( );
		}
	}
}
