using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Syngine.Input.GamePad
{
	public class GamePadHandler : IGamePadHandler
	{
		public GamePadState GetState()
		{
			return GetState(PlayerIndex.One);
		}

		public GamePadState GetState(PlayerIndex index)
		{
			return Microsoft.Xna.Framework.Input.GamePad.GetState(index);
		}
	}
}