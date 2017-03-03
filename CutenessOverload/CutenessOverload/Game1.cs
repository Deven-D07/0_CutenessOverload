using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Media;

namespace CutenessOverload
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        double x = 0;

        // Define all the variables you want to use here
        Random rand = new Random();
        Texture2D background;  // This is a Texture2D object that will hold the background picture
        Texture2D Magnush;  // What's supdog?
        Texture2D HyperGra;
        Texture2D Shuma;
        Texture2D MagRock;

        Sprite Mags;  // We will load a superdog image into this sprite and make him do awesome things!
        Sprite HGrav;
        Sprite Gorath;
        Sprite HGrav2;
        List<Sprite> Rocks;

        SoundPlayer player = new SoundPlayer();
        SoundPlayer hype = new SoundPlayer();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Rocks = new List<Sprite>();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("Desert");  // Load the background picture file into the 
                                                             // texture.. note that under the properties for 
                                                             // background.jpg in the Solution explorer you 
                                                             // should see that it has the asset name of "background"

            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\X_-_Men_vs_Street_Fighter_Music_-_STORM.wav";
            
            hype.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\mag_hypergrav.wav";
            hype.Play();
            player.Play();
            Magnush = Content.Load<Texture2D>("frame91");
            HyperGra = Content.Load<Texture2D>("frame154");
            Shuma = Content.Load<Texture2D>("shuma");
            MagRock = Content.Load<Texture2D>("rock");

            Mags = new Sprite(new Vector2(50, 30), // Start at x=-150, y=30
                                  Magnush, 
                                  new Rectangle(0, 0, 100, 135), // Use this part of the superdog texture
                                  new Vector2(0, 0));

            HGrav = new Sprite(new Vector2(50, 30), HyperGra, new Rectangle(0, 0, 130, 120), new Vector2(900, 900));
            HGrav2 = new Sprite(new Vector2(380,370), HyperGra, new Rectangle(0, 0, 130, 120), new Vector2(-90, -90));
            Gorath = new Sprite(new Vector2(380, 370), // Start at x=-150, y=30
                                  Shuma,
                                  new Rectangle(0, 0, 101, 122), // Use this part of the superdog texture
                                  new Vector2(-90, -90));

            for (int i = 0; i < 100; i++)
            {
                Rocks.Add(new Sprite(new Vector2(50, 30), // Start at x=-150, y=30
                                      MagRock,
                                      new Rectangle(0, 0, 40, 46), // Use this part of the superdog texture
                                      new Vector2(rand.Next(300, 900), rand.Next(300, 900))));

                
            }

            // Add any other initialization code here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            Mags.Rotation = 0;
            Gorath.Rotation = 0;
            HGrav2.Rotation = 0;
            HGrav.Rotation = 0;

            x += 0.1f;

            Mags.Location = new Vector2(Mags.Location.X, (float)(30 + Math.Sin(x) * 4));

            Mags.Update(gameTime);  // Update the superdog so he moves
            HGrav.Update(gameTime);
            HGrav2.Update(gameTime);
            Gorath.Update(gameTime);

            for (int i = 0; i < Rocks.Count; i++)
            {
                Rocks[i].Rotation += 0.01f; 
                Rocks[i].Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            
            spriteBatch.Draw(background, new Rectangle(0,0,this.Window.ClientBounds.Width,this.Window.ClientBounds.Height), Color.White); // Draw the background at (0,0) - no crazy tinting
            Mags.Draw(spriteBatch);
            Gorath.Draw(spriteBatch); // Draw the superdog!
            HGrav.Draw(spriteBatch);
            HGrav2.Draw(spriteBatch);
            for (int i = 0; i < Rocks.Count; i++)
            {
                Rocks[i].Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
