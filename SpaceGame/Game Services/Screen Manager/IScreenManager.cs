using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;



namespace SpaceGame
{
    public interface IScreenManager
    {
        Viewport Viewport { get; set;  }

        void SetScreenSize(int width, int height, bool fullScreen);
        void ToggleFullScreen();

        void PushViewport(ViewPort viewport);
        void PopViewport(Viewport viewport);
        
    }
}
