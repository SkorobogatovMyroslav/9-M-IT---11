using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._2
{
    public partial class Form1 : Form
    {

        bool turn = true; // true = X turn; false = O turn
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_MouseEnter(object sender, EventArgs e)
        {
            Random rnd = new Random();
            // Вираховуємо нові координати так, щоб кнопка не виходила за межі свого GroupBox
            int x = rnd.Next(0, groupBox1.Width - btnRun.Width);
            int y = rnd.Next(0, groupBox1.Height - btnRun.Height);

            btnRun.Location = new Point(x, y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false; // Disable button after click
            turn_count++;

            CheckForWinner();
        }
        private void CheckForWinner()
        {
            bool there_is_a_winner = false;

            // Horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)) there_is_a_winner = true;

            // Vertical checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)) there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)) there_is_a_winner = true;

            // Diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)) there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled)) there_is_a_winner = true;

            if (there_is_a_winner)
            {
                string winner = turn ? "O" : "X"; // The person who just moved wins
                MessageBox.Show(winner + " Wins!");
                ResetGame();
            }
            else if (turn_count == 9)
            {
                MessageBox.Show("Draw!");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            turn = true;
            turn_count = 0;
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    c.Enabled = true;
                    c.Text = "";
                }
            }
        }

    }
}

