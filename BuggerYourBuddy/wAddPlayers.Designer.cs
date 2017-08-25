namespace BuggerYourBuddy
{
    partial class wAddPlayers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wAddPlayers));
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.cmdAddPlayer = new System.Windows.Forms.Button();
            this.lbxPlayerList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdDone = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.lblInfoRounds = new System.Windows.Forms.Label();
            this.lblInfoStartingCards = new System.Windows.Forms.Label();
            this.chkExtended = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayerName.Location = new System.Drawing.Point(12, 12);
            this.txtPlayerName.MaxLength = 20;
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(131, 20);
            this.txtPlayerName.TabIndex = 1;
            // 
            // cmdAddPlayer
            // 
            this.cmdAddPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddPlayer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdAddPlayer.Location = new System.Drawing.Point(149, 10);
            this.cmdAddPlayer.Name = "cmdAddPlayer";
            this.cmdAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.cmdAddPlayer.TabIndex = 3;
            this.cmdAddPlayer.Text = "Add Player";
            this.cmdAddPlayer.UseVisualStyleBackColor = true;
            this.cmdAddPlayer.Click += new System.EventHandler(this.cmdAddPlayer_Click);
            // 
            // lbxPlayerList
            // 
            this.lbxPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxPlayerList.FormattingEnabled = true;
            this.lbxPlayerList.Location = new System.Drawing.Point(12, 71);
            this.lbxPlayerList.Name = "lbxPlayerList";
            this.lbxPlayerList.Size = new System.Drawing.Size(212, 134);
            this.lbxPlayerList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Game Information:";
            // 
            // cmdDone
            // 
            this.cmdDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDone.Enabled = false;
            this.cmdDone.Location = new System.Drawing.Point(149, 357);
            this.cmdDone.Name = "cmdDone";
            this.cmdDone.Size = new System.Drawing.Size(75, 23);
            this.cmdDone.TabIndex = 2;
            this.cmdDone.Text = "Done";
            this.cmdDone.UseVisualStyleBackColor = true;
            this.cmdDone.Click += new System.EventHandler(this.cmdDone_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(15, 357);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Location = new System.Drawing.Point(183, 208);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPlayerCount.Size = new System.Drawing.Size(30, 13);
            this.lblPlayerCount.TabIndex = 10;
            this.lblPlayerCount.Text = "0/10";
            // 
            // cmdRemove
            // 
            this.cmdRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdRemove.Enabled = false;
            this.cmdRemove.Location = new System.Drawing.Point(12, 211);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 11;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // lblInfoRounds
            // 
            this.lblInfoRounds.AutoSize = true;
            this.lblInfoRounds.Location = new System.Drawing.Point(12, 306);
            this.lblInfoRounds.Name = "lblInfoRounds";
            this.lblInfoRounds.Size = new System.Drawing.Size(59, 13);
            this.lblInfoRounds.TabIndex = 12;
            this.lblInfoRounds.Text = "Rounds: ...";
            // 
            // lblInfoStartingCards
            // 
            this.lblInfoStartingCards.AutoSize = true;
            this.lblInfoStartingCards.Location = new System.Drawing.Point(12, 325);
            this.lblInfoStartingCards.Name = "lblInfoStartingCards";
            this.lblInfoStartingCards.Size = new System.Drawing.Size(88, 13);
            this.lblInfoStartingCards.TabIndex = 13;
            this.lblInfoStartingCards.Text = "Starting Cards: ...";
            // 
            // chkExtended
            // 
            this.chkExtended.AutoSize = true;
            this.chkExtended.Location = new System.Drawing.Point(12, 251);
            this.chkExtended.Name = "chkExtended";
            this.chkExtended.Size = new System.Drawing.Size(71, 17);
            this.chkExtended.TabIndex = 14;
            this.chkExtended.Text = "Extended";
            this.chkExtended.UseVisualStyleBackColor = true;
            this.chkExtended.CheckedChanged += new System.EventHandler(this.chkExtended_CheckedChanged);
            // 
            // wAddPlayers
            // 
            this.AcceptButton = this.cmdAddPlayer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(236, 392);
            this.ControlBox = false;
            this.Controls.Add(this.chkExtended);
            this.Controls.Add(this.lblInfoStartingCards);
            this.Controls.Add(this.lblInfoRounds);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxPlayerList);
            this.Controls.Add(this.cmdAddPlayer);
            this.Controls.Add(this.txtPlayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wAddPlayers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Players";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Button cmdAddPlayer;
        private System.Windows.Forms.ListBox lbxPlayerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdDone;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Label lblInfoRounds;
        private System.Windows.Forms.Label lblInfoStartingCards;
        private System.Windows.Forms.CheckBox chkExtended;
    }
}