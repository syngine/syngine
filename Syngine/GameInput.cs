using System;
using Syngine.Input;

namespace Syngine
{
    public static class GameInput
    {
        public static InputManager Input { get; } = new InputManager();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IInputCallback If(Func<IInputContext, bool> predicate)
        {
            return Input.If(predicate);
        }
    }
}