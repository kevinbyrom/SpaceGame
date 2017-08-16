using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;


namespace SpaceGame
{
    public class ScreenManager : GameComponent, IScreenManager  
    {
        private GraphicsDeviceManager deviceManager;
        private Stack<Viewport> viewportStack;
        

        public Viewport Viewport
        {
            get
            {
                return this.deviceManager.GraphicsDevice.Viewport;
            }
        }



        #region Constructors

        public ScreenManager(Game game) : this(game, game.GraphicsDevice) {}
    
        public ScreenManager(Game game, GraphicsDeviceManager deviceManager) : base(game)
        {
            this.DeviceManager = deviceManager;
            this.viewportStack = new Stack<Viewport>();
        }

        #endregion


        #region Screen Size Routines

        public void SetScreenSize(int width, int height, bool fullScreen)
        {
            this.DeviceManager.PreferredBackBufferWidth = width;
            this.DeviceManager.PreferredBackBufferHeight = height;
            this.DeviceManager.IsFullScreen = fullScreen;
            this.DeviceManager.ApplyChanges();
        }


        public void ToggleFullscreen()
        {
            this.DeviceManager.IsFullScreen = !this.DeviceManager.IsFullScreen;
            this.DeviceManager.ApplyChanges();
        }

        #endregion


        #region Viewport Routines

        public void PushViewport(Viewport viewport)
        {
            this.viewportStack.Push(this.deviceManager.GraphicsDevice.Viewport);
            this.deviceManager.GraphicsDevice.Viewport = viewport;
        }

        public void PopViewport()
        {
            if (this.viewportStack.Count > 0)
                this.deviceManager.GraphicsDevice.Viewport = this.viewportStack.Pop();
        }

        #endregion

    }
}
