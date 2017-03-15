using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syngine.Components;

namespace Syngine.Graphics
{
	/// <summary>
	/// 
	/// </summary>
	public class ParticleSystem : Drawable, IAnimation
	{
		private readonly List<Particle> _particles = new List<Particle>();
		private int _spawnedPerSecondCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParticleSystem"/> class.
        /// </summary>
        /// <param name="spawnsPerSecond">The spawns per second.</param>
        /// <param name="lifeTime">The life time.</param>
        public ParticleSystem(float spawnsPerSecond, float lifeTime = float.MaxValue)
        {
            SpawnsPerSecond = spawnsPerSecond;
            LifeTime = lifeTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParticleSystem"/> class.
        /// </summary>
        /// <param name="textures"></param>
        /// <param name="spawnsPerSecond">The spawns per second.</param>
        /// <param name="lifeTime">The life time.</param>
        public ParticleSystem(string[] textures, float spawnsPerSecond = 60, float lifeTime = float.MaxValue) : this(spawnsPerSecond, lifeTime)
        {
            TextureNames = textures;
        }

	    /// <summary>
	    /// Initializes a new instance of the <see cref="ParticleSystem"/> class.
	    /// </summary>
	    /// <param name="settings"></param>
	    /// <param name="textures"></param>
	    /// <param name="spawnsPerSecond">The spawns per second.</param>
	    /// <param name="lifeTime">The life time.</param>
	    public ParticleSystem(ParticleSettings settings, string[] textures, float spawnsPerSecond = 60, float lifeTime = float.MaxValue) : this(textures, spawnsPerSecond, lifeTime)
        {
            ParticleFactory = new DefaultParticleFactory(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        public float LifeTime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ParticleEmitter Emitter { get; set; }

        /// <summary>
        /// 
        /// </summary>
	    public Texture2D[] Textures { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] TextureNames { get; }

        /// <summary>
        /// Determines how many particles will spawn per second.
        /// </summary>
        public float SpawnsPerSecond { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private float SecondTimer { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private float LifeTimer { get; set; }

        /// <summary>
        /// 
        /// </summary>
	    public PlayMode Mode { get; set; }

	    /// <summary>
		/// 
		/// </summary>
		public PlayState State { get; private set; }

        public ITextureSelector TextureSelector { get; set; }

        public IParticleFactory ParticleFactory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Play()
		{
			State = PlayState.Playing;
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void Stop()
		{
			LifeTimer = 0;
			SecondTimer = 0;
			_particles.Clear();
			_spawnedPerSecondCount = 0;
			State = PlayState.Stopped;
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void Pause()
		{
			State = (State == PlayState.Playing) ? PlayState.Paused : PlayState.Playing;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            if (Emitter == null)
            {
                var viewPort = GameContext.Game.GraphicsDevice.Viewport;
                Emitter = new ParticleEmitter(
                    new Rectangle(viewPort.Width / 2 - 250, viewPort.Height / 2 - 250, 500, 500),
                    new Vector2(-50, -100),
                    new Vector2(50, 100)
                );
            }

            if (TextureSelector == null)
            {
                TextureSelector = new RandomTextureSelector();
            }

            if (ParticleFactory == null)
            {
                ParticleFactory = new DefaultParticleFactory(Vector2.Zero, Vector2.Zero, 2.0f, 10.0f);
            }

            base.Initialize();
        }

	    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void LoadContent(LoadContext context)
        {
            var textureNames = TextureNames;

            if (textureNames != null && textureNames.Length > 0)
		    {
                var textures = new List<Texture2D>(textureNames.Length);

                foreach (var textureName in textureNames)
                {
                    textures.Add(context.Load<Texture2D>(textureName));
                }

		        Textures = textures.ToArray();
		    }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		protected override void UpdateCore(UpdateContext context)
		{
		    if (State != PlayState.Playing)
		    {
		        return;
		    }

		    var elapsedTime = (float)context.GameTime.ElapsedGameTime.TotalSeconds;
		    LifeTimer += elapsedTime;

		    if (LifeTimer >= LifeTime)
		    {
		        Stop();
		        return;
            }

            SecondTimer += elapsedTime;

            if (SecondTimer > 1.0f)
		    {
		        SecondTimer -= 1.0f;
		        _spawnedPerSecondCount = 0;
		    }
			
		    var particlesToSpawn = Math.Floor((SpawnsPerSecond * SecondTimer) - _spawnedPerSecondCount);
				
		    EmitParticles(particlesToSpawn);

		    _spawnedPerSecondCount += (int)particlesToSpawn;

		    UpdateParticles(context);
		}

		private void UpdateParticles(UpdateContext context)
		{
			for (int i = 0; i < _particles.Count; i++)
			{
				if (_particles[i].IsDead)
				{
					_particles.RemoveAt(i--);
					continue;
				}

				_particles[i].Update(context);
			}
		}

		private void EmitParticles(double particlesToSpawn)
		{
		    var context = GameContext.CreateLoadContext();

			for (int i = 0; i < particlesToSpawn; i++)
			{
			    var particle = ParticleFactory.Create(GetTexture());
                
                _particles.Add(particle);

				Emitter.Emit(particle, context);
			}
		}

        private Texture2D GetTexture()
        {
            return TextureSelector.Select(Textures);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void UnloadContent()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		protected override void DrawCore(DrawContext context)
		{
			for (int i = 0; i < _particles.Count; i++)
			{
				_particles[i].Draw(context);
			}
		}
	}

    public interface IParticleFactory
    {
        ParticleSettings Settings { get; set; }

        Particle Create(Texture2D texture);
    }

    public class DefaultParticleFactory : IParticleFactory
    {
        public DefaultParticleFactory(ParticleSettings settings)
        {
            Settings = settings;
        }

        public DefaultParticleFactory(Vector2 acceleration, Vector2 velocity, float lifeTime = 60f, float mass = 1f, float startAlpha = 255, float endAlpha = 0f)
        {
            Settings = new ParticleSettings
            {
                Acceleration = acceleration,
                Velocity = velocity,
                LifeTime = lifeTime,
                StartAlpha = startAlpha,
                EndAlpha = endAlpha,
                Mass = mass,
            };
        }

        public ParticleSettings Settings { get; set; }

        public Particle Create(Texture2D texture)
        {
            var particle = new Particle(texture)
            {
                Acceleration = Settings.Acceleration,
                Velocity = Settings.Velocity,
                Mass = Settings.Mass,
                LifeTime = Settings.LifeTime,
                StartAlpha = Settings.StartAlpha,
                EndAlpha = Settings.EndAlpha,
                Color = Settings.Color,
                RotationSpeed = Settings.RotationSpeed,
                Direction = Settings.Direction
            };

            particle.Initialize();

            return particle;
        }
    }

    public class ParticleSettings
    {
        public Color Color { get; set; } = Color.White;

        public Vector2 Acceleration { get; set; } = new Vector2(1f);

        public Vector2 Velocity { get; set; } = new Vector2(1f);

        public float LifeTime { get; set; } = 60f;

        public float Mass { get; set; } = 1f;

        public float StartAlpha { get; set; } = 255f;

        public float EndAlpha { get; set; } = 1f;

        public Vector2 Direction { get; set; } = Rand.Vector2(-1f, 1f, -1f, 1f);

        public float RotationSpeed { get; set; } = Rand.Next(-1f, 1f);
    }

    public interface ITextureSelector
    {
        Texture2D Select(Texture2D[] available);
    }

    public class RandomTextureSelector : ITextureSelector
    {
        public Texture2D Select(Texture2D[] available)
        {
            if (available?.Length > 0)
            {
                return available[Rand.Next(0, available.Length - 1)];
            }

            return null;
        }
    }
}