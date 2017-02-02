using Microsoft.Xna.Framework.Input;

namespace Syngine.Input.Keyboard
{
	public class KeyboardHandler : IKeyboardHandler
	{
		public KeyboardState GetState()
		{
			return Microsoft.Xna.Framework.Input.Keyboard.GetState();
		}
	}
}