using Microsoft.Xna.Framework;

namespace Syngine.Graphics
{
    public abstract class TextureAnimation : DrawableTexture, IAnimation
    {
        protected TextureAnimation()
        {
        }

        protected TextureAnimation(string assetName, Rectangle bounds) : base(assetName, bounds)
        {
            State = PlayState.Playing;
        }

        protected TextureAnimation(string assetName, PlayState state, Rectangle bounds) : base(assetName, bounds)
        {
            State = state;
        }

        protected TextureAnimation(string assetName, PlayState state, Rectangle bounds, Color color) : base(assetName, bounds, color)
        {
            State = state;
        }
        
        public PlayMode Mode { get; set; }

        public PlayState State { get; protected set; }

        public override void Update(UpdateContext context)
        {
            if (State == PlayState.Playing)
            {
                base.Update(context);
            }
        }

        public virtual void Stop()
        {
            State = PlayState.Stopped;
        }

        public virtual void Pause()
        {
            State = PlayState.Paused;
        }

        public virtual void Play()
        {
            State = PlayState.Playing;
        }
    }
}