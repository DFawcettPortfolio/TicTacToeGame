using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
namespace TicTacToe
{
    public partial class Form1 : Form
    {

        int playerWins = 0;
        int computerWins = 0;
        int drawGames = 0;
        int playerNumber;
        int currentPlayer=1;
        Random random = new Random();
        List<Button> buttons;
        bool active=true;
        
        //END OF INITIALIZING

            public Form1()
        {
            InitializeComponent();
            NewGame();
            
        }//end of Form1

        private void NewGame()
        {
            active = true;
            textBox.Visible = false;
            label1.Text = $"Player Wins: {playerWins}";
            label2.Text = $"Computer Wins: {computerWins}";
            label3.Text = $"Draw Games: {drawGames}";
            playerNumber = random.Next(1,3);
            currentPlayer = 1;
            checkedListBox1.SetItemChecked(0, false);
            checkedListBox1.SetItemChecked(1, false);
            checkedListBox1.SetItemChecked(playerNumber-1, true);
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = " ";
                x.BackColor = System.Drawing.Color.DarkGray; 
            }//end of foreach loop

            if (playerNumber == 2) { CPU_Timer.Start(); } 

        }//end of NewGame
        

        private void PlayerMove(object sender, EventArgs e)
        {
            if (active == true)
            { if(playerNumber == currentPlayer)
                {


          var button = (Button)sender;
            
            if(playerNumber == 1)
            {
                button.Text = "X";
                button.BackColor = Color.DarkSeaGreen;
            }
            else
            {
                button.Text = "O";
                button.BackColor = Color.DarkMagenta;
            }
            button.Enabled = false;
            buttons.Remove(button);
            gameState();

                }//end of playerNumber==currentPlayer
            }//end of active==true
        }//end of PlayerMove


        private void ComputerMove(object sender, EventArgs e)
        {
            if (active == true)
            {
                int chosenMove = random.Next(buttons.Count);
                if (playerNumber == 2)
                {
                    buttons[chosenMove].Text = "X";
                    buttons[chosenMove].BackColor = Color.DarkSeaGreen;
                }
                else
                {
                    buttons[chosenMove].Text = "O";
                    buttons[chosenMove].BackColor = Color.DarkMagenta;
                }
                buttons[chosenMove].Enabled = false;
                buttons.RemoveAt(chosenMove);
                gameState();

            }//end of active==true
        }//end of ComputerMove

        private void gameState()
        {
            if ( //X wins
                button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
             || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
             || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"

             || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
             || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
             || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"

             || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
             || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
           )
            {// this happens if X wins
                if (playerNumber == 1) //X represents player 1, if X wins, and the human is controlling player 1, the human wins
                {
                    playerWins++;
                    label1.Text = $"Player Wins: {playerWins}";
                    textBox.Visible = true;
                    textBox.Text = "Human player wins!";
                    active = false;
                    return;

                }
                else //playerNumber ==2, so the computer has control over player 1
                {
                    computerWins++;
                    label2.Text = $"Computer Wins: {computerWins}";
                    textBox.Visible = true;
                    textBox.Text = "Computer player wins!";

                    CPU_Timer.Stop();
                    active = false;
                    return;


                }
            }
            else if ( //O wins
                button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
             || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
             || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                                                                               
             || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
             || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
             || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                                                                               
                                                                               
             || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
             || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
           )
            {
                if (playerNumber == 2)
                {
                    playerWins++;
                    label1.Text = $"Player Wins: {playerWins}";
                    textBox.Visible = true; 
                    textBox.Text = "Human player wins!";
                    active = false;
                    return;



                }
                else
                {
                    computerWins++;
                    label2.Text = $"Computer Wins: {computerWins}";
                    textBox.Visible = true;
                    textBox.Text = "Computer player wins!";

                    CPU_Timer.Stop();
                    active = false;
                    return;

                }
            }
            else if (buttons.Count == 0)  //game is a draw, no spaces left
            {
                drawGames++;
                label3.Text=$"Draw Games: {drawGames}";
                textBox.Visible = true;
                textBox.Text = "Draw! (Cat's Game)";

                CPU_Timer.Stop();
                return;

            }
            else   //game moves on, change the player control
            {
                {

                    if (currentPlayer == 2) { currentPlayer = 1; }
                    else { currentPlayer = 2; }
                    if (playerNumber == currentPlayer) { CPU_Timer.Stop(); } //Player turn
                    else { CPU_Timer.Start(); }//CPU turn
                }
               

            }

           
        }//end of gameState



        private void ContinueButton(object sender, EventArgs e)
        {

            NewGame();
        }//end of ContinueButton

        private void ExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetButton(object sender, EventArgs e)
        {
            playerWins = 0;
            computerWins = 0;
            drawGames = 0;

            NewGame();

        }//end of ResetButton

        private void WinnerDisplay(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
           button10.Width = this.ClientSize.Width / 2;
        }





    }//end of Form1 form
}//end of TicTacToe namespace



/* 
 * 
 * A Windows Forms (.NET Framework) GUI application

App must use a TableLayoutPanel to control the layout of Buttons, Labels, and other GUI components on the top level Form

Use of MessageBox is not allowed in any part of the app. All UI elements must be part of the Form.

App must resize from some reasonable min to max sizes with all components resizing appropriately

Your game must have 1 human player who has autonomy in their selection of squares to place their mark.

The human player will play against the computer.

The computer will use a pseudo-random square selection to place its marker

The first player to move will be chosen using the Random class.

Each player, human and computer, should have reasonable opportunity to move first.

The first player to move is automatically assigned the X marker, second player to move is assigned the O marker.

There should be controls to:

Start a new game at any time.

Stop a game and Exit the application at any time.

The winner of a game should be announced and the game ended as soon as there is a winner.

A game where neither player wins should be declared a "TIE" or a "CAT'S" game.*/ 