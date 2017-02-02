using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public interface IGamePadHandler : IHandleInput<GamePadState>
	{
		GamePadState GetState(PlayerIndex index);
	}
}