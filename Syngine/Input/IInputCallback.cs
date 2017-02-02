using System;

namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public interface IInputCallback
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        IInputSubscription Call(Action<InputCallbackContext> callback);

        ///// <summary>
        ///// 
        ///// </summary>
        //Action<InputCallbackContext> Callback { get; }

	    InputCallbackContext Invoke(InputCallbackContext context);
	}
}