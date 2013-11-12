using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class Entity
    {
        Vector2 Position { get; set; }
        Rectangle BoundingBox { get; set; }
        Texture2D Image { get; set; }
        bool Visable { get; set; }

        public Entity() { }

        public Entity(Vector2 startPosition, Rectangle boundingBox, bool isVisable)
        {
            Position = startPosition;
            BoundingBox = boundingBox;
            Visable = isVisable;
        }

        public void LoadImage(Texture2D image)
        {
            Image = image;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void Move(float x, float y)
        {
            Position = new Vector2(Position.X + x, Position.Y + y);
            DefineBoundingBox(new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height));
        }

        public void DefineBoundingBox(Rectangle boundingBox)
        {
            BoundingBox = boundingBox;
        }

        public void ResizeBoundingBox(Texture2D imageToUse)
        {
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, imageToUse.Width, imageToUse.Height);
        }

        public void SetVisable(bool visable)
        {
            Visable = visable;
        }

        public Texture2D ReturnImage()
        {
            if (Visable == true)
            {
                return Image;
            }
            
            return null;
        }

        public Vector2 ReturnPosition()
        {
            return Position;
        }

        public Rectangle ReturnBoundingBox()
        {
            return BoundingBox;
        }

        public bool ReturnVisbale()
        {
            return Visable;
        }

        public virtual Entity OnCollide(Entity entColliding)
        {
            // do somthing
            return null;
        }

    }
}
