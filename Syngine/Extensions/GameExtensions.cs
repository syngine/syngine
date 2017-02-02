using Microsoft.Xna.Framework;
using Syngine.Controllers;

namespace Syngine
{
    public static class GameExtensions
    {
        public static void AddController(this Game game, IController controller)
        {
            game.Components.Add(controller);
        }
    }
}