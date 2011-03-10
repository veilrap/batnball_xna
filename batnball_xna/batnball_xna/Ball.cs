using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace batnball_xna
{
    public class Ball
    {
        public float x;
        public float y;

        public float speedX;
        public float speedY;

        //Ball is radius 15, treat collisions as rectangle 30x30 for ease
        Texture2D ballTexture;

        public Ball(float startX, float startY, float startSpeedX, float startSpeedY, Texture2D startTexture)
        {
            x = startX;
            y = startY;
            speedX = startSpeedX;
            speedY = startSpeedY;
            ballTexture = startTexture;
        }

        public void Update(GameTime gameTime)
        {
            x += speedX * (float)gameTime.ElapsedGameTime.Milliseconds/1000f;
            y += speedY * (float)gameTime.ElapsedGameTime.Milliseconds/1000f;

            if (x > 770 || x < 0)
            {
                speedX *= -1f;
            }
            if (y > 450 || y < 0)
            {
                speedY *= -1f;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(ballTexture, new Vector2(x, y), Color.White);
            spriteBatch.End();
        }
    }
}
