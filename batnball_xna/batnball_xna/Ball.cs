using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace batnball_xna
{
    class Ball
    {
        public float x;
        public float y;

        public float speedX;
        public float speedY;

        //Ball is radius 15, treat collisions as rectangle 30x30 for ease
        Texture2D ballTexture;

        public int scoreLeft = 0;
        public int scoreRight = 0;

        SpriteFont scoreFont;

        public Ball(float startX, float startY, float startSpeedX, float startSpeedY, Texture2D startTexture, SpriteFont font)
        {
            x = startX;
            y = startY;
            speedX = startSpeedX;
            speedY = startSpeedY;
            ballTexture = startTexture;
            scoreFont = font;
        }

        public void Update(GameTime gameTime)
        {
            x += speedX * (float)gameTime.ElapsedGameTime.Milliseconds/1000f;
            y += speedY * (float)gameTime.ElapsedGameTime.Milliseconds/1000f;

            if (x > 770 || x < 0)
            {
                speedX *= -1f;
                if (x > 770)
                {
                    scoreLeft++;
                }
                if (x < 0)
                {
                    scoreRight++;
                }
            }
            if (y > 450 || y < 0)
            {
                speedY *= -1f;
            }
        }

        public void CheckCollision(Bat bat)
        {
            if ((x < bat.x + 30 && x + 30 > bat.x) && (y < bat.y + 150 && y + 30 > bat.y))
            {
                speedX *= -1f;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(ballTexture, new Vector2(x, y), Color.White);
            spriteBatch.DrawString(scoreFont, scoreLeft.ToString(), new Vector2(50,10), Color.White);
            spriteBatch.DrawString(scoreFont, scoreRight.ToString(), new Vector2(680, 10), Color.White);
            spriteBatch.End();
        }
    }
}
