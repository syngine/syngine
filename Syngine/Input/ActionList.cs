using System.Collections.Generic;

namespace Syngine.Input
{
	public class ActionList : List<IInputAction>
	{
		public void Update(IInputContext inputContext, InputCallbackContext callbackContext)
		{
			for (var i = 0; i < Count; i++)
			{
				if (this[i].Enabled && this[i].Condition(inputContext))
				{
					this[i].Notify(callbackContext);

				    if (callbackContext.Handled)
				    {
				        break;
				    }
				}
			}
		}
	}
}
