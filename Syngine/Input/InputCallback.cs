using System;

namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public class InputCallback : IInputCallback
	{
	    public InputCallback(IInputSubscription subscription)
	    {
	        Subscription = subscription;
	    }

	    public IInputSubscription Subscription { get; }

	    public Action<InputCallbackContext> Callback { get; private set; }
        
		public IInputSubscription Call(Action<InputCallbackContext> callback)
		{
		    Callback = callback;
		    return Subscription;
		}

	    public InputCallbackContext Invoke(InputCallbackContext context)
	    {
            Callback(context);
	        return context;
	    }
	}
}