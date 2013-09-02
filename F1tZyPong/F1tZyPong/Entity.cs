using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace F1tZyPong
{
    public abstract class Entity
    {
        public Texture2D Image = null;
        Vector2 Posistion = Vector2.Zero;
        public Vector2 Volcity = Vector2.Zero;
        Rectangle BoundingBox = new Rectangle();

        public Entity() { }

        public Entity(Texture2D imageToSet, Vector2 position)
        {
            Image = imageToSet;
            Posistion = position;
        }

        public abstract void LoadContent(Texture2D TextureToAssign);

        public abstract void UnloadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw();
    }
}
