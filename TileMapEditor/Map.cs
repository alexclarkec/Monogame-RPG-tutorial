using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace TileMapEditor
{
    public class Map
    {
        [XmlElement("Layer")]
        public List<Layer> Layer;
        public Vector2 TileDimensions;

        public void Initialize(ContentManager content)
        {
            foreach (Layer L in Layer)
            {
                L.Initialize(content, TileDimensions);
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Layer L in Layer)
            {
                L.Draw(spritebatch);
            }
        }
    }
}
