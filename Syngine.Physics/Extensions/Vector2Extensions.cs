using FarseerPhysics;
using Microsoft.Xna.Framework;

namespace Syngine
{
	/// <summary>
	/// 
	/// </summary>
	public static class Vector2Extensions
	{
		/// <summary>
		/// Converts the vector to display units.
		/// </summary>
		/// <param name="vector">The vector to convert.</param>
		/// <returns>The converted vector.</returns>
		public static Vector2 ToDisplayUnits(this Vector2 vector)
		{
			return ConvertUnits.ToDisplayUnits(vector);
		}

		/// <summary>
		/// Converts the vector to simulation units.
		/// </summary>
		/// <param name="vector">The vector to convert.</param>
		/// <returns>The converted vector.</returns>
		public static Vector2 ToSimUnits(this Vector2 vector)
		{
			return ConvertUnits.ToSimUnits(vector);
		}
	}
}