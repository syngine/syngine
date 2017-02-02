using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Syngine.Graphics
{
	/// <summary>
	/// 
	/// </summary>
	public class ParticleEmitter
	{
		private static readonly Random Random = new Random(DateTime.Now.Millisecond);

	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="textures"></param>
	    /// <param name="region"></param>
	    /// <param name="minAngle"></param>
	    /// <param name="maxAngle"></param>
	    public ParticleEmitter(Rectangle region, Vector2 minAngle, Vector2 maxAngle)
		{
	        Region = region;
	        Angle = Rand.Vector2(minAngle.X, maxAngle.X, minAngle.Y, maxAngle.Y);
			//Angle = new Vector2(Math.Min(minAngle.X, maxAngle.X), Math.Min(minAngle.Y, maxAngle.Y));
		}

		/// <summary>
		/// 
		/// </summary>
		public Vector2 Angle { get; set; }

	    /// <summary>
		/// 
		/// </summary>
		public Rectangle Region { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual void Emit(Particle particle, LoadContext context)
		{
			particle.Position = GenerateRandomPosition();
		}

	    /// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual void Emit(IEnumerable<Particle> particles)
	    {
	        var context = GameContext.CreateLoadContext();

			foreach (var particle in particles)
			{
				Emit(particle, context);
			}
        }

        private Vector2 GenerateRandomPosition()
        {
            return Rand.Vector2(Region.Left, Region.Right, Region.Top, Region.Bottom);
        }

        private Vector2 GenerateRandomDirection()
        {
            return Rand.Vector2((int)Angle.X, (int)Angle.Y, (int)Angle.X, (int)Angle.Y);
        }
    }
}