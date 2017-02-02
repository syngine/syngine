namespace Syngine.Components
{
	public abstract class Updatable : IUpdate
	{
	    protected Updatable()
	    {
	        Enabled = true;
	    }

	    public bool Enabled { get; set; }

	    public bool IsInitialized { get; protected set; }

		public virtual void Initialize()
		{
			IsInitialized = true;
		}

	    public virtual void Update(UpdateContext context)
	    {
	        if (!GameState.Paused && Enabled)
	        {
	            UpdateCore(context);
	        }
	    }

	    protected abstract void UpdateCore(UpdateContext context);
	}
}
