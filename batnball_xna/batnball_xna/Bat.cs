using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace batnball_xna
{
    public class Bat
    {
        public float x;
        public float y;

        public float speed;

        public int player;

        //Bat Size is 150px by 30px
        Texture2D batTexture;

        public Bat(float startX, float startY, float startSpeed, int startPlayer, Texture2D startTexture)
        {
            x = startX;
            y = startY;
            speed = startSpeed;
            player = startPlayer;
            batTexture = startTexture;
        }

        public void Update(GameTime gameTime)
        {
            if (player == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    y -=  speed * (float)gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    y += speed * (float)gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
            }

            if (player == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    y -= speed * (float)gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    y += speed * (float)gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(batTexture, new Vector2(x, y), Color.White);
            spriteBatch.End();
        }
    }
}
