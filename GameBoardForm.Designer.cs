namespace GameOfOthelloAssignment
{
    partial class GameBoardForm
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
            this.othelloBoard = new GameOfOthelloAssignment.OthelloBoard();
            this.panel_CurrentTurnMenu_Container = new System.Windows.Forms.Panel();
            this.btn_CurrentTurnMenu_Detail = new System.Windows.Forms.Button();
            this.pic_currentTurnMenu_piece = new System.Windows.Forms.PictureBox();
            this.btn_CurrentTurnMenu_Title = new System.Windows.Forms.Button();
            this.panel_ScoreMenu_Container = new System.Windows.Forms.Panel();
            this.pic_ScoreMenu_Black = new System.Windows.Forms.PictureBox();
            this.btn_ScoreMenu_Black = new System.Windows.Forms.Button();
            this.pic_ScoreMenu_White = new System.Windows.Forms.PictureBox();
            this.btn_ScoreMenu_White = new System.Windows.Forms.Button();
            this.btn_ScoreMenu_Title = new System.Windows.Forms.Button();
            this.checkBox_DebugMenu_EnableDebug = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_DebugMenu_SearchDepth = new System.Windows.Forms.TextBox();
            this.btn_ScoreMenu_PlayerBlack_Label = new System.Windows.Forms.Button();
            this.btn_ScoreMenu_PlayerWhite_Label = new System.Windows.Forms.Button();
            this.btn_AIThinking_Detail = new System.Windows.Forms.Button();
            this.panel_CurrentTurnMenu_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_currentTurnMenu_piece)).BeginInit();
            this.panel_ScoreMenu_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScoreMenu_Black)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScoreMenu_White)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // othelloBoard
            // 
            this.othelloBoard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.othelloBoard.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.othelloBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.othelloBoard.BlackScore = 0;
            this.othelloBoard.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.othelloBoard.ColumnCount = 8;
            this.othelloBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.gameMode = GameOfOthelloAssignment.NPC.GameMode.TwoPlayer;
            this.othelloBoard.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.othelloBoard.Location = new System.Drawing.Point(170, 2);
            this.othelloBoard.Margin = new System.Windows.Forms.Padding(0);
            this.othelloBoard.Name = "othelloBoard";
            this.othelloBoard.Player1DiscColor = GameOfOthelloAssignment.DiscType.Black;
            this.othelloBoard.RowCount = 8;
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.Size = new System.Drawing.Size(350, 366);
            this.othelloBoard.TabIndex = 0;
            this.othelloBoard.WhiteScore = 0;
            // 
            // panel_CurrentTurnMenu_Container
            // 
            this.panel_CurrentTurnMenu_Container.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_CurrentTurnMenu_Container.Controls.Add(this.btn_CurrentTurnMenu_Detail);
            this.panel_CurrentTurnMenu_Container.Controls.Add(this.pic_currentTurnMenu_piece);
            this.panel_CurrentTurnMenu_Container.Controls.Add(this.btn_CurrentTurnMenu_Title);
            this.panel_CurrentTurnMenu_Container.Location = new System.Drawing.Point(9, 10);
            this.panel_CurrentTurnMenu_Container.Margin = new System.Windows.Forms.Padding(2);
            this.panel_CurrentTurnMenu_Container.Name = "panel_CurrentTurnMenu_Container";
            this.panel_CurrentTurnMenu_Container.Size = new System.Drawing.Size(150, 102);
            this.panel_CurrentTurnMenu_Container.TabIndex = 1;
            // 
            // btn_CurrentTurnMenu_Detail
            // 
            this.btn_CurrentTurnMenu_Detail.BackColor = System.Drawing.Color.Transparent;
            this.btn_CurrentTurnMenu_Detail.Enabled = false;
            this.btn_CurrentTurnMenu_Detail.FlatAppearance.BorderSize = 0;
            this.btn_CurrentTurnMenu_Detail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CurrentTurnMenu_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CurrentTurnMenu_Detail.Location = new System.Drawing.Point(66, 35);
            this.btn_CurrentTurnMenu_Detail.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CurrentTurnMenu_Detail.Name = "btn_CurrentTurnMenu_Detail";
            this.btn_CurrentTurnMenu_Detail.Size = new System.Drawing.Size(82, 58);
            this.btn_CurrentTurnMenu_Detail.TabIndex = 2;
            this.btn_CurrentTurnMenu_Detail.Text = "Black";
            this.btn_CurrentTurnMenu_Detail.UseVisualStyleBackColor = false;
            // 
            // pic_currentTurnMenu_piece
            // 
            this.pic_currentTurnMenu_piece.BackColor = System.Drawing.Color.Transparent;
            this.pic_currentTurnMenu_piece.BackgroundImage = global::GameOfOthelloAssignment.Properties.Resources.black_piece;
            this.pic_currentTurnMenu_piece.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_currentTurnMenu_piece.Enabled = false;
            this.pic_currentTurnMenu_piece.Location = new System.Drawing.Point(8, 35);
            this.pic_currentTurnMenu_piece.Margin = new System.Windows.Forms.Padding(2);
            this.pic_currentTurnMenu_piece.Name = "pic_currentTurnMenu_piece";
            this.pic_currentTurnMenu_piece.Size = new System.Drawing.Size(54, 58);
            this.pic_currentTurnMenu_piece.TabIndex = 2;
            this.pic_currentTurnMenu_piece.TabStop = false;
            // 
            // btn_CurrentTurnMenu_Title
            // 
            this.btn_CurrentTurnMenu_Title.BackColor = System.Drawing.Color.Transparent;
            this.btn_CurrentTurnMenu_Title.FlatAppearance.BorderSize = 0;
            this.btn_CurrentTurnMenu_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CurrentTurnMenu_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CurrentTurnMenu_Title.Location = new System.Drawing.Point(2, 2);
            this.btn_CurrentTurnMenu_Title.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CurrentTurnMenu_Title.Name = "btn_CurrentTurnMenu_Title";
            this.btn_CurrentTurnMenu_Title.Size = new System.Drawing.Size(146, 28);
            this.btn_CurrentTurnMenu_Title.TabIndex = 0;
            this.btn_CurrentTurnMenu_Title.Text = "Current Turn";
            this.btn_CurrentTurnMenu_Title.UseVisualStyleBackColor = false;
            // 
            // panel_ScoreMenu_Container
            // 
            this.panel_ScoreMenu_Container.Controls.Add(this.btn_ScoreMenu_PlayerWhite_Label);
            this.panel_ScoreMenu_Container.Controls.Add(this.btn_ScoreMenu_PlayerBlack_Label);
            this.panel_ScoreMenu_Container.Controls.Add(this.pic_ScoreMenu_Black);
            this.panel_ScoreMenu_Container.Controls.Add(this.btn_ScoreMenu_Black);
            this.panel_ScoreMenu_Container.Controls.Add(this.pic_ScoreMenu_White);
            this.panel_ScoreMenu_Container.Controls.Add(this.btn_ScoreMenu_White);
            this.panel_ScoreMenu_Container.Controls.Add(this.btn_ScoreMenu_Title);
            this.panel_ScoreMenu_Container.Location = new System.Drawing.Point(532, 10);
            this.panel_ScoreMenu_Container.Margin = new System.Windows.Forms.Padding(2);
            this.panel_ScoreMenu_Container.Name = "panel_ScoreMenu_Container";
            this.panel_ScoreMenu_Container.Size = new System.Drawing.Size(150, 157);
            this.panel_ScoreMenu_Container.TabIndex = 2;
            // 
            // pic_ScoreMenu_Black
            // 
            this.pic_ScoreMenu_Black.BackColor = System.Drawing.Color.Transparent;
            this.pic_ScoreMenu_Black.BackgroundImage = global::GameOfOthelloAssignment.Properties.Resources.black_piece;
            this.pic_ScoreMenu_Black.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_ScoreMenu_Black.Enabled = false;
            this.pic_ScoreMenu_Black.Location = new System.Drawing.Point(69, 54);
            this.pic_ScoreMenu_Black.Margin = new System.Windows.Forms.Padding(2);
            this.pic_ScoreMenu_Black.Name = "pic_ScoreMenu_Black";
            this.pic_ScoreMenu_Black.Size = new System.Drawing.Size(36, 39);
            this.pic_ScoreMenu_Black.TabIndex = 4;
            this.pic_ScoreMenu_Black.TabStop = false;
            // 
            // btn_ScoreMenu_Black
            // 
            this.btn_ScoreMenu_Black.BackColor = System.Drawing.Color.Transparent;
            this.btn_ScoreMenu_Black.Enabled = false;
            this.btn_ScoreMenu_Black.FlatAppearance.BorderSize = 0;
            this.btn_ScoreMenu_Black.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ScoreMenu_Black.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ScoreMenu_Black.Location = new System.Drawing.Point(109, 54);
            this.btn_ScoreMenu_Black.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ScoreMenu_Black.Name = "btn_ScoreMenu_Black";
            this.btn_ScoreMenu_Black.Size = new System.Drawing.Size(38, 39);
            this.btn_ScoreMenu_Black.TabIndex = 5;
            this.btn_ScoreMenu_Black.Text = "2";
            this.btn_ScoreMenu_Black.UseVisualStyleBackColor = false;
            // 
            // pic_ScoreMenu_White
            // 
            this.pic_ScoreMenu_White.BackColor = System.Drawing.Color.Transparent;
            this.pic_ScoreMenu_White.BackgroundImage = global::GameOfOthelloAssignment.Properties.Resources.white_piece;
            this.pic_ScoreMenu_White.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_ScoreMenu_White.Enabled = false;
            this.pic_ScoreMenu_White.Location = new System.Drawing.Point(69, 103);
            this.pic_ScoreMenu_White.Margin = new System.Windows.Forms.Padding(2);
            this.pic_ScoreMenu_White.Name = "pic_ScoreMenu_White";
            this.pic_ScoreMenu_White.Size = new System.Drawing.Size(36, 39);
            this.pic_ScoreMenu_White.TabIndex = 3;
            this.pic_ScoreMenu_White.TabStop = false;
            // 
            // btn_ScoreMenu_White
            // 
            this.btn_ScoreMenu_White.BackColor = System.Drawing.Color.Transparent;
            this.btn_ScoreMenu_White.Enabled = false;
            this.btn_ScoreMenu_White.FlatAppearance.BorderSize = 0;
            this.btn_ScoreMenu_White.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ScoreMenu_White.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ScoreMenu_White.Location = new System.Drawing.Point(109, 103);
            this.btn_ScoreMenu_White.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ScoreMenu_White.Name = "btn_ScoreMenu_White";
            this.btn_ScoreMenu_White.Size = new System.Drawing.Size(38, 39);
            this.btn_ScoreMenu_White.TabIndex = 3;
            this.btn_ScoreMenu_White.Text = "2";
            this.btn_ScoreMenu_White.UseVisualStyleBackColor = false;
            // 
            // btn_ScoreMenu_Title
            // 
            this.btn_ScoreMenu_Title.BackColor = System.Drawing.Color.Transparent;
            this.btn_ScoreMenu_Title.FlatAppearance.BorderSize = 0;
            this.btn_ScoreMenu_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ScoreMenu_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ScoreMenu_Title.Location = new System.Drawing.Point(2, 2);
            this.btn_ScoreMenu_Title.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ScoreMenu_Title.Name = "btn_ScoreMenu_Title";
            this.btn_ScoreMenu_Title.Size = new System.Drawing.Size(146, 28);
            this.btn_ScoreMenu_Title.TabIndex = 3;
            this.btn_ScoreMenu_Title.Text = "Score";
            this.btn_ScoreMenu_Title.UseVisualStyleBackColor = false;
            // 
            // checkBox_DebugMenu_EnableDebug
            // 
            this.checkBox_DebugMenu_EnableDebug.AutoSize = true;
            this.checkBox_DebugMenu_EnableDebug.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_DebugMenu_EnableDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_DebugMenu_EnableDebug.Location = new System.Drawing.Point(24, 13);
            this.checkBox_DebugMenu_EnableDebug.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_DebugMenu_EnableDebug.Name = "checkBox_DebugMenu_EnableDebug";
            this.checkBox_DebugMenu_EnableDebug.Size = new System.Drawing.Size(15, 14);
            this.checkBox_DebugMenu_EnableDebug.TabIndex = 3;
            this.checkBox_DebugMenu_EnableDebug.UseVisualStyleBackColor = false;
            this.checkBox_DebugMenu_EnableDebug.CheckedChanged += new System.EventHandler(this.checkBox_DebugMenu_EnableDebug_CheckedChanged);
            this.checkBox_DebugMenu_EnableDebug.CheckStateChanged += new System.EventHandler(this.checkBox_DebugMenu_EnableDebug_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox_DebugMenu_SearchDepth);
            this.panel1.Controls.Add(this.checkBox_DebugMenu_EnableDebug);
            this.panel1.Location = new System.Drawing.Point(532, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 77);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(39, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Enable Debug";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(39, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search Depth";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox_DebugMenu_SearchDepth
            // 
            this.textBox_DebugMenu_SearchDepth.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_DebugMenu_SearchDepth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_DebugMenu_SearchDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DebugMenu_SearchDepth.Location = new System.Drawing.Point(9, 46);
            this.textBox_DebugMenu_SearchDepth.MaxLength = 3;
            this.textBox_DebugMenu_SearchDepth.Name = "textBox_DebugMenu_SearchDepth";
            this.textBox_DebugMenu_SearchDepth.Size = new System.Drawing.Size(30, 16);
            this.textBox_DebugMenu_SearchDepth.TabIndex = 5;
            this.textBox_DebugMenu_SearchDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_DebugMenu_SearchDepth.WordWrap = false;
            this.textBox_DebugMenu_SearchDepth.TextChanged += new System.EventHandler(this.textBox_DebugMenu_SearchDepth_ChangeValue);
            this.textBox_DebugMenu_SearchDepth.Leave += new System.EventHandler(this.textBox_DebugMenu_SearchDepth_ChangeValue);
            // 
            // btn_ScoreMenu_PlayerBlack_Label
            // 
            this.btn_ScoreMenu_PlayerBlack_Label.FlatAppearance.BorderSize = 0;
            this.btn_ScoreMenu_PlayerBlack_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ScoreMenu_PlayerBlack_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ScoreMenu_PlayerBlack_Label.Location = new System.Drawing.Point(3, 51);
            this.btn_ScoreMenu_PlayerBlack_Label.Name = "btn_ScoreMenu_PlayerBlack_Label";
            this.btn_ScoreMenu_PlayerBlack_Label.Size = new System.Drawing.Size(61, 48);
            this.btn_ScoreMenu_PlayerBlack_Label.TabIndex = 7;
            this.btn_ScoreMenu_PlayerBlack_Label.Text = "Player Black";
            this.btn_ScoreMenu_PlayerBlack_Label.UseVisualStyleBackColor = true;
            // 
            // btn_ScoreMenu_PlayerWhite_Label
            // 
            this.btn_ScoreMenu_PlayerWhite_Label.FlatAppearance.BorderSize = 0;
            this.btn_ScoreMenu_PlayerWhite_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ScoreMenu_PlayerWhite_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ScoreMenu_PlayerWhite_Label.Location = new System.Drawing.Point(3, 100);
            this.btn_ScoreMenu_PlayerWhite_Label.Name = "btn_ScoreMenu_PlayerWhite_Label";
            this.btn_ScoreMenu_PlayerWhite_Label.Size = new System.Drawing.Size(61, 48);
            this.btn_ScoreMenu_PlayerWhite_Label.TabIndex = 8;
            this.btn_ScoreMenu_PlayerWhite_Label.Text = "Player White";
            this.btn_ScoreMenu_PlayerWhite_Label.UseVisualStyleBackColor = true;
            // 
            // btn_AIThinking_Detail
            // 
            this.btn_AIThinking_Detail.BackColor = System.Drawing.Color.Transparent;
            this.btn_AIThinking_Detail.FlatAppearance.BorderSize = 0;
            this.btn_AIThinking_Detail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AIThinking_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AIThinking_Detail.Location = new System.Drawing.Point(12, 123);
            this.btn_AIThinking_Detail.Name = "btn_AIThinking_Detail";
            this.btn_AIThinking_Detail.Size = new System.Drawing.Size(147, 35);
            this.btn_AIThinking_Detail.TabIndex = 5;
            this.btn_AIThinking_Detail.Text = "Thinking...";
            this.btn_AIThinking_Detail.UseVisualStyleBackColor = false;
            this.btn_AIThinking_Detail.Visible = false;
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(692, 366);
            this.Controls.Add(this.btn_AIThinking_Detail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_ScoreMenu_Container);
            this.Controls.Add(this.panel_CurrentTurnMenu_Container);
            this.Controls.Add(this.othelloBoard);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameBoardForm";
            this.Text = "Othello";
            this.panel_CurrentTurnMenu_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_currentTurnMenu_piece)).EndInit();
            this.panel_ScoreMenu_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScoreMenu_Black)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScoreMenu_White)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OthelloBoard othelloBoard;
        private System.Windows.Forms.Panel panel_CurrentTurnMenu_Container;
        private System.Windows.Forms.PictureBox pic_currentTurnMenu_piece;
        private System.Windows.Forms.Button btn_CurrentTurnMenu_Title;
        private System.Windows.Forms.Button btn_CurrentTurnMenu_Detail;
        private System.Windows.Forms.Panel panel_ScoreMenu_Container;
        private System.Windows.Forms.Button btn_ScoreMenu_Title;
        private System.Windows.Forms.PictureBox pic_ScoreMenu_Black;
        private System.Windows.Forms.Button btn_ScoreMenu_Black;
        private System.Windows.Forms.PictureBox pic_ScoreMenu_White;
        private System.Windows.Forms.Button btn_ScoreMenu_White;
        private System.Windows.Forms.CheckBox checkBox_DebugMenu_EnableDebug;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_DebugMenu_SearchDepth;
        private System.Windows.Forms.Button btn_ScoreMenu_PlayerWhite_Label;
        private System.Windows.Forms.Button btn_ScoreMenu_PlayerBlack_Label;
        private System.Windows.Forms.Button btn_AIThinking_Detail;
    }
}

