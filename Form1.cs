using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Properties;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum enPlayer
        { 
            Player1,
            Player2
        }

        enum enWinner
        { 
            Player1,
            Player2,
            InProgress,
            Draw
        
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        stGameStatus GameStatus;
        enPlayer PlayerTurn;
        enWinner Winner;
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white=Color.FromKnownColor(KnownColor.White);
            Pen pen1 = new Pen(white);
            pen1.Width = 10;

            pen1.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen1.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            
            //drawing vertical lines
            e.Graphics.DrawLine(pen1, 625, 100, 625, 550);//left line
            e.Graphics.DrawLine(pen1, 825, 100, 825, 550);//right line

            //drawing horizontal lines
            e.Graphics.DrawLine(pen1, 475, 250, 975, 250);
            e.Graphics.DrawLine(pen1, 475, 400, 975, 400);

        }

        private void RestButton(Button btn)
        {
            btn.Tag = "?";
            btn.Image=Resources.question_mark_96;
            btn.BackColor = Color.Black;
            btn.Enabled = true;
        }

        private void RestartGame()
        {
            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);


            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player1";
            GameStatus.PlayCount = 0;
            GameStatus.Winner = enWinner.InProgress;
            GameStatus.GameOver = false;
            lblWinner.Text = "In Progress";
        }

        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = PlayerTurn.ToString();
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = PlayerTurn.ToString();
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }
            else
            { 
                MessageBox.Show("Choose another box!","Invalid play!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.Winner = enWinner.Draw;
                GameStatus.GameOver = true;
                EndGame();
            }

        }

        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" &&
                btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                //color the winning boxes
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            return false;

        }

        void EndGame()
        {
            lblTurn.Text = "Game Over";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                    break;
                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                    break;
                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

            MessageBox.Show("Game over", "End", MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        public void CheckWinner()
        {
            //check rows

            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            //check columns

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            //check diagonals
            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button) sender);
        }

        private void LABEL1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            RestartGame();  
        }
    }
}
