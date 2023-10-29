using System;
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
            
            for (int rowIndex = 0; rowIndex < tableLayoutPanel1.RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < tableLayoutPanel1.ColumnCount; columnIndex++)
                {
                    tableLayoutPanel1.Controls.Add(new DiscSpace(), columnIndex, rowIndex);
                }
            }
        }

        public void GameSetup()
        {
            ClearGameBoard();

        }

        public void ClearGameBoard()
        {
            foreach (DiscSpace discSpace in tableLayoutPanel1.Controls)
            {
                discSpace.SetDisc(null);
            }
        }

        public void clickPanel(object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;

            var position = tableLayoutPanel1.GetCellPosition((Panel)sender);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
