namespace TetrisWFA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MainPanel = new Panel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            NextPanel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            NextPanel2 = new Panel();
            NextPanel3 = new Panel();
            LinesLabel = new Label();
            scoreLabel = new Label();
            mainTimer = new System.Windows.Forms.Timer(components);
            gameOverPanel = new Panel();
            gameOverScoreLabel = new Label();
            label6 = new Label();
            label5 = new Label();
            exitButton = new Button();
            newGameButton = new Button();
            statusStrip1.SuspendLayout();
            gameOverPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Location = new Point(12, 12);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(402, 602);
            MainPanel.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 639);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(579, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(118, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // NextPanel1
            // 
            NextPanel1.Location = new Point(446, 42);
            NextPanel1.Name = "NextPanel1";
            NextPanel1.Size = new Size(80, 80);
            NextPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(444, 12);
            label1.Name = "label1";
            label1.Size = new Size(51, 21);
            label1.TabIndex = 3;
            label1.Text = "NEXT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(434, 483);
            label2.Name = "label2";
            label2.Size = new Size(54, 21);
            label2.TabIndex = 4;
            label2.Text = "LINES";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(434, 552);
            label3.Name = "label3";
            label3.Size = new Size(60, 21);
            label3.TabIndex = 6;
            label3.Text = "SCORE";
            // 
            // NextPanel2
            // 
            NextPanel2.Location = new Point(446, 138);
            NextPanel2.Name = "NextPanel2";
            NextPanel2.Size = new Size(80, 80);
            NextPanel2.TabIndex = 3;
            // 
            // NextPanel3
            // 
            NextPanel3.Location = new Point(446, 234);
            NextPanel3.Name = "NextPanel3";
            NextPanel3.Size = new Size(80, 80);
            NextPanel3.TabIndex = 8;
            // 
            // LinesLabel
            // 
            LinesLabel.BorderStyle = BorderStyle.FixedSingle;
            LinesLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LinesLabel.ForeColor = SystemColors.ControlText;
            LinesLabel.Location = new Point(434, 508);
            LinesLabel.Name = "LinesLabel";
            LinesLabel.Size = new Size(125, 36);
            LinesLabel.TabIndex = 9;
            LinesLabel.Text = "1234";
            LinesLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // scoreLabel
            // 
            scoreLabel.BorderStyle = BorderStyle.FixedSingle;
            scoreLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            scoreLabel.Location = new Point(434, 577);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(125, 36);
            scoreLabel.TabIndex = 10;
            scoreLabel.Text = "1234";
            scoreLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // mainTimer
            // 
            mainTimer.Interval = 1000;
            mainTimer.Tick += mainTimer_Tick;
            // 
            // gameOverPanel
            // 
            gameOverPanel.BorderStyle = BorderStyle.FixedSingle;
            gameOverPanel.Controls.Add(gameOverScoreLabel);
            gameOverPanel.Controls.Add(label6);
            gameOverPanel.Controls.Add(label5);
            gameOverPanel.Controls.Add(exitButton);
            gameOverPanel.Controls.Add(newGameButton);
            gameOverPanel.Location = new Point(78, 97);
            gameOverPanel.Name = "gameOverPanel";
            gameOverPanel.Size = new Size(395, 226);
            gameOverPanel.TabIndex = 11;
            gameOverPanel.Visible = false;
            // 
            // gameOverScoreLabel
            // 
            gameOverScoreLabel.AutoSize = true;
            gameOverScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gameOverScoreLabel.Location = new Point(188, 72);
            gameOverScoreLabel.Name = "gameOverScoreLabel";
            gameOverScoreLabel.Size = new Size(172, 21);
            gameOverScoreLabel.TabIndex = 4;
            gameOverScoreLabel.Text = "gameOverScoreLabel";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(108, 72);
            label6.Name = "label6";
            label6.Size = new Size(56, 21);
            label6.TabIndex = 3;
            label6.Text = "Score:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label5.Location = new Point(127, 28);
            label5.Name = "label5";
            label5.Size = new Size(141, 30);
            label5.TabIndex = 2;
            label5.Text = "GAME OVER";
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            exitButton.Location = new Point(217, 157);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 33);
            exitButton.TabIndex = 1;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // newGameButton
            // 
            newGameButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            newGameButton.Location = new Point(74, 157);
            newGameButton.Name = "newGameButton";
            newGameButton.Size = new Size(122, 33);
            newGameButton.TabIndex = 0;
            newGameButton.Text = "New Game";
            newGameButton.UseVisualStyleBackColor = true;
            newGameButton.Click += newGameButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 661);
            Controls.Add(gameOverPanel);
            Controls.Add(scoreLabel);
            Controls.Add(LinesLabel);
            Controls.Add(NextPanel3);
            Controls.Add(NextPanel2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NextPanel1);
            Controls.Add(statusStrip1);
            Controls.Add(MainPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            gameOverPanel.ResumeLayout(false);
            gameOverPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel MainPanel;
        private StatusStrip statusStrip1;
        private Panel NextPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Panel NextPanel2;
        private Panel NextPanel3;
        private Label LinesLabel;
        private Label scoreLabel;
        private System.Windows.Forms.Timer mainTimer;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Panel gameOverPanel;
        private Label label5;
        private Button exitButton;
        private Button newGameButton;
        private Label gameOverScoreLabel;
        private Label label6;
    }
}
