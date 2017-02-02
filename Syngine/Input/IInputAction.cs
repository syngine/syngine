using System;

namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public interface IInputAction
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="IInputAction"/> is enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if enabled; otherwise, <c>false</c>.
		/// </value>
		bool Enabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		InputManager Input { get; }
		
		/// <summary>
		/// 
		/// </summary>
		Func<IInputContext, bool> Condition { get; }

		/// <summary>
		/// 
		/// </summary>
		IInputCallback Callback { get; }

        ///// <summary>
        ///// 
        ///// </summary>
        //IInputSubscription Subscription { get; }

        /// <summary>
        /// Removes this instance from the input loop.
        /// </summary>
        bool Remove();

        InputCallbackContext Notify(InputCallbackContext context);
    }
}