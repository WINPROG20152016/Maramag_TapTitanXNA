using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TapTitanXNA_AlyannaMaramag
{
    public class Hero
    {
        #region Properties
        Texture2D playerLoc, playerI, playerA, Ally01, Ally02, Monster01, Monster02;
        Vector2 playerPosition, allyPosition01, allyPosition02, monsterPosition;
        ContentManager content;
        Level level;
        int timer = 0;
        int count = 0;

        Animation idleAnimation, attackAnimation;
        Animation ally01, ally02;
        Animation monster01, monster02;
        AnimationPlayer spritePlayer, spriteAlly01, spriteAlly02, spriteMonster01;
        #endregion

        public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;

            spritePlayer.PlayAnimation(idleAnimation);

        }



        public void LoadContent()
        {
            playerLoc = content.Load<Texture2D>("HeroSprite/HeroI");
            playerI = content.Load<Texture2D>("HeroSprite/HeroI");
            playerA = content.Load<Texture2D>("HeroSprite/HeroA");
            Ally01 = content.Load<Texture2D>("Ally/asd");
            Ally02 = content.Load<Texture2D>("Ally/zxc");
            Monster01 = content.Load<Texture2D>("Monster/Monster01");
            Monster02 = content.Load<Texture2D>("Monster/Monster02");


            idleAnimation = new Animation(playerI, 0.2f, true, 4);
            int pPositionX = (Level.windowWidth / 2) - (playerLoc.Width / 8);
            int pPositionY = (Level.windowHeight / 2) - (playerLoc.Height / 2);
            playerPosition = new Vector2((float)pPositionX, (float)pPositionY);
            attackAnimation = new Animation(playerA, 0.1f, true, 9);

            ally01 = new Animation(Ally01, 0.2f, true, 11);
            int onePositionX = (Level.windowWidth / 2) - (Ally01.Width / 8);
            int onePositionY = (Level.windowHeight / 3) - (Ally01.Height / 6);
            allyPosition01 = new Vector2((float)onePositionX, (float)onePositionY);
            spriteAlly01.PlayAnimation(ally01);

            ally02 = new Animation(Ally02, 0.2f, true, 8);
            int twoPositionX = (Level.windowWidth / 1) - (Ally02.Width / 8);
            int twoPositionY = (Level.windowHeight / 3) - (Ally02.Height / 6);
            allyPosition02 = new Vector2((float)twoPositionX, (float)twoPositionY);
            spriteAlly02.PlayAnimation(ally02);


            monster01 = new Animation(Monster01, 0.05f, false, 1);
            int mPositionX = (Level.windowWidth / 2) - (Monster01.Width / 2);
            int mPositionY = (Level.windowHeight / 3) - (Monster01.Height / 2);
            monsterPosition = new Vector2((float)mPositionX, (float)mPositionY);
            spriteMonster01.PlayAnimation(monster01);
            monster02 = new Animation(Monster02, 0.15f, false, 7);



            spritePlayer.PlayAnimation(idleAnimation);

        }
        public void Update(GameTime gameTime)
        {
            
            if (level.mouseState.RightButton == ButtonState.Pressed && level.oldMouseState.RightButton == ButtonState.Released)
            {
                if (playerPosition.X + (playerI.Width / 4) != Level.windowWidth)
                {
                    spritePlayer.PlayAnimation(idleAnimation);
                    //playerPosition.X++;

                }
            }

            if (level.mouseState.LeftButton == ButtonState.Pressed && level.oldMouseState.LeftButton == ButtonState.Released)
            {
                if (playerPosition.X != 0)
                {
                    if (spritePlayer.Animation.islooping == true)
                    {
                        spritePlayer.PlayAnimation(attackAnimation);

                    }
                    count++;
                    timer = 0;
                    timer++;
                    if (timer >= 5)
                    {
                        timer = 0;
                        spritePlayer.PlayAnimation(idleAnimation);
                    }
                    timer = 0;
                    if (level.health != 0)
                    {
                        spriteMonster01.PlayAnimation(monster01);

                    }
                    else
                    {
                        spriteMonster01.PlayAnimation(monster02);

                    }
                }
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteMonster01.Draw(gameTime, spriteBatch,
                monsterPosition, SpriteEffects.None);
            spritePlayer.Draw(gameTime, spriteBatch, 
                playerPosition, SpriteEffects.None);
            spriteAlly01.Draw(gameTime, spriteBatch,
                allyPosition01, SpriteEffects.None);
            spriteAlly02.Draw(gameTime, spriteBatch,
                allyPosition02, SpriteEffects.None);
        }
    }
}
