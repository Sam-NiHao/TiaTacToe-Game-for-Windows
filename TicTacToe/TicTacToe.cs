using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        bool whoseTurn = true; // true = x; false = o
        int turnCount = 0;

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void AboutMenuClick(object sender, EventArgs e)
        {
            MessageBox.Show("Все права разрешены.", "About Tic Tac Toe Game");
        }
        private void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            WriteButtonText(button);
                
            whoseTurn = !whoseTurn;
            button.Enabled = false;
            turnCount++;

            CheackForWinner();

            label1.Focus();
        }
        private void WriteButtonText(Button button)
        {
            if (whoseTurn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }
        }
        private void CheackForWinner()
        {
            bool haveWinner = FindWinner();

            if (haveWinner)
            {
                DisableButtons();

                MessageBox.Show(ReturnWinner() + " Wins");
            }
            else
            {
                ReturnDraw();
            }
        }
        private string ReturnWinner()
        {
            string winner = "";

            if (whoseTurn)
            {
                winner = textBoxPlayer2.Text;
                oWinsCount.Text = ((Int32.Parse(oWinsCount.Text) + 1)).ToString();
                return winner;
            }
            else
            {
                winner = textBoxPlayer1.Text;
                xWinsCount.Text = ((Int32.Parse(xWinsCount.Text) + 1)).ToString();
                return winner;
            }
        }
        private void ReturnDraw()
        {
            int maximumFields = 9;

            if (turnCount == maximumFields)
            {
                MessageBox.Show("Draw!", "Wooow");
                drawWinsCount.Text = ((Int32.Parse(drawWinsCount.Text) + 1)).ToString();
            }
        }
        private bool FindWinner()
        {
            return HorizontalCheck();
        }
        private bool HorizontalCheck()
        {
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                return true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                return true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                return true;
            }
            else
            {
                return VerticalCheck();
            }
        }
        private bool VerticalCheck()
        {
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                return true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                return true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                return true;
            }
            else
            {
                return DiagonalCheck();
            }
        }
        private bool DiagonalCheck()
        {
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                return true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DisableButtons()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button button = (Button)c;
                    button.Enabled = false;
                    buttonStartNewGame.Enabled = true;
                }
                catch { }
            }
        }
        private void StartNewGame(object sender, EventArgs e)
        {
            whoseTurn = true;
            turnCount = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button button = (Button)c;
                    button.Enabled = true;
                    button.Text = "";
                    buttonStartNewGame.Text = "New Game";
                }
                catch { }
            }
        }
        private void MouseEnterMethod(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Enabled)
            {
                WriteButtonText(button);
            }
        }
        private void MouseLeaveMethod(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Enabled)
            {
                button.Text = "";
            }
        }
        private void ResetCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xWinsCount.Text = "0";
            oWinsCount.Text = "0";
            drawWinsCount.Text = "0";
        }
    }
}
