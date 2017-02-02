using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Syngine.Graphics
{
    public class SpriteSheet : TextureAnimation
    {
        public SpriteSheet(string assetName, float frameDuration, Rectangle bounds) : this(assetName, PlayState.Playing, PlayMode.Loop, frameDuration, bounds)
        {
        }

        public SpriteSheet(string assetName, PlayState state, float frameDuration, Rectangle bounds) : this(assetName, state, PlayMode.Loop, frameDuration, bounds)
        {
        }

        public SpriteSheet(string assetName, PlayMode mode, float frameDuration, Rectangle bounds) : this(assetName, PlayState.Playing, mode, frameDuration, bounds)
        {
        }

        public SpriteSheet(string assetName, PlayState state, PlayMode mode, float frameDuration, Rectangle bounds) : base(assetName, state, bounds, Color.White)
        {
            Mode = mode;
            FrameDuration = frameDuration;
        }

        protected List<SpriteFrame> Frames { get; } = new List<SpriteFrame>();

        public float FrameDuration { get; }

        public float FrameTimeCounter { get; set; }

        public SpriteFrame CurrentFrame { get; protected set; }

        protected override void UpdateCore(UpdateContext context)
        {
            base.UpdateCore(context);

            if (Frames.Count == 0) { return; }

            FrameTimeCounter += (float)context.GameTime.ElapsedGameTime.TotalSeconds;

            if (FrameTimeCounter < FrameDuration) { return; }

            FrameTimeCounter -= FrameDuration;

            SetNextFrame();
        }

        public void SetNextFrame()
        {
            var index = CurrentFrame?.Index + 1 ?? 0;

            if (index >= Frames.Count)
            {
                switch (Mode)
                {
                    case PlayMode.Loop:
                    {
                        index = 0;
                        break;
                    }
                    case PlayMode.Single:
                    default:
                    {
                        State = PlayState.Stopped;
                        FrameTimeCounter = 0;
                        break;
                    }
                }
            }

            SetCurrentFrame(index);
        }

        public override void LoadContent(LoadContext context)
        {
            base.LoadContent(context);

            var totalFrames = Asset.Width / Bounds.Width;
            var totalHeight = Asset.Height / Bounds.Height;
            
            for (var h = 0; h < totalHeight; h++)
            {
                for (var i = 0; i < totalFrames; i++)
                {
                    Frames.Add(new SpriteFrame(i, new Rectangle(i * Bounds.Width, h * Bounds.Height, Bounds.Width, Bounds.Height)));
                }
            }
            
            SetCurrentFrame(0);
        }

        public void SetCurrentFrame(int index)
        {
            if (Frames.Count > 0)
            {
                index = Math.Min(index, Frames.Count - 1);
                CurrentFrame = Frames[Math.Max(index, 0)];
                SourceRectangle = CurrentFrame.Bounds;
            }
        }

        public override void Stop()
        {
            base.Stop();

            SetCurrentFrame(0);
            FrameTimeCounter = 0f;
        }
    }
}