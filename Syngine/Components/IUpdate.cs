using Microsoft.Xna.Framework;

namespace Syngine.Components
{
	/// <summary>
	/// 
	/// </summary>
	public interface IUpdate
	{
	    bool Enabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		bool IsInitialized { get; }

        ILayer Layer { get; }

        /// <summary>
        /// 
        /// </summary>
        void Initialize();

        void SetLayer(ILayer layer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        void Update(UpdateContext context);
    }
}