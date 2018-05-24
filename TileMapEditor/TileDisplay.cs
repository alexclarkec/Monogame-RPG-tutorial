using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TileMapEditor
{
    class TileDisplay : GraphicsDeviceControl
    {
        Editor editor;
        Image image;
        SpriteBatch spriteBatch;

        public TileDisplay()
        {
            
        }

        public TileDisplay(ref Editor editor)
        {
            this.editor = editor;
            editor.OnInitialize += LoadContent;
        }

        private void LoadContent(object sender, EventArgs e)
        {
            image = editor.CurrentLayer.Image;
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Draw()
        {
            spriteBatch.Begin();
            image.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
