namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public class InputCallbackContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InputCallbackContext"/> struct.
		/// </summary>
		/// <param name="context">The current update context.</param>
		/// <param name="current">The current input state.</param>
		/// <param name="previous">The previous input state.</param>
		public InputCallbackContext(UpdateContext context, InputState current, InputState previous)// : this()
		{
			Context = context;
			Current = current;
			Previous = previous;
		}

	    public bool Handled { get; set; }

		public InputState Current { get; private set; }

		public InputState Previous { get; private set; }

		public UpdateContext Context { get; private set; }
	}
}