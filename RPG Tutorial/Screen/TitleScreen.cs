using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG_Tutorial
{
    public class TitleScreen : GameScreen
    {
        MenuManager MenuManager;

        public TitleScreen()
        {
            MenuManager = new MenuManager();

        }

        public override void LoadContent()
        {
            base.LoadContent();
            MenuManager.LoadContent("Content/XML/TitleMenu.xml");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            MenuManager.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MenuManager.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            MenuManager.Draw(spriteBatch);
        }



    }
}
