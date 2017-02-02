using Microsoft.Xna.Framework.Input.Touch;

namespace Syngine.Input.Touch
{
	public class TouchHandler : ITouchHandler
	{
		public TouchCollection GetState()
		{
			return TouchPanel.GetState();
		}
	}
}