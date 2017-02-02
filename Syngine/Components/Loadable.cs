using System;

namespace Syngine.Components
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Loadable : Updatable, ILoad
    {
        public string Name { get; set; }

        public abstract void LoadContent(LoadContext context);

        public abstract void UnloadContent();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Loadable<TAsset> : Loadable
    {
        protected Loadable()
        {
        }

        protected Loadable(string assetName) : this()
        {
            Name = assetName;
            AssetName = assetName;
        }

        public string AssetName { get; protected set; }

        public TAsset Asset { get; protected set; }

        public override void Initialize()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = AssetName;
            }

            base.Initialize();
        }

        public override void LoadContent(LoadContext context)
	    {
	        if (!string.IsNullOrEmpty(AssetName))
	        {
	            Asset = context.Load<TAsset>(AssetName);
	        }
	    }

	    public override void UnloadContent()
	    {
            (Asset as IDisposable)?.Dispose();
	    }
    }
}