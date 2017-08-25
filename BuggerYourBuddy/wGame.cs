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
    public partial class wGame : Form
    {
        int colWidth = 100;
        int playerCount;

        public wGame()
        {
            InitializeComponent();
        }

        public wGame(int rounds, int startingCards, bool isExtended, DataTable players)
        {
            //Setup our data grid view based on the parameters passed in
            InitializeComponent();

            DataTable gameTable = new DataTable();
            gameTable.Columns.Add("roundNumber", typeof(int));
            this.playerCount = players.Rows.Count;

            for(int i = 0; i < playerCount; i++)
            {
                gameTable.Columns.Add(players.Rows[i].ItemArray[0].ToString(), typeof(int));
                gameTable.Columns.Add("chk_" + players.Rows[i].ItemArray[0].ToString(), typeof(bool));
            }
            dgvPlayers.DataSource = gameTable;

            dgvPlayers.Columns[0].HeaderText = "Round";
            dgvPlayers.Columns[0].Width = 48;
            dgvPlayers.Columns[0].ReadOnly = true;

            for(int i = 0; i < this.playerCount; i++)
            {
                int currentCol = i * 2 + 1;
                dgvPlayers.Columns[currentCol].Width = colWidth;

                dgvPlayers.Columns[currentCol + 1].HeaderText = "Bid";
                dgvPlayers.Columns[currentCol + 1].Width = 32;
            }

            DataRow dr;
            if (isExtended)
            {
                for (int i = 0; i < rounds/2; i++)
                {
                    dr = gameTable.NewRow();
                    dr[0] = rounds/2 - i;
                    //for (int j = 1; j < (dr.ItemArray.Count() - 1) / 2; j++){}
                    gameTable.Rows.Add(dr);
                }
                for (int i = 0; i < rounds / 2; i++)
                {
                    dr = gameTable.NewRow();
                    dr[0] = i;
                    //for (int j = 1; j < (dr.ItemArray.Count() - 1) / 2; j++){}
                    gameTable.Rows.Add(dr);
                }
            }
            else
            {
                for (int i = 1; i < rounds; i++)
                {
                    dr = gameTable.NewRow();
                    dr[0] = rounds - i;
                    //for (int j = 1; j < (dr.ItemArray.Count() - 1) / 2; j++){}
                    gameTable.Rows.Add(dr);
                }
                dr = gameTable.NewRow();
                dr[0] = 1;
                gameTable.Rows.Add(dr);
            }

            //Add the last row for showing player scores
            dr = gameTable.NewRow();
            gameTable.Rows.Add(dr);
            dgvPlayers.Rows[dgvPlayers.RowCount - 1].Cells[1].ReadOnly = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            //Confirm end game
            if (MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Game.endGame();
                this.Close();
            }
        }

        private void dgvPlayers_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            updateScores();
        }

        private void dgvPlayers_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void updateScores()
        {
            //Clear the score row's data
            for(int i = 0; i < this.playerCount; i++)
            {
                dgvPlayers.Rows[dgvPlayers.Rows.Count - 1].Cells[(2 * i) + 1].Value = 0;
            }

            //Rows
            for(int i = 0; i < dgvPlayers.Rows.Count-1; i++)
            {
                //Cells
                for(int j = 0; j < this.playerCount; j++)
                {
                    //If player got their bid
                    if(dgvPlayers.Rows[i].Cells[(2 * j) + 2].Value.ToString() == "True")
                    {
                        if(dgvPlayers.Rows[i].Cells[(2 * j) + 1].Value.ToString() != String.Empty)
                        {
                            int currentScore = 0;
                            int addScore = 0;
                            int newScore = 0;

                            int.TryParse(dgvPlayers.Rows[dgvPlayers.Rows.Count - 1].Cells[(2 * j) + 1].Value.ToString(), out currentScore);
                            if (!int.TryParse(dgvPlayers.Rows[i].Cells[(2 * j) + 1].Value.ToString(), out addScore))
                                dgvPlayers.Rows[i].Cells[(2 * j) + 1].Value = "";
                            newScore = currentScore + addScore + 10;

                            dgvPlayers.Rows[dgvPlayers.Rows.Count - 1].Cells[(2 * j) + 1].Value = newScore;
                        }
                    }
                }
            }
        }
    }
}
