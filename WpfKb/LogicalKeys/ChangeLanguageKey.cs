using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using WindowsInput;
using WpfKb.Helpers;

namespace WpfKb.LogicalKeys
{
	/// <summary>
	/// Кнопка для смены раскладки
	/// </summary>
	public class ChangeLanguageKey : CaseSensitiveKey
	{
		private readonly LanguageIndexKeeper _indexKeeper = new LanguageIndexKeeper();

		public ChangeLanguageKey(VirtualKeyCode keyCode, IList<string> keyDisplays)
			: base(keyCode, keyDisplays)
		{
		}

		public void InitRussianLayout()
		{
			var current = InputLanguage.CurrentInputLanguage;
			if (current.Culture.LCID == 1033 &&
				_indexKeeper.LanguageIndex == LanguageIndexKeeper.En) // En-us // todo неплохо бы сделать клавиатуру адаптивной под любой набор раскладок...
				Press();
			else if(_indexKeeper.LanguageIndex == LanguageIndexKeeper.En)
				_indexKeeper.Shift();
		}

		public int LanguageIndex { get { return _indexKeeper.LanguageIndex; }}

		public override void Press()
		{
			_indexKeeper.Shift();
			AltShiftPress();
			CtrlShiftPress();
			OnKeyPressed();
		}

		private void AltShiftPress()
		{
			if (InputSimulator.IsKeyDown(VirtualKeyCode.MENU))
			{
				InputSimulator.SimulateKeyPress(VirtualKeyCode.SHIFT);
				InputSimulator.SimulateKeyUp(VirtualKeyCode.MENU);
			}
			else if (InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT))
			{
				InputSimulator.SimulateKeyPress(VirtualKeyCode.MENU);
				InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
			}
			else
			{
				InputSimulator.SimulateKeyDown(VirtualKeyCode.MENU);
				InputSimulator.SimulateKeyPress(VirtualKeyCode.SHIFT);
				InputSimulator.SimulateKeyUp(VirtualKeyCode.MENU);
			}
		}

		private void CtrlShiftPress()
		{
			if (InputSimulator.IsKeyDown(VirtualKeyCode.CONTROL))
			{
				InputSimulator.SimulateKeyPress(VirtualKeyCode.SHIFT);
				InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
			}
			else if (InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT))
			{
				InputSimulator.SimulateKeyPress(VirtualKeyCode.CONTROL);
				InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
			}
			else
			{
				InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
				InputSimulator.SimulateKeyPress(VirtualKeyCode.SHIFT);
				InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
			}
		}
	}
}
