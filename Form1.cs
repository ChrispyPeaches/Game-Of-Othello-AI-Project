﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            for (int rowIndex = 0; rowIndex < othelloBoard1.RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < othelloBoard1.ColumnCount; columnIndex++)
                {
                    othelloBoard1.Controls.Add(new DiscSpace(), columnIndex, rowIndex);
                }
            }
            GameSetup();
        }

        public void GameSetup()
        {
            ClearGameBoard();
            othelloBoard1.GetDiscSpace(3, 3).SetDisc(new Disc(DiscType.White));
            othelloBoard1.GetDiscSpace(3, 4).SetDisc(new Disc(DiscType.Black));
            othelloBoard1.GetDiscSpace(4, 3).SetDisc(new Disc(DiscType.Black));
            othelloBoard1.GetDiscSpace(4, 4).SetDisc(new Disc(DiscType.White));
        }

        public void ClearGameBoard()
        {
            foreach (DiscSpace discSpace in othelloBoard1.Controls)
            {
                discSpace.SetDisc(null);
            }
        }
    }
}
