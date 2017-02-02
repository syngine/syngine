using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Syngine.Graphics;

namespace Syngine.Physics.Graphics
{
    public class DrawableBody : Drawable
    {
        protected readonly Vector2 InitialPosition;

        public DrawableBody(Vector2 initialPosition)
        {
            InitialPosition = initialPosition;
        }

        protected Body Body { get; set; }

        public float Mass
        {
            get
            {
                return Body?.Mass ?? 0f;
            }
            set
            {
                if (Body != null)
                {
                    Body.Mass = value;
                }
            }
        }

        public Vector2 Position
        {
            get
            {
                return Body?.Position.ToDisplayUnits() ?? InitialPosition;
            }
            set
            {
                if (Body != null)
                {
                    Body.Position = value.ToSimUnits();
                }
            }
        }

        public SpriteBook Sprites { get; protected set; } = new SpriteBook();

        protected virtual Body CreateBody(object data)
        {
            return BodyFactory.CreateBody(WorldContext.World, InitialPosition.ToSimUnits(), data);
        }

        protected override void UpdateCore(UpdateContext context)
        {
            Sprites.Set(Position, Body.Rotation);
            Sprites.Update(context);
        }

        protected override void DrawCore(DrawContext context)
        {
            Sprites.Draw(context);
        }

        public override void Initialize()
        {
            Body = CreateBody(this);
            Sprites.Initialize();
            base.Initialize();
        }

        public override void LoadContent(LoadContext context)
        {
            Sprites.LoadContent(context);
        }

        public override void UnloadContent()
        {
            Sprites.UnloadContent();
        }

        /// <summary>
        /// Applies a force at the center of mass.
        /// </summary>
        /// <param name="force"></param>
        public void ApplyForce(Vector2 force)
        {
            Body?.ApplyForce(force);
        }

        /// <summary>
        /// Applies a force at the center of mass.
        /// </summary>
        /// <param name="force"></param>
        /// <param name="point"></param>
        public void ApplyForce(Vector2 force, Vector2 point)
        {
            Body?.ApplyForce(force, point);
        }

        /// <summary>
        /// Apply a torque. This affects the angular velocity without affecting
        /// the linear velocity of the center of mass. This wakes up the body.
        /// </summary>
        /// <param name="torque"></param>
        public void ApplyTorque(float torque)
        {
            Body?.ApplyTorque(torque);
        }
    }
}
