using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Syngine.Graphics
{
    public class SpriteBook : Drawable, IAnimation, IEnumerable<SpriteSheet>
    {
        public PlayState State => CurrentSheet?.State ?? PlayState.Playing;

        public PlayMode Mode => CurrentSheet?.Mode ?? PlayMode.Loop;

        public SpriteSheet CurrentSheet { get; protected set; }

        protected Dictionary<string, SpriteSheet> Sheets { get; } = new Dictionary<string, SpriteSheet>();

        protected override void UpdateCore(UpdateContext context)
        {
            CurrentSheet?.Update(context);
        }

        public override void LoadContent(LoadContext context)
        {
            foreach (var sheet in Sheets.Values)
            {
                sheet.LoadContent(context);
            }
        }

        public override void UnloadContent()
        {
            foreach (var sheet in Sheets)
            {
                sheet.Value.UnloadContent();
            }
        }

        protected override void DrawCore(DrawContext context)
        {
            CurrentSheet?.Draw(context);
        }

        public void Stop()
        {
            CurrentSheet?.Stop();
        }

        public void Pause()
        {
            CurrentSheet?.Pause();
        }

        public void Play()
        {
            CurrentSheet?.Play();
        }

        public IEnumerator<SpriteSheet> GetEnumerator()
        {
            return Sheets.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void SetCurrentSheet(string name)
        {
            name = (name ?? string.Empty).ToLower();

            if (Sheets.ContainsKey(name))
            {
                CurrentSheet = Sheets[name];
            }
        }

        public void Add(string name, SpriteSheet sheet)
        {
            name = (name ?? string.Empty).ToLower();

            if (!string.IsNullOrEmpty(name))
            {
                if (!sheet.IsInitialized && IsInitialized)
                {
                    sheet.Initialize();
                    sheet.LoadContent(GameContext.CreateLoadContext());
                }

                Sheets[name] = sheet;
            }
        }

        public void Add(string name, string assetName, PlayState state, PlayMode mode, float frameDuration, Rectangle bounds)
        {
            Add(name ?? assetName, new SpriteSheet(assetName, state, mode, frameDuration, bounds));
        }

        public void Add(string name, string assetName, PlayMode mode, float frameDuration, Rectangle bounds)
        {
            Add(name ?? assetName, new SpriteSheet(assetName, mode, frameDuration, bounds));
        }

        public void Set(Vector2 position, float rotation)
        {
            foreach (var sheet in Sheets.Values)
            {
                sheet.SetPosition(position);
                sheet.Rotation = rotation;
            }
        }

        public void SetPosition(Vector2 position)
        {
            foreach (var sheet in Sheets.Values)
            {
                sheet.SetPosition(position);
            }
        }

        public void SetRotation(float rotation)
        {
            foreach (var sheet in Sheets.Values)
            {
                sheet.Rotation = rotation;
            }
        }
    }
}
