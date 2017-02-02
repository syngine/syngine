using System.Linq;
using Microsoft.Xna.Framework;

namespace Syngine.Input.Touch
{
	public static class InputActionTouchExtensions
	{
		public static bool IsTouching(this IInputContext action)
		{
			return action.Current.TouchState.Count > 0;
		}

		public static bool IsTouching(this IInputContext action, Rectangle bounds)
		{
			return IsTouching(action) && action.Current.TouchState.Any(p => bounds.Contains(p.Position));
		}
	}
}