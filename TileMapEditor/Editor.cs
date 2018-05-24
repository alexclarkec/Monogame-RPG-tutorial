using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using RPG_Tutorial;


namespace TileMapEditor
{
    class Editor : GraphicsDeviceControl
    {
        ContentManager content;
        SpriteBatch spriteBatch1;
        Map map;
        int layerNumber;

        public event EventHandler OnInitialize;

        public Editor()
        {
            map = new Map();
            layerNumber = 0;
        }

        public Layer CurrentLayer
        {
            get { return map.Layer[layerNumber]; }
        }

        protected override void Initialize()
        {
            this.content = new ContentManager(Services, "Content");
            spriteBatch1 = new SpriteBatch(GraphicsDevice);
            XmlManager<Map> xml = new XmlManager<Map>();
            map = xml.Load("Content/XML/Map01.xml");
            map.Initialize(content);

            if (OnInitialize != null)
                OnInitialize(this, null);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Thistle);
            spriteBatch1.Begin();
            map.Draw(spriteBatch1);
            spriteBatch1.End();
        }
    }
}
