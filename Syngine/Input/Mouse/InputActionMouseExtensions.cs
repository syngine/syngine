using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Syngine.Input.Mouse
{
	/// <summary>
	/// 
	/// </summary>
	public static class InputActionMouseExtensions
	{
		/// <summary>
		/// Determines whether the mouse is with the specified bounds.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="bounds">The bounds.</param>
		/// <returns>
		///   <c>true</c> if the mouse is with the bounds; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsOver(this IInputContext action, Rectangle bounds)
		{
			var state = action.Current.MouseState;
			return bounds.Contains(state.X, state.Y);
		}

		/// <summary>
		/// Determines whether the specified mouse button is down.
		/// </summary>
		/// <param name="action"></param>
		/// <param name="button">The button.</param>
		/// <returns>
		///   <c>true</c> if the specified mouse button is down; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsDown(this IInputContext action, MouseButtons button)
		{
			switch (button)
			{
				case MouseButtons.Middle:
				{
					return action.Current.MouseState.MiddleButton == ButtonState.Pressed;
				}
				case MouseButtons.Right:
				{
					return action.Current.MouseState.RightButton == ButtonState.Pressed;
				}
				case MouseButtons.X1:
				{
					return action.Current.MouseState.XButton1 == ButtonState.Pressed;
				}
				case MouseButtons.X2:
				{
					return action.Current.MouseState.XButton2 == ButtonState.Pressed;
				}
				case MouseButtons.Left:
				default:
				{
					return action.Current.MouseState.LeftButton == ButtonState.Pressed;
				}
			}
		}

		/// <summary>
		/// Determines whether the specified mouse button is down.
		/// </summary>
		/// <param name="action"></param>
		/// <param name="button">The button.</param>
		/// <param name="region"></param>
		/// <returns>
		///   <c>true</c> if the specified mouse button is down; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsDown(this IInputContext action, MouseButtons button, Rectangle region)
		{
		    var state = action.Current.MouseState;
            return action.IsDown(button) && region.Contains(state.X, state.Y);
		}

		/// <summary>
		/// Determines whether the specified mouse button was up and is now pressed.
		/// </summary>
		/// <param name="action"></param>
		/// <param name="button">The button.</param>
		/// <returns>
		///   <c>true</c> if the specified mouse button is down; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPressed(this IInputContext action, MouseButtons button)
		{
			switch (button)
			{
				case MouseButtons.Middle:
				{
					return action.Previous.MouseState.MiddleButton == ButtonState.Released && action.Current.MouseState.MiddleButton == ButtonState.Pressed;
				}
				case MouseButtons.Right:
				{
					return action.Previous.MouseState.RightButton == ButtonState.Released && action.Current.MouseState.RightButton == ButtonState.Pressed;
				}
				case MouseButtons.X1:
				{
					return action.Previous.MouseState.XButton1 == ButtonState.Released && action.Current.MouseState.XButton1 == ButtonState.Pressed;
				}
				case MouseButtons.X2:
				{
					return action.Previous.MouseState.XButton2 == ButtonState.Released && action.Current.MouseState.XButton2 == ButtonState.Pressed;
				}
				case MouseButtons.Left:
				default:
				{
					return action.Previous.MouseState.LeftButton == ButtonState.Released && action.Current.MouseState.LeftButton == ButtonState.Pressed;
				}
			}
		}

		/// <summary>
		/// Determines whether the specified mouse button is down.
		/// </summary>
		/// <param name="action"></param>
		/// <param name="button">The button.</param>
		/// <param name="region"></param>
		/// <returns>
		///   <c>true</c> if the specified mouse button is down; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPressed(this IInputContext action, MouseButtons button, Rectangle region)
		{
			switch (button)
			{
				case MouseButtons.Middle:
				{
					return action.Previous.MouseState.MiddleButton == ButtonState.Released
						&& action.Current.MouseState.MiddleButton == ButtonState.Pressed
						&& region.Contains(action.Current.MouseState.X, action.Current.MouseState.Y);
				}
				case MouseButtons.Right:
				{
					return action.Previous.MouseState.RightButton == ButtonState.Released
						&& action.Current.MouseState.RightButton == ButtonState.Pressed
						&& region.Contains(action.Current.MouseState.X, action.Current.MouseState.Y);
				}
				case MouseButtons.X1:
				{
					return action.Previous.MouseState.XButton1 == ButtonState.Released
						&& action.Current.MouseState.XButton1 == ButtonState.Pressed
						&& region.Contains(action.Current.MouseState.X, action.Current.MouseState.Y);
				}
				case MouseButtons.X2:
				{
					return action.Previous.MouseState.XButton2 == ButtonState.Released
						&& action.Current.MouseState.XButton2 == ButtonState.Pressed
						&& region.Contains(action.Current.MouseState.X, action.Current.MouseState.Y);
				}
				default:
				{
					return action.Previous.MouseState.LeftButton == ButtonState.Released
						&& action.Current.MouseState.LeftButton == ButtonState.Pressed
						&& region.Contains(action.Current.MouseState.X, action.Current.MouseState.Y);
				}
			}
		}

		/// <summary>
		/// Determines whether the mouse button was up and is now down.
		/// </summary>
		/// <param name="action"></param>
		/// <param name="button">The button.</param>
		/// <returns></returns>
		public static bool WasReleased(this IInputContext action, MouseButtons button)
		{
			switch (button)
			{
				case MouseButtons.Middle:
				{
					return action.Previous.MouseState.MiddleButton == ButtonState.Pressed && action.Current.MouseState.MiddleButton == ButtonState.Released;
				}
				case MouseButtons.Right:
				{
					return action.Previous.MouseState.RightButton == ButtonState.Pressed && action.Current.MouseState.RightButton == ButtonState.Released;
				}
				case MouseButtons.X1:
				{
					return action.Previous.MouseState.XButton1 == ButtonState.Pressed && action.Current.MouseState.XButton1 == ButtonState.Released;
				}
				case MouseButtons.X2:
				{
					return action.Previous.MouseState.XButton2 == ButtonState.Pressed && action.Current.MouseState.XButton2 == ButtonState.Released;
				}
				default:
				{
					return action.Previous.MouseState.LeftButton == ButtonState.Pressed && action.Current.MouseState.LeftButton == ButtonState.Released;
				}
			}
		}

	    /// <summary>
	    /// Determines whether the mouse button was down and is now up.
	    /// </summary>
	    /// <param name="action"></param>
	    /// <param name="button">The button.</param>
	    /// <param name="region"></param>
	    /// <returns></returns>
	    public static bool WasReleased(this IInputContext action, MouseButtons button, Rectangle region)
	    {
	        var state = action.Current.MouseState;
            return action.WasReleased(button) && region.Contains(state.X, state.Y);
		}

		/// <summary>
		/// Determines whether the wheel is scrolling.
		/// </summary>
		/// <returns>
		///   <c>true</c> if the wheel is scrolling; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsWheelScrolling(this IInputContext action)
		{
			return action.Current.MouseState.ScrollWheelValue > 0;
		}

		/// <summary>
		/// Determines whether the wheel was scrolled.
		/// </summary>
		/// <returns></returns>
		public static bool WasWheelScrolled(this IInputContext action)
		{
			return action.Previous.MouseState.ScrollWheelValue != 0 && action.Current.MouseState.ScrollWheelValue == 0;
		}
	}
}