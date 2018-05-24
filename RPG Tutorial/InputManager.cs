using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;


namespace RPG_Tutorial
{
    /// <summary>
    /// Handles Inputs for the game.
    /// Is a singleton class
    /// </summary>
    public class InputManager
    {
        KeyboardState currentKeyState, prevKeyState;

        private static InputManager instance;

        /// <summary>
        /// Creates the Singleton or Instance
        /// Methods of this Class are accessed by InputManger.Instance.'method'
        /// </summary>
        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();

                return instance;
            }
        }

        /// <summary>
        /// Sets prevKeyState to the current
        /// currentKeyState is set to the Keyboards state unless the sceen is transitioning
        /// </summary>
        public void Update()
        {
            prevKeyState = currentKeyState;
            if (!ScreenManager.Instance.IsTransitioning)
                currentKeyState = Keyboard.GetState();

        }

        /// <summary>
        /// Determines if a key is pressed
        /// if the key is currently down but was previously up returns true
        /// </summary>
        /// <param name="keys">Keys of the Keyboard</param>
        /// <returns>Boolean</returns>
        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if a key has been released
        /// if the key is currently up but was previously down returns true
        /// </summary>
        /// <param name="keys">Keys of the Keyboard</param>
        /// <returns>Boolean</returns>
        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if a key is being held down
        /// if the key is currently down returns true
        /// </summary>
        /// <param name="keys">Keys of the Keyboard</param>
        /// <returns>Boolean</returns>
        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }         
    }
}
