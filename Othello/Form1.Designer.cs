namespace WindowsFormsApplication1
{
    partial class Othello
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyBlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumBlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.blackLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.whiteLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.hardBlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardWhiteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.whiteToolStripMenuItem,
            this.twoPlayerToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyBlackToolStripMenuItem,
            this.mediumBlackToolStripMenuItem,
            this.hardBlackToolStripMenuItem});
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blackToolStripMenuItem.Text = "Human Black";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
            // 
            // easyBlackToolStripMenuItem
            // 
            this.easyBlackToolStripMenuItem.Name = "easyBlackToolStripMenuItem";
            this.easyBlackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.easyBlackToolStripMenuItem.Text = "Easy";
            this.easyBlackToolStripMenuItem.Click += new System.EventHandler(this.easyBlackToolStripMenuItem_Click);
            // 
            // mediumBlackToolStripMenuItem
            // 
            this.mediumBlackToolStripMenuItem.Name = "mediumBlackToolStripMenuItem";
            this.mediumBlackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediumBlackToolStripMenuItem.Text = "Medium";
            this.mediumBlackToolStripMenuItem.Click += new System.EventHandler(this.mediumBlackToolStripMenuItem_Click);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyWhiteToolStripMenuItem,
            this.mediumWhiteToolStripMenuItem,
            this.hardWhiteToolStripMenuItem1});
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.whiteToolStripMenuItem.Text = "Human White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // easyWhiteToolStripMenuItem
            // 
            this.easyWhiteToolStripMenuItem.Name = "easyWhiteToolStripMenuItem";
            this.easyWhiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.easyWhiteToolStripMenuItem.Text = "Easy";
            this.easyWhiteToolStripMenuItem.Click += new System.EventHandler(this.easyWhiteToolStripMenuItem_Click);
            // 
            // mediumWhiteToolStripMenuItem
            // 
            this.mediumWhiteToolStripMenuItem.Name = "mediumWhiteToolStripMenuItem";
            this.mediumWhiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediumWhiteToolStripMenuItem.Text = "Medium";
            this.mediumWhiteToolStripMenuItem.Click += new System.EventHandler(this.mediumWhiteToolStripMenuItem_Click);
            // 
            // twoPlayerToolStripMenuItem
            // 
            this.twoPlayerToolStripMenuItem.Name = "twoPlayerToolStripMenuItem";
            this.twoPlayerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.twoPlayerToolStripMenuItem.Text = "Two Player";
            this.twoPlayerToolStripMenuItem.Click += new System.EventHandler(this.twoPlayerToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label1.Location = new System.Drawing.Point(454, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Black:";
            // 
            // blackLabel
            // 
            this.blackLabel.AutoSize = true;
            this.blackLabel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.blackLabel.Location = new System.Drawing.Point(497, 4);
            this.blackLabel.Name = "blackLabel";
            this.blackLabel.Size = new System.Drawing.Size(13, 13);
            this.blackLabel.TabIndex = 3;
            this.blackLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label3.Location = new System.Drawing.Point(571, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "White:";
            // 
            // whiteLabel
            // 
            this.whiteLabel.AutoSize = true;
            this.whiteLabel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.whiteLabel.Location = new System.Drawing.Point(615, 4);
            this.whiteLabel.Name = "whiteLabel";
            this.whiteLabel.Size = new System.Drawing.Size(13, 13);
            this.whiteLabel.TabIndex = 5;
            this.whiteLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Turn:";
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Location = new System.Drawing.Point(250, 4);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(0, 13);
            this.turnLabel.TabIndex = 7;
            // 
            // hardBlackToolStripMenuItem
            // 
            this.hardBlackToolStripMenuItem.Name = "hardBlackToolStripMenuItem";
            this.hardBlackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hardBlackToolStripMenuItem.Text = "Hard";
            this.hardBlackToolStripMenuItem.Click += new System.EventHandler(this.hardBlackToolStripMenuItem_Click);
            // 
            // hardWhiteToolStripMenuItem1
            // 
            this.hardWhiteToolStripMenuItem1.Name = "hardWhiteToolStripMenuItem1";
            this.hardWhiteToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.hardWhiteToolStripMenuItem1.Text = "Hard";
            this.hardWhiteToolStripMenuItem1.Click += new System.EventHandler(this.hardWhiteToolStripMenuItem1_Click);
            // 
            // Othello
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 832);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.whiteLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.blackLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(820, 870);
            this.MinimumSize = new System.Drawing.Size(820, 870);
            this.Name = "Othello";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Othello";
            this.Load += new System.EventHandler(this.Othello_Load_1);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Othello_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Othello_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label blackLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label whiteLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.ToolStripMenuItem twoPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyBlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumBlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardBlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardWhiteToolStripMenuItem1;
    }
}

