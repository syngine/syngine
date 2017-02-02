namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public interface IHandleInput
	{
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TState"></typeparam>
	public interface IHandleInput<out TState> : IHandleInput
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		TState GetState();
	}

	///// <summary>
	///// 
	///// </summary>
	//public interface IUserInputHandler : IHandleInput<InputState>
	//{
	//}
}