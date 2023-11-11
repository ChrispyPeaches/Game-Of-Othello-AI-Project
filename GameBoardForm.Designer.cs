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
            this.panel_CurrentTurnMenu_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_currentTurnMenu_piece)).BeginInit();
            this.panel_ScoreMenu_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScoreMenu_Black)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScoreMenu_White)).BeginInit();
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
            this.othelloBoard.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.othelloBoard.Location = new System.Drawing.Point(227, 3);
            this.othelloBoard.Margin = new System.Windows.Forms.Padding(0);
            this.othelloBoard.Name = "othelloBoard";
            this.othelloBoard.RowCount = 8;
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.othelloBoard.Size = new System.Drawing.Size(466, 451);
            this.othelloBoard.TabIndex = 0;
            this.othelloBoard.WhiteScore = 0;
            // 
            // panel_CurrentTurnMenu_Container
            // 
            this.panel_CurrentTurnMenu_Container.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_CurrentTurnMenu_Container.Controls.Add(this.btn_CurrentTurnMenu_Detail);
            this.panel_CurrentTurnMenu_Container.Controls.Add(this.pic_currentTurnMenu_piece);
            this.panel_CurrentTurnMenu_Container.Controls.Add(this.btn_CurrentTurnMenu_Title);
            this.panel_CurrentTurnMenu_Container.Location = new System.Drawing.Point(12, 12);
            this.panel_CurrentTurnMenu_Container.Name = "panel_CurrentTurnMenu_Container";
            this.panel_CurrentTurnMenu_Container.Size = new System.Drawing.Size(200, 125);
            this.panel_CurrentTurnMenu_Container.TabIndex = 1;
            // 
            // btn_CurrentTurnMenu_Detail
            // 
            this.btn_CurrentTurnMenu_Detail.BackColor = System.Drawing.Color.Transparent;
            this.btn_CurrentTurnMenu_Detail.Enabled = false;
            this.btn_CurrentTurnMenu_Detail.FlatAppearance.BorderSize = 0;
            this.btn_CurrentTurnMenu_Detail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CurrentTurnMenu_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CurrentTurnMenu_Detail.Location = new System.Drawing.Point(88, 43);
            this.btn_CurrentTurnMenu_Detail.Name = "btn_CurrentTurnMenu_Detail";
            this.btn_CurrentTurnMenu_Detail.Size = new System.Drawing.Size(109, 72);
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
            this.pic_currentTurnMenu_piece.Location = new System.Drawing.Point(10, 43);
            this.pic_currentTurnMenu_piece.Name = "pic_currentTurnMenu_piece";
            this.pic_currentTurnMenu_piece.Size = new System.Drawing.Size(72, 72);
            this.pic_currentTurnMenu_piece.TabIndex = 2;
            this.pic_currentTurnMenu_piece.TabStop = false;
            // 
            // btn_CurrentTurnMenu_Title
            // 
            this.btn_CurrentTurnMenu_Title.BackColor = System.Drawing.Color.Transparent;
            this.btn_CurrentTurnMenu_Title.FlatAppearance.BorderSize = 0;
            this.btn_CurrentTurnMenu_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CurrentTurnMenu_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CurrentTurnMenu_Title.Location = new System.Drawing.Point(3, 3);
            this.btn_CurrentTurnMenu_Title.Name = "btn_CurrentTurnMenu_Title";
            this.btn_CurrentTurnMenu_Title.Size = new System.Drawing.Size(194, 34);
            this.btn_CurrentTurnMenu_Title.TabIndex = 0;
            this.btn_CurrentTurnMenu_Title.Text = "Current Turn";
            this.btn_CurrentTurnMenu_Title.UseVisualStyleBackColor = false;
            // 
            // panel_ScoreMenu_Container
            // 
            this.panel_ScoreMenu_Container.Controls.Add(this.pic_ScoreMenu_Black);
            this.panel_ScoreMenu_Container.Controls.Add(this.btn_ScoreMenu_Black);
            this.panel_ScoreMenu_Container.Controls.Add(this.pic_ScoreMenu_White);
            this.panel_ScoreMenu_Container.Controls.Add(this.btn_ScoreMenu_White);
            this.panel_ScoreMenu_Container.Controls.Add(this.btn_ScoreMenu_Title);
            this.panel_ScoreMenu_Container.Location = new System.Drawing.Point(710, 12);
            this.panel_ScoreMenu_Container.Name = "panel_ScoreMenu_Container";
            this.panel_ScoreMenu_Container.Size = new System.Drawing.Size(200, 212);
            this.panel_ScoreMenu_Container.TabIndex = 2;
            // 
            // pic_ScoreMenu_Black
            // 
            this.pic_ScoreMenu_Black.BackColor = System.Drawing.Color.Transparent;
            this.pic_ScoreMenu_Black.BackgroundImage = global::GameOfOthelloAssignment.Properties.Resources.black_piece;
            this.pic_ScoreMenu_Black.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_ScoreMenu_Black.Enabled = false;
            this.pic_ScoreMenu_Black.Location = new System.Drawing.Point(12, 54);
            this.pic_ScoreMenu_Black.Name = "pic_ScoreMenu_Black";
            this.pic_ScoreMenu_Black.Size = new System.Drawing.Size(68, 68);
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
            this.btn_ScoreMenu_Black.Location = new System.Drawing.Point(106, 54);
            this.btn_ScoreMenu_Black.Name = "btn_ScoreMenu_Black";
            this.btn_ScoreMenu_Black.Size = new System.Drawing.Size(72, 68);
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
            this.pic_ScoreMenu_White.Location = new System.Drawing.Point(12, 132);
            this.pic_ScoreMenu_White.Name = "pic_ScoreMenu_White";
            this.pic_ScoreMenu_White.Size = new System.Drawing.Size(68, 68);
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
            this.btn_ScoreMenu_White.Location = new System.Drawing.Point(106, 132);
            this.btn_ScoreMenu_White.Name = "btn_ScoreMenu_White";
            this.btn_ScoreMenu_White.Size = new System.Drawing.Size(72, 68);
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
            this.btn_ScoreMenu_Title.Location = new System.Drawing.Point(3, 3);
            this.btn_ScoreMenu_Title.Name = "btn_ScoreMenu_Title";
            this.btn_ScoreMenu_Title.Size = new System.Drawing.Size(194, 34);
            this.btn_ScoreMenu_Title.TabIndex = 3;
            this.btn_ScoreMenu_Title.Text = "Score";
            this.btn_ScoreMenu_Title.UseVisualStyleBackColor = false;
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(922, 450);
            this.Controls.Add(this.panel_ScoreMenu_Container);
            this.Controls.Add(this.panel_CurrentTurnMenu_Container);
            this.Controls.Add(this.othelloBoard);
            this.Name = "GameBoardForm";
            this.Text = "Othello";
            this.panel_CurrentTurnMenu_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_currentTurnMenu_piece)).EndInit();
            this.panel_ScoreMenu_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScoreMenu_Black)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScoreMenu_White)).EndInit();
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
    }
}

