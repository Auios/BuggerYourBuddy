using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuggerYourBuddy
{
    //This form is
    //  Application.OpenForms[0];

    public partial class wMainMenu : Form
    {
        public wMainMenu()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close the application respectfully
            if(GlobalVariables.gameExists)
            {
                Game.endGame();
            }
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.startGame();

            Form f = new wAddPlayers();
            //f.MdiParent = Application.OpenForms[0];
            f.MdiParent = this;
            f.Show();
        }

        public void setNewGameButton(bool isEnabled)
        {
            this.newToolStripMenuItem.Enabled = isEnabled;
        }
    }
}
