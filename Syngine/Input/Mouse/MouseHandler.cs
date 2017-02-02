using Microsoft.Xna.Framework.Input;

namespace Syngine.Input.Mouse
{
	public class MouseHandler : IMouseHandler
	{
		public MouseState GetState()
		{
			return Microsoft.Xna.Framework.Input.Mouse.GetState();
		}
	}
}