using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Syngine.Components;

namespace Syngine.Input
{
	/// <summary>
	/// Manages user input callbacks and subscriptions.
	/// </summary>
	public class InputManager : IInputManager
    {
		#region Fields

	    public ActionList Actions { get; } = new ActionList();

	    #endregion

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		public InputManager()
		{
		    Enabled = true;
			CurrentState = GetInputState();
		}

		#endregion

		#region Properties

		internal IMouseHandler Mouse { get; private set; }

		internal ITouchHandler Touch { get; private set; }

		internal IKeyboardHandler Keyboard { get; private set; }

		internal IGamePadHandler GamePad { get; private set; }

		private InputState CurrentState { get; set; }

        public bool Enabled { get; set; }

        public bool IsInitialized { get; private set; }

        public ILayer Layer => null;

        #endregion

        #region Methods

        public void Initialize()
        {
            IsInitialized = true;
        }

        public void Update(UpdateContext context)
        {
            if (Enabled)
            {
                var previousState = CurrentState;
                CurrentState = GetInputState();
                var inputContext = new InputContext(CurrentState, previousState);
                Actions.Update(inputContext, new InputCallbackContext(context, CurrentState, previousState));
            }
        }

        /// <summary>
        /// Sets the specified mouse handler to handle user input.
        /// </summary>
        /// <param name="mouse">The mouse handler.</param>
        public void Set(IMouseHandler mouse)
		{
			Mouse = mouse;
		}

		/// <summary>
		/// Sets the specified touch handler to handle user input.
		/// </summary>
		/// <param name="touch">The touch handler.</param>
		public void Set(ITouchHandler touch)
		{
			Touch = touch;
		}

		/// <summary>
		/// Sets the specified keyboard handler to handle user input.
		/// </summary>
		/// <param name="keyboard">The keyboard handler.</param>
		public void Set(IKeyboardHandler keyboard)
		{
			Keyboard = keyboard;
		}

		/// <summary>
		/// Sets the specified game pad handler to handle user input.
		/// </summary>
		/// <param name="gamePad">The game pad handler.</param>
		public void Set(IGamePadHandler gamePad)
		{
			GamePad = gamePad;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public IInputSubscription If(Func<IInputContext, bool> predicate, Action<InputCallbackContext> callback)
		{
            return If(predicate).Call(callback);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IInputCallback If(Func<IInputContext, bool> predicate)
        {
            var subscription = new InputSubscription();
            var callback = new InputCallback(subscription);
            subscription.Action = new InputAction(this, predicate, callback);
            Actions.Add(subscription.Action);
            return callback;
        }

        public IGamePadHandler GetGamePadHandler()
        {
            return GamePad;
        }

        public IKeyboardHandler GetKeyboardHandler()
        {
            return Keyboard;
        }

        public IMouseHandler GetMouseHandler()
        {
            return Mouse;
        }

        public ITouchHandler GetTouchHandler()
        {
            return Touch;
        }

        internal bool Remove(IInputAction action)
        {
            return Actions.Remove(action);
        }

        protected InputState GetInputState()
        {
            return new InputState
            {
                MouseState = Mouse?.GetState() ?? new MouseState(),
                TouchState = Touch?.GetState() ?? new TouchCollection(),
                GamePadState = GamePad?.GetState() ?? new GamePadState(),
                KeyboardState = Keyboard?.GetState() ?? new KeyboardState(),
            };
        }

        public void SetLayer(ILayer layer)
        {
            // Do nothing for the input manager.
        }

        #endregion
    }
}