using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace TileMapEditor
{
     public class Layer
    {
        public class TileMap
        {
            [XmlElement("Row")]
            public List<string> Row;
        }

        Vector2 TileDimensions;


        List<List<Vector2>> tileMap;

        [XmlElement("TileMap_")]
        public TileMap TileMap_;
        public Image Image;

        public Layer()
        {
            TileDimensions = new Vector2();
            tileMap = new List<List<Vector2>>();
        }

        public void Initialize(ContentManager content, Vector2 tileDimensions)
        {
            foreach(string row in TileMap_.Row)
            {
                string[] split = row.Split(']');
                List<Vector2> temTileMap = new List<Vector2>();
                foreach(string s in split)
                {
                    int value1, value2;
                    if (s !=String.Empty && !s.Contains('x'))
                    {
                        string str = s.Replace("[", String.Empty);
                        value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                    }
                    else
                        value1 = value2 = -1;

                    temTileMap.Add(new Vector2(value1, value2));

                }
                tileMap.Add(temTileMap);

            }

            Image.Initialize(content);
            this.TileDimensions = tileDimensions;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < tileMap.Count; i++)
            {
                for(int j = 0; j < tileMap[i].Count; j++)
                {
                    if (tileMap[i][j] != -Vector2.One)
                    {
                        Image.Position = new Vector2(j * TileDimensions.X, i * TileDimensions.Y);
                        Image.SourceRect = new Rectangle((int)(tileMap[i][j].X * TileDimensions.X),
                            (int)(tileMap[i][j].Y * TileDimensions.Y), (int)TileDimensions.X, 
                             (int)TileDimensions.Y);
                        Image.Draw(spriteBatch);
                    }
                } 
            }
        }

    }
}
