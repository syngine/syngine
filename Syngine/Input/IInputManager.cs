using Syngine.Components;
using System;

namespace Syngine.Input
{
    public interface IInputManager : IUpdate
    {
        ActionList Actions { get; }

        IInputCallback If(Func<IInputContext, bool> predicate);

        IInputSubscription If(Func<IInputContext, bool> predicate, Action<InputCallbackContext> callback);

        void Set(IGamePadHandler gamePad);

        void Set(IKeyboardHandler keyboard);

        void Set(IMouseHandler mouse);

        void Set(ITouchHandler touch);

        IGamePadHandler GetGamePadHandler();

        IKeyboardHandler GetKeyboardHandler();

        IMouseHandler GetMouseHandler();

        ITouchHandler GetTouchHandler();
    }
}