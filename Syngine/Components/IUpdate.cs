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

		/// <summary>
		/// 
		/// </summary>
		void Initialize();
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		void Update(UpdateContext context);
	}
}