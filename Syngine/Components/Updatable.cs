using System;
using Syngine.Input;

namespace Syngine.Components
{
	public abstract class Updatable : IUpdate
	{
	    protected Updatable()
	    {
	        Enabled = true;
	    }

        protected IInputManager Input { get; } = new InputManager();

        /// <summary>
        /// 
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
	    public bool IsInitialized { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public ILayer Layer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Initialize()
		{
            Input.Initialize();
            Input.Set(GameInput.Input.GetMouseHandler());
            Input.Set(GameInput.Input.GetKeyboardHandler());
            Input.Set(GameInput.Input.GetTouchHandler());
            Input.Set(GameInput.Input.GetGamePadHandler());
            IsInitialized = true;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
	    public virtual void Update(UpdateContext context)
	    {
	        if (!GameState.Paused && Enabled)
            {
                Input.Update(context);

                UpdateCore(context);
	        }
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
	    protected abstract void UpdateCore(UpdateContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
	    public void SetLayer(ILayer layer)
	    {
	        if (layer == null)
	        {
	            throw new ArgumentNullException(nameof(layer));
	        }

            if (Layer != null && Layer != layer)
            {
                throw new ArgumentException("An IUpdate can only belong to one layer.");
            }

            Layer = layer;
	    }
	}
}
