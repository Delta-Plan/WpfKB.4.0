namespace WpfKb.Helpers
{
	public class LanguageIndexKeeper
	{
		/// <summary>
		/// Английская раскладка
		/// </summary>
		public const int En = 0;

		/// <summary>
		/// Русская раскладка
		/// </summary>
		public const int Ru = 2;

		private int _currentIndex = 0;

		public void Shift()
		{
			_currentIndex = (_currentIndex + 2)%4; // 0 || 2
		}

		public int LanguageIndex { get { return _currentIndex; } }
	}
}
