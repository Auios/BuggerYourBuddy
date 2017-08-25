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
    public partial class wAddPlayers : Form
    {
        //Variables to pass to the wGame form
        int rounds = 0;
        int startingCards = 0;

        public wAddPlayers()
        {
            InitializeComponent();
        }

        private void cmdAddPlayer_Click(object sender, EventArgs e)
        {
            bool playerAlreadyExists = false;

            //Check if textbox has anything in it
            if (txtPlayerName.Text.Trim().Length > 0)
            {
                
                txtPlayerName.Text = txtPlayerName.Text.Trim();
                
                //Check if another player has the same name
                foreach(string lbxItem in lbxPlayerList.Items)
                {
                    //Same name?
                    if (txtPlayerName.Text == lbxItem)
                    {
                        playerAlreadyExists = true;
                        break;
                    }
                }
                
                if(!playerAlreadyExists)
                {
                    //Add player to the list box
                    lbxPlayerList.Items.Add(txtPlayerName.Text);
                    lblPlayerCount.Text = lbxPlayerList.Items.Count.ToString() + "/10";
                    txtPlayerName.Text = "";
                    cmdRemove.Enabled = true;
                    this.calculateInformation();

                    //Disable the add player button when player list is full
                    if (lbxPlayerList.Items.Count == 10)
                    {
                        cmdAddPlayer.Enabled = false;
                        txtPlayerName.Enabled = false;
                    }

                    //Enable the next button when player count is valid
                    if (lbxPlayerList.Items.Count >= 4)
                        cmdDone.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cannot add two players with the same name!");
                }
            }
            txtPlayerName.Select();
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            //Make sure an item is selected on the list box
            if(lbxPlayerList.SelectedIndex > -1)
            {
                lbxPlayerList.Items.RemoveAt(lbxPlayerList.SelectedIndex);
                cmdAddPlayer.Enabled = true;
                txtPlayerName.Enabled = true;
                this.calculateInformation();

                //Disable the remove button if there are no players on the list
                if(lbxPlayerList.Items.Count == 0)
                    cmdRemove.Enabled = false;

                //If minimum player count is not valid then disable the done button
                if (lbxPlayerList.Items.Count < 4)
                    cmdDone.Enabled = false;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            //Clean up
            if(MessageBox.Show("Are you sure you want to exit the setup menu?","Exit?",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Game.endGame();
                this.Close();
            }
        }

        private void cmdDone_Click(object sender, EventArgs e)
        {
            //Gather the list box items into a datatable so we can pass it
            // to the wGame form
            DataTable players = new DataTable();
            players.Columns.Add("playerName");
            foreach(string playerName in lbxPlayerList.Items)
            {
                DataRow dr = players.NewRow();
                dr["playerName"] = playerName;
                players.Rows.Add(dr);
                //MessageBox.Show(players.Rows[players.Rows.Count-1].ItemArray[0].ToString());
            }

            Form f = new wGame(rounds, startingCards, chkExtended.Checked, players);
            f.MdiParent = Application.OpenForms[0];
            f.Show();

            this.Close();
        }

        private void chkExtended_CheckedChanged(object sender, EventArgs e)
        {
            //Refresh information on screen when checkbox is clicked
            this.calculateInformation();
        }

        private void calculateInformation()
        {
            //Update the information on screen
            if(lbxPlayerList.Items.Count >= 4)
            {
                if (chkExtended.Checked)
                {
                    rounds = (int)Math.Floor((decimal)52 / lbxPlayerList.Items.Count) * 2;
                    startingCards = (int)Math.Floor((decimal)52 / lbxPlayerList.Items.Count);
                }
                else
                {
                    rounds = (int)(Math.Floor((decimal)52 / lbxPlayerList.Items.Count) + 1);
                    startingCards = (int)Math.Floor((decimal)52 / lbxPlayerList.Items.Count);
                }

                lblInfoRounds.Text = "Rounds: " + rounds.ToString();
                lblInfoStartingCards.Text = "Starting Cards: " + startingCards.ToString();
            }
            else
            {
                lblInfoRounds.Text = "Rounds: ...";
                lblInfoStartingCards.Text = "Starting Cards: ...";
            }
        }
    }
}
