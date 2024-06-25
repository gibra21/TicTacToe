namespace TicTacToePracticeeeee
{
    public partial class Form1 : Form
    {

        public enum Player //a data type
        { 

            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;
        List<Button> buttons; //made global so 






        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CPUMove(object sender, EventArgs e)
        {

            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkGreen;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTimer.Stop();
            }

        }

        private void PlayerClickButton(object sender, EventArgs e)
        {

            var button = (Button)sender;

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString(); // converting x information to a string
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons.Remove(button); // button will be removed so it cant be clicked again 
            CheckGame(); //will check if any of the 3 buttons have matched
            CPUTimer.Start();
        
        }

        private void RestartGame(object sender, EventArgs e)
        {

            RestartGame();

        }

        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" 
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X" 
               || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
               || button1.Text == "X"  && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
               )
            {

                CPUTimer.Stop();
                MessageBox.Show("Player Wins!");
                playerWinCount++;
                label1.Text = "Player wins " + playerWinCount;
                RestartGame();



            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
               || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
               || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
               || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
               || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
               || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
               || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
               || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
               )
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU wins!");
                CPUWinCount++;
                label2.Text = "CPU wins " + CPUWinCount;
                RestartGame();

            }
            

        }

        private void RestartGame() // restarting the game back to the original square colors
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9};

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;

            }

        }
    }
}
