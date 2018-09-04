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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).BeginInit();
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
            this.dataGridPlayers.Location = new System.Drawing.Point(549, 0);
            this.dataGridPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridPlayers.Name = "dataGridPlayers";
            this.dataGridPlayers.RowTemplate.Height = 28;
            this.dataGridPlayers.Size = new System.Drawing.Size(827, 526);
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
            this.txtMinValue.Text = "10";
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
            this.rdoViewLineups.Size = new System.Drawing.Size(75, 23);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1376, 526);
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
    }
}

