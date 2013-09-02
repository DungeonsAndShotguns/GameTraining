using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace F1tZyPong
{
    public class Entity
    {
        Texture2D Image = null;
        Vector2 Posistion = Vector2.Zero;
        Vector2 Volcity = Vector2.Zero;
        Rectangle BoundingBox = new Rectangle();

        public Entity() { }

        public Entity(Texture2D imageToSet, Vector2 position)
        {
            Image = imageToSet;
            Posistion = position;
        }

        public abstract void LoadContent(string path) { }

        public abstract void UnloadContent() { }

        public abstract void Update() { }

        public abstract void Draw() { }
    }
}
