namespace DailyFantasyNFL
{
    partial class Form1
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
            this.rdoRotoGrinders = new System.Windows.Forms.RadioButton();
            this.rdoNumberFire = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClearScreen = new System.Windows.Forms.Button();
            this.btnViewPlayers = new System.Windows.Forms.Button();
            this.btnRunStats = new System.Windows.Forms.Button();
            this.dataGridPlayers = new System.Windows.Forms.DataGridView();
            this.txtIncomingText = new System.Windows.Forms.RichTextBox();
            this.btnViewStats = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinValue = new System.Windows.Forms.TextBox();
            this.rdoNumberFireDefense = new System.Windows.Forms.RadioButton();
            this.rdoViewLineups = new System.Windows.Forms.Button();
            this.btnResetStats = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinHighScore = new System.Windows.Forms.TextBox();
            this.rdoRotoWire = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQBid = new System.Windows.Forms.TextBox();
            this.lblRB1 = new System.Windows.Forms.Label();
            this.txtRB1id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWR1id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTEid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDEFid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUTILid = new System.Windows.Forms.TextBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoDraftKings = new System.Windows.Forms.RadioButton();
            this.rdoFanDuel = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtThreadNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoRotoGrinders
            // 
            this.rdoRotoGrinders.AutoSize = true;
            this.rdoRotoGrinders.Location = new System.Drawing.Point(8, 382);
            this.rdoRotoGrinders.Margin = new System.Windows.Forms.Padding(2);
            this.rdoRotoGrinders.Name = "rdoRotoGrinders";
            this.rdoRotoGrinders.Size = new System.Drawing.Size(87, 17);
            this.rdoRotoGrinders.TabIndex = 1;
            this.rdoRotoGrinders.TabStop = true;
            this.rdoRotoGrinders.Text = "RotoGrinders";
            this.rdoRotoGrinders.UseVisualStyleBackColor = true;
            // 
            // rdoNumberFire
            // 
            this.rdoNumberFire.AutoSize = true;
            this.rdoNumberFire.Location = new System.Drawing.Point(9, 401);
            this.rdoNumberFire.Margin = new System.Windows.Forms.Padding(2);
            this.rdoNumberFire.Name = "rdoNumberFire";
            this.rdoNumberFire.Size = new System.Drawing.Size(113, 17);
            this.rdoNumberFire.TabIndex = 2;
            this.rdoNumberFire.TabStop = true;
            this.rdoNumberFire.Text = "NumberFirePlayers";
            this.rdoNumberFire.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(9, 431);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(78, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClearScreen
            // 
            this.btnClearScreen.Location = new System.Drawing.Point(91, 431);
            this.btnClearScreen.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearScreen.Name = "btnClearScreen";
            this.btnClearScreen.Size = new System.Drawing.Size(78, 23);
            this.btnClearScreen.TabIndex = 4;
            this.btnClearScreen.Text = "Clear Screen";
            this.btnClearScreen.UseVisualStyleBackColor = true;
            this.btnClearScreen.Click += new System.EventHandler(this.btnClearScreen_Click);
            // 
            // btnViewPlayers
            // 
            this.btnViewPlayers.Location = new System.Drawing.Point(173, 431);
            this.btnViewPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewPlayers.Name = "btnViewPlayers";
            this.btnViewPlayers.Size = new System.Drawing.Size(78, 23);
            this.btnViewPlayers.TabIndex = 5;
            this.btnViewPlayers.Text = "View Players";
            this.btnViewPlayers.UseVisualStyleBackColor = true;
            this.btnViewPlayers.Click += new System.EventHandler(this.btnViewPlayers_Click);
            // 
            // btnRunStats
            // 
            this.btnRunStats.Location = new System.Drawing.Point(255, 431);
            this.btnRunStats.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunStats.Name = "btnRunStats";
            this.btnRunStats.Size = new System.Drawing.Size(78, 23);
            this.btnRunStats.TabIndex = 6;
            this.btnRunStats.Text = "Run Stats";
            this.btnRunStats.UseVisualStyleBackColor = true;
            this.btnRunStats.Click += new System.EventHandler(this.btnRunStats_Click);
            // 
            // dataGridPlayers
            // 
            this.dataGridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlayers.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridPlayers.Location = new System.Drawing.Point(546, 0);
            this.dataGridPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridPlayers.Name = "dataGridPlayers";
            this.dataGridPlayers.RowTemplate.Height = 28;
            this.dataGridPlayers.Size = new System.Drawing.Size(1005, 644);
            this.dataGridPlayers.TabIndex = 7;
            // 
            // txtIncomingText
            // 
            this.txtIncomingText.Location = new System.Drawing.Point(8, 12);
            this.txtIncomingText.Name = "txtIncomingText";
            this.txtIncomingText.Size = new System.Drawing.Size(423, 365);
            this.txtIncomingText.TabIndex = 8;
            this.txtIncomingText.Text = "";
            // 
            // btnViewStats
            // 
            this.btnViewStats.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnViewStats.Location = new System.Drawing.Point(339, 431);
            this.btnViewStats.Name = "btnViewStats";
            this.btnViewStats.Size = new System.Drawing.Size(75, 23);
            this.btnViewStats.TabIndex = 9;
            this.btnViewStats.Text = "View Stats";
            this.btnViewStats.UseVisualStyleBackColor = true;
            this.btnViewStats.Click += new System.EventHandler(this.btnViewStats_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "MinValue";
            // 
            // txtMinValue
            // 
            this.txtMinValue.Location = new System.Drawing.Point(441, 30);
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(100, 20);
            this.txtMinValue.TabIndex = 11;
            this.txtMinValue.Text = "15";
            // 
            // rdoNumberFireDefense
            // 
            this.rdoNumberFireDefense.AutoSize = true;
            this.rdoNumberFireDefense.Location = new System.Drawing.Point(127, 401);
            this.rdoNumberFireDefense.Name = "rdoNumberFireDefense";
            this.rdoNumberFireDefense.Size = new System.Drawing.Size(119, 17);
            this.rdoNumberFireDefense.TabIndex = 12;
            this.rdoNumberFireDefense.TabStop = true;
            this.rdoNumberFireDefense.Text = "NumberFireDefense";
            this.rdoNumberFireDefense.UseVisualStyleBackColor = true;
            // 
            // rdoViewLineups
            // 
            this.rdoViewLineups.Location = new System.Drawing.Point(421, 431);
            this.rdoViewLineups.Name = "rdoViewLineups";
            this.rdoViewLineups.Size = new System.Drawing.Size(85, 23);
            this.rdoViewLineups.TabIndex = 13;
            this.rdoViewLineups.Text = "View Lineups";
            this.rdoViewLineups.UseVisualStyleBackColor = true;
            this.rdoViewLineups.Click += new System.EventHandler(this.rdoViewLineups_Click);
            // 
            // btnResetStats
            // 
            this.btnResetStats.Location = new System.Drawing.Point(8, 460);
            this.btnResetStats.Name = "btnResetStats";
            this.btnResetStats.Size = new System.Drawing.Size(79, 25);
            this.btnResetStats.TabIndex = 14;
            this.btnResetStats.Text = "Reset Stats";
            this.btnResetStats.UseVisualStyleBackColor = true;
            this.btnResetStats.Click += new System.EventHandler(this.btnResetStats_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Min High Score";
            // 
            // txtMinHighScore
            // 
            this.txtMinHighScore.Location = new System.Drawing.Point(441, 73);
            this.txtMinHighScore.Name = "txtMinHighScore";
            this.txtMinHighScore.Size = new System.Drawing.Size(100, 20);
            this.txtMinHighScore.TabIndex = 16;
            // 
            // rdoRotoWire
            // 
            this.rdoRotoWire.AutoSize = true;
            this.rdoRotoWire.Location = new System.Drawing.Point(127, 382);
            this.rdoRotoWire.Name = "rdoRotoWire";
            this.rdoRotoWire.Size = new System.Drawing.Size(107, 17);
            this.rdoRotoWire.TabIndex = 17;
            this.rdoRotoWire.TabStop = true;
            this.rdoRotoWire.Text = "ProFootballFocus";
            this.rdoRotoWire.UseVisualStyleBackColor = true;
            this.rdoRotoWire.CheckedChanged += new System.EventHandler(this.rdoRotoWire_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "QB";
            // 
            // txtQBid
            // 
            this.txtQBid.Location = new System.Drawing.Point(440, 117);
            this.txtQBid.Name = "txtQBid";
            this.txtQBid.Size = new System.Drawing.Size(100, 20);
            this.txtQBid.TabIndex = 19;
            this.txtQBid.Text = "0";
            // 
            // lblRB1
            // 
            this.lblRB1.AutoSize = true;
            this.lblRB1.Location = new System.Drawing.Point(437, 145);
            this.lblRB1.Name = "lblRB1";
            this.lblRB1.Size = new System.Drawing.Size(28, 13);
            this.lblRB1.TabIndex = 20;
            this.lblRB1.Text = "RB1";
            // 
            // txtRB1id
            // 
            this.txtRB1id.Location = new System.Drawing.Point(440, 161);
            this.txtRB1id.Name = "txtRB1id";
            this.txtRB1id.Size = new System.Drawing.Size(100, 20);
            this.txtRB1id.TabIndex = 21;
            this.txtRB1id.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(438, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "WR1";
            // 
            // txtWR1id
            // 
            this.txtWR1id.Location = new System.Drawing.Point(440, 205);
            this.txtWR1id.Name = "txtWR1id";
            this.txtWR1id.Size = new System.Drawing.Size(100, 20);
            this.txtWR1id.TabIndex = 23;
            this.txtWR1id.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "TE";
            // 
            // txtTEid
            // 
            this.txtTEid.Location = new System.Drawing.Point(440, 249);
            this.txtTEid.Name = "txtTEid";
            this.txtTEid.Size = new System.Drawing.Size(100, 20);
            this.txtTEid.TabIndex = 25;
            this.txtTEid.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "D/ST";
            // 
            // txtDEFid
            // 
            this.txtDEFid.Location = new System.Drawing.Point(441, 289);
            this.txtDEFid.Name = "txtDEFid";
            this.txtDEFid.Size = new System.Drawing.Size(100, 20);
            this.txtDEFid.TabIndex = 27;
            this.txtDEFid.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "UTIL";
            // 
            // txtUTILid
            // 
            this.txtUTILid.Location = new System.Drawing.Point(440, 333);
            this.txtUTILid.Name = "txtUTILid";
            this.txtUTILid.Size = new System.Drawing.Size(100, 20);
            this.txtUTILid.TabIndex = 29;
            this.txtUTILid.Text = "0";
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Checked = true;
            this.chkThursday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThursday.Location = new System.Drawing.Point(9, 492);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(70, 17);
            this.chkThursday.TabIndex = 30;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Checked = true;
            this.chkSaturday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaturday.Location = new System.Drawing.Point(85, 492);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(68, 17);
            this.chkSaturday.TabIndex = 31;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Checked = true;
            this.chkSunday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSunday.Location = new System.Drawing.Point(159, 492);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(62, 17);
            this.chkSunday.TabIndex = 32;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Checked = true;
            this.chkMonday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonday.Location = new System.Drawing.Point(227, 492);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(64, 17);
            this.chkMonday.TabIndex = 33;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoDraftKings);
            this.groupBox1.Controls.Add(this.rdoFanDuel);
            this.groupBox1.Location = new System.Drawing.Point(9, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 36);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // rdoDraftKings
            // 
            this.rdoDraftKings.AutoSize = true;
            this.rdoDraftKings.Location = new System.Drawing.Point(99, 13);
            this.rdoDraftKings.Name = "rdoDraftKings";
            this.rdoDraftKings.Size = new System.Drawing.Size(74, 17);
            this.rdoDraftKings.TabIndex = 1;
            this.rdoDraftKings.TabStop = true;
            this.rdoDraftKings.Text = "DraftKings";
            this.rdoDraftKings.UseVisualStyleBackColor = true;
            // 
            // rdoFanDuel
            // 
            this.rdoFanDuel.AutoSize = true;
            this.rdoFanDuel.Checked = true;
            this.rdoFanDuel.Location = new System.Drawing.Point(7, 13);
            this.rdoFanDuel.Name = "rdoFanDuel";
            this.rdoFanDuel.Size = new System.Drawing.Size(65, 17);
            this.rdoFanDuel.TabIndex = 0;
            this.rdoFanDuel.TabStop = true;
            this.rdoFanDuel.Text = "FanDuel";
            this.rdoFanDuel.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 570);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Threads";
            // 
            // txtThreadNumber
            // 
            this.txtThreadNumber.Location = new System.Drawing.Point(61, 567);
            this.txtThreadNumber.Name = "txtThreadNumber";
            this.txtThreadNumber.Size = new System.Drawing.Size(100, 20);
            this.txtThreadNumber.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1551, 644);
            this.Controls.Add(this.txtThreadNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkMonday);
            this.Controls.Add(this.chkSunday);
            this.Controls.Add(this.chkSaturday);
            this.Controls.Add(this.chkThursday);
            this.Controls.Add(this.txtUTILid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDEFid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTEid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWR1id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRB1id);
            this.Controls.Add(this.lblRB1);
            this.Controls.Add(this.txtQBid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoRotoWire);
            this.Controls.Add(this.txtMinHighScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnResetStats);
            this.Controls.Add(this.rdoViewLineups);
            this.Controls.Add(this.rdoNumberFireDefense);
            this.Controls.Add(this.txtMinValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnViewStats);
            this.Controls.Add(this.txtIncomingText);
            this.Controls.Add(this.dataGridPlayers);
            this.Controls.Add(this.btnRunStats);
            this.Controls.Add(this.btnViewPlayers);
            this.Controls.Add(this.btnClearScreen);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rdoNumberFire);
            this.Controls.Add(this.rdoRotoGrinders);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rdoRotoGrinders;
        private System.Windows.Forms.RadioButton rdoNumberFire;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClearScreen;
        private System.Windows.Forms.Button btnViewPlayers;
        private System.Windows.Forms.Button btnRunStats;
        private System.Windows.Forms.DataGridView dataGridPlayers;
        private System.Windows.Forms.RichTextBox txtIncomingText;
        private System.Windows.Forms.Button btnViewStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinValue;
        private System.Windows.Forms.RadioButton rdoNumberFireDefense;
        private System.Windows.Forms.Button rdoViewLineups;
        private System.Windows.Forms.Button btnResetStats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinHighScore;
        private System.Windows.Forms.RadioButton rdoRotoWire;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQBid;
        private System.Windows.Forms.Label lblRB1;
        private System.Windows.Forms.TextBox txtRB1id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWR1id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTEid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDEFid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUTILid;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoDraftKings;
        private System.Windows.Forms.RadioButton rdoFanDuel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtThreadNumber;
    }
}

