namespace Syngine.Components
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILoad
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		void LoadContent(LoadContext context);

		/// <summary>
		/// 
		/// </summary>
		void UnloadContent();
	}
}
