using System;

namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	[Flags]
	public enum InputType
	{
		/// <summary>
		/// 
		/// </summary>
		Unknown = 1,

		/// <summary>
		/// 
		/// </summary>
		Mouse = 2,

		/// <summary>
		/// 
		/// </summary>
		Touch = 4,

		/// <summary>
		/// 
		/// </summary>
		GamePad = 8,

		/// <summary>
		/// 
		/// </summary>
		Keyboard = 16,
	}
}