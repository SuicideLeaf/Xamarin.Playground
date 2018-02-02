namespace MvpArchitecture.Classes
{
	public static class CoreConstants
	{
		public static class FormattingConstants
		{
			public const string Currency = "C";
			public const string Dashes = "D";
			public const string Date = "dd MMMM yyyy";
			public const string DateWithoutYear = "dd MMMM";
			public const string Time = "hh:mm tt";
			public const string TwoDecimalPlace = "N2";
		}

		public static class TimeoutConstants
		{
			public const int FileUploadSeconds = 180;
			public const int ConnectionSeconds = 45;
		}
	}
}
