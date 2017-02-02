namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public interface IInputContext
	{
		/// <summary>
		/// Gets the current input state.
		/// </summary>
		InputState Current { get; }

		/// <summary>
		/// Gets the previous input state.
		/// </summary>
		InputState Previous { get; }
	}
}