namespace GameOfOthelloAssignment
{
    partial class MainMenu
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
            this.btn_2Player = new System.Windows.Forms.Button();
            this.btn_AI = new System.Windows.Forms.Button();
            this.btn_ChooseColorMenu_Black = new System.Windows.Forms.Button();
            this.btn_ChooseColorMenu_White = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_2Player
            // 
            this.btn_2Player.Location = new System.Drawing.Point(221, 156);
            this.btn_2Player.Name = "btn_2Player";
            this.btn_2Player.Size = new System.Drawing.Size(165, 110);
            this.btn_2Player.TabIndex = 0;
            this.btn_2Player.Text = "Player 1 vs Player 2";
            this.btn_2Player.UseVisualStyleBackColor = true;
            this.btn_2Player.Click += new System.EventHandler(this.btn_2Player_Click);
            // 
            // btn_AI
            // 
            this.btn_AI.Location = new System.Drawing.Point(432, 156);
            this.btn_AI.Name = "btn_AI";
            this.btn_AI.Size = new System.Drawing.Size(165, 110);
            this.btn_AI.TabIndex = 1;
            this.btn_AI.Text = "Player 1 vs AI";
            this.btn_AI.UseVisualStyleBackColor = true;
            this.btn_AI.Click += new System.EventHandler(this.btn_AI_Click);
            // 
            // btn_ChooseColorMenu_Black
            // 
            this.btn_ChooseColorMenu_Black.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_ChooseColorMenu_Black.FlatAppearance.BorderSize = 0;
            this.btn_ChooseColorMenu_Black.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChooseColorMenu_Black.Location = new System.Drawing.Point(352, 347);
            this.btn_ChooseColorMenu_Black.Name = "btn_ChooseColorMenu_Black";
            this.btn_ChooseColorMenu_Black.Size = new System.Drawing.Size(125, 75);
            this.btn_ChooseColorMenu_Black.TabIndex = 3;
            this.btn_ChooseColorMenu_Black.Text = "Black";
            this.btn_ChooseColorMenu_Black.UseVisualStyleBackColor = false;
            this.btn_ChooseColorMenu_Black.Click += new System.EventHandler(this.btn_ChooseBlack);
            // 
            // btn_ChooseColorMenu_White
            // 
            this.btn_ChooseColorMenu_White.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ChooseColorMenu_White.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ChooseColorMenu_White.FlatAppearance.BorderSize = 0;
            this.btn_ChooseColorMenu_White.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChooseColorMenu_White.Location = new System.Drawing.Point(472, 347);
            this.btn_ChooseColorMenu_White.Name = "btn_ChooseColorMenu_White";
            this.btn_ChooseColorMenu_White.Size = new System.Drawing.Size(125, 75);
            this.btn_ChooseColorMenu_White.TabIndex = 4;
            this.btn_ChooseColorMenu_White.Text = "White";
            this.btn_ChooseColorMenu_White.UseVisualStyleBackColor = false;
            this.btn_ChooseColorMenu_White.Click += new System.EventHandler(this.btn_ChooseWhite);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(221, 347);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 75);
            this.button3.TabIndex = 5;
            this.button3.Text = "Choose Color";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_ChooseColorMenu_White);
            this.Controls.Add(this.btn_ChooseColorMenu_Black);
            this.Controls.Add(this.btn_AI);
            this.Controls.Add(this.btn_2Player);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_2Player;
        private System.Windows.Forms.Button btn_AI;
        private System.Windows.Forms.Button btn_ChooseColorMenu_Black;
        private System.Windows.Forms.Button btn_ChooseColorMenu_White;
        private System.Windows.Forms.Button button3;
    }
}