using Microsoft.Xna.Framework;
using Syngine.Graphics;

namespace Syngine.Components
{
	public class FpsCounter : DrawableString
    {
        private float _updateInterval = 1.0f;
		private float _timeSinceLastUpdate;
		private float _frameCount;
		private float _fps = 60;

		public FpsCounter(string assetName, Vector2 position) : this(assetName, position, Color.White)
		{
		}

	    public FpsCounter(string assetName, Vector2 position, Color color) : base(assetName, position, string.Empty, color)
	    {
	    }

	    /// <summary>
		/// The frames per second.
		/// </summary>
		public float Fps => _fps;

		protected override void UpdateCore(UpdateContext context)
        {
            base.UpdateCore(context);

            _frameCount++;
            _timeSinceLastUpdate += (float)context.GameTime.ElapsedGameTime.TotalSeconds;

            if (_timeSinceLastUpdate > _updateInterval)
            {
                _fps = _frameCount / _timeSinceLastUpdate;
                _timeSinceLastUpdate -= _updateInterval;
                _frameCount = 0;
                Text = $"FPS: {_fps}";
            }
        }
	}
}
