using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace Syngine.Input.Keyboard
{
	/// <summary>
	/// 
	/// </summary>
	public static class InputActionKeyboardExtensions
	{
		/// <summary>
		/// Determines whether [is key down] [the specified key].
		/// </summary>
		/// <param name="context"></param>
		/// <param name="key">The key.</param>
		/// <returns>
		///   <c>true</c> if [is key down] [the specified key]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsDown(this IInputContext context, Keys key)
		{
			return context.Current.KeyboardState.IsKeyDown(key);
		}

		/// <summary>
		/// Determines whether the key was up and is now pressed.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="key">The key.</param>
		/// <returns>True if the key was pressed; false otherwise.</returns>
		public static bool WasPressed(this IInputContext context, Keys key)
		{
			return context.Previous.KeyboardState.IsKeyUp(key) && context.Current.KeyboardState.IsKeyDown(key);
		}

		/// <summary>
		/// Determines whether the key was pressed.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="key">The key.</param>
		/// <returns>True if the key was pressed; false otherwise.</returns>
		public static bool WasReleased(this IInputContext context, Keys key)
		{
			return context.Previous.KeyboardState.IsKeyDown(key) && context.Current.KeyboardState.IsKeyUp(key);
		}

		/// <summary>
		/// Determines whether the keys are down.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="keys">The keys.</param>
		/// <returns></returns>
		public static bool AreDown(this IInputContext context, params Keys[] keys)
		{
		    if (keys.Length == 0)
		    {
		        return false;
		    }

		    var pressedKeys = context.Current.KeyboardState.GetPressedKeys();

		    if (keys.Length > pressedKeys.Length)
		    {
		        return false;
		    }

		    return !keys.Any(key => !pressedKeys.Contains(key));
		}

		/// <summary>
		/// Determines whether the keys were pressed.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="keys">The keys.</param>
		/// <returns></returns>
		public static bool WerePressed(this IInputContext context, params Keys[] keys)
        {
            if (keys.Length == 0)
            {
                return false;
            }

            var previousKeys = context.Previous.KeyboardState.GetPressedKeys();

            if (keys.Length > previousKeys.Length)
            {
                return false;
            }

            var currentKeys = context.Current.KeyboardState.GetPressedKeys();
            return !keys.Any(key => !previousKeys.Contains(key)) && !keys.Any(key => currentKeys.Contains(key));
        }

		///// <summary>
		///// Determines whether the keys were pressed.
		///// </summary>
		///// <param name="context"></param>
		///// <param name="keys">The keys.</param>
		///// <param name="duration">The duration.</param>
		///// <returns></returns>
		//public static bool WerePressed(this IInputContext context, Keys[] keys, float duration)
		//{
		//	return false;
		//}

		///// <summary>
		///// Determines whether the keys were pressed.
		///// </summary>
		///// <param name="context"></param>
		///// <param name="keys">The keys.</param>
		///// <param name="duration">The duration.</param>
		///// <param name="inOrder">if set to <c>true</c> [in order].</param>
		///// <returns></returns>
		//public static bool WerePressed(this IInputContext context, Keys[] keys, float duration, bool inOrder)
		//{
		//	return false;
		//}
	}
}