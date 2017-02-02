using System;

namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public class InputAction : IInputAction
	{
	    /// <summary>
	    /// Initializes a new instance of the <see cref="InputAction"/> class.
	    /// </summary>
	    /// <param name="input">The input.</param>
	    /// <param name="condition">The condition.</param>
	    /// <param name="callback">The callback.</param>
	    public InputAction(InputManager input, Func<IInputContext, bool> condition, IInputCallback callback)
		{
			Enabled = true;
			Input = input;
			Condition = condition;
			Callback = callback;
		    //subscription.Action = this;
            //Subscription = subscription;
        }

		public bool Enabled { get; set; }

		public InputManager Input { get; }

		public IInputCallback Callback { get; }

	    //public IInputSubscription Subscription { get; }

	    public Func<IInputContext, bool> Condition { get; }

		/// <summary>
		/// Removes this instance from the input loop.
		/// </summary>
		public bool Remove()
		{
			return Input.Remove(this);
        }

        public InputCallbackContext Notify(InputCallbackContext context)
        {
            Callback?.Invoke(context);

            return context;
        }
    }
}