namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public struct InputContext : IInputContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InputContext"/> struct.
		/// </summary>
		/// <param name="current">The current.</param>
		/// <param name="previous">The previous.</param>
		public InputContext(InputState current, InputState previous) : this()
		{
			Current = current;
			Previous = previous;
		}

		/// <summary>
		/// Gets the current input state.
		/// </summary>
		public InputState Current { get; }

		/// <summary>
		/// Gets the previous input state.
		/// </summary>
		public InputState Previous { get; }
	}
}