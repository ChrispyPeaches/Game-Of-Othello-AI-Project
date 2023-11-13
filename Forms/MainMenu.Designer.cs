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
            this.btn_ChooseColorMenu_Black = new System.Windows.Forms.Button();
            this.btn_ChooseColorMenu_White = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_AI = new System.Windows.Forms.Button();
            this.btn_2Player = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ChooseColorMenu_Black
            // 
            this.btn_ChooseColorMenu_Black.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_ChooseColorMenu_Black.FlatAppearance.BorderSize = 0;
            this.btn_ChooseColorMenu_Black.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChooseColorMenu_Black.Location = new System.Drawing.Point(257, 282);
            this.btn_ChooseColorMenu_Black.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ChooseColorMenu_Black.Name = "btn_ChooseColorMenu_Black";
            this.btn_ChooseColorMenu_Black.Size = new System.Drawing.Size(116, 61);
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
            this.btn_ChooseColorMenu_White.Location = new System.Drawing.Point(373, 282);
            this.btn_ChooseColorMenu_White.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ChooseColorMenu_White.Name = "btn_ChooseColorMenu_White";
            this.btn_ChooseColorMenu_White.Size = new System.Drawing.Size(116, 61);
            this.btn_ChooseColorMenu_White.TabIndex = 4;
            this.btn_ChooseColorMenu_White.Text = "White";
            this.btn_ChooseColorMenu_White.UseVisualStyleBackColor = false;
            this.btn_ChooseColorMenu_White.Click += new System.EventHandler(this.btn_ChooseWhite);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(132, 282);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 61);
            this.button3.TabIndex = 5;
            this.button3.Text = "Choose Player 1 Color";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btn_AI
            // 
            this.btn_AI.BackgroundImage = global::GameOfOthelloAssignment.Properties.Resources.AI_Icon;
            this.btn_AI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AI.Location = new System.Drawing.Point(373, 50);
            this.btn_AI.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AI.Name = "btn_AI";
            this.btn_AI.Size = new System.Drawing.Size(178, 153);
            this.btn_AI.TabIndex = 1;
            this.btn_AI.UseVisualStyleBackColor = true;
            this.btn_AI.Click += new System.EventHandler(this.btn_AI_Click);
            // 
            // btn_2Player
            // 
            this.btn_2Player.BackgroundImage = global::GameOfOthelloAssignment.Properties.Resources._2P_Icon;
            this.btn_2Player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_2Player.Location = new System.Drawing.Point(80, 50);
            this.btn_2Player.Margin = new System.Windows.Forms.Padding(2);
            this.btn_2Player.Name = "btn_2Player";
            this.btn_2Player.Size = new System.Drawing.Size(178, 153);
            this.btn_2Player.TabIndex = 0;
            this.btn_2Player.UseVisualStyleBackColor = true;
            this.btn_2Player.Click += new System.EventHandler(this.btn_2Player_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(80, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Player 1 vs Player 2";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btn_2Player_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(373, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "Player 1 vs AI";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btn_AI_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_ChooseColorMenu_Black);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_ChooseColorMenu_White);
            this.Controls.Add(this.btn_AI);
            this.Controls.Add(this.btn_2Player);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_2Player;
        private System.Windows.Forms.Button btn_AI;
        private System.Windows.Forms.Button btn_ChooseColorMenu_Black;
        private System.Windows.Forms.Button btn_ChooseColorMenu_White;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}