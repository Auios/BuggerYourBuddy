using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggerYourBuddy
{
    public class Game
    {
        public static void startGame()
        {
            //Things that should happen when the game is created
            GlobalVariables.gameExists = true;
            GlobalVariables.wMainMenu.setNewGameButton(false);
        }

        public static void endGame()
        {
            //Things that should happen when the game is closed
            GlobalVariables.gameExists = false;
            GlobalVariables.wMainMenu.setNewGameButton(true);
        }
    }
}
