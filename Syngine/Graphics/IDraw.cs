using Syngine.Components;

namespace Syngine.Graphics
{
	/// <summary>
	/// 
	/// </summary>
	public interface IDraw : IUpdate, ILoad
	{
		/// <summary>
		/// 
		/// </summary>
		bool Visible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		void Draw(DrawContext context);
	}
}