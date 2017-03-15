using System;
using Syngine.Input;
using Syngine.Input.GamePad;
using Syngine.Input.Keyboard;
using Syngine.Input.Mouse;
using Syngine.Input.Touch;

namespace Syngine
{
    public static class GameInput
    {
        public static IInputManager Input { get; } = new InputManager();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IInputCallback If(Func<IInputContext, bool> predicate)
        {
            return Input.If(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IInputSubscription If(Func<IInputContext, bool> predicate, Action<InputCallbackContext> callback)
        {
            return If(predicate).Call(callback);
        }

        public static void Set(ITouchHandler touch)
        {
            Input.Set(touch);
        }

        public static void Set(IMouseHandler mouse)
        {
            Input.Set(mouse);
        }

        public static void Set(IKeyboardHandler keyboard)
        {
            Input.Set(keyboard);
        }

        public static void Set(IGamePadHandler gamePad)
        {
            Input.Set(gamePad);
        }
    }
}