﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace RPG_Tutorial
{
    public class GameScreen
    {
        protected ContentManager content;

        [XmlIgnore]
        public Type Type;

        public string XmlPath;

        public GameScreen()
        {
            Type = this.GetType();
            XmlPath = "Content/XML/" + Type.ToString().Replace("RPG_Tutorial.", "") + ".xml";
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
            InputManager.Instance.Update(); 
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
