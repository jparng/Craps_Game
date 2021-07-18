using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Craps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public class Score
        {
            public int points;
            public int dice1;
            public int dice2;

           public Score(int points, int dice1, int dice2)
            {
                this.points = points;
                this.dice1 = dice1;
                this.dice2 = dice2;
            }

            public int CalculateNum()
            {
                Random rnd = new Random();
                dice1 = rnd.Next(1, 7);
                dice2 = rnd.Next(1, 7);
                int totalNum = dice1 + dice2;
                return totalNum;
            }

        }

        private void playGame(object sender, RoutedEventArgs e)
        {
            Score score = new Score(0, 0, 0);
            int totalNum = score.CalculateNum();
            winBox.Text = "";
            pointBox.Text = "";

            switch(totalNum)
            {
                case 7:
                    outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";
                    rollButton.IsEnabled = false;
                    winBox.Text = "You win!";
                    break;

                case 11:
                    outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";
                    rollButton.IsEnabled = false;
                    winBox.Text = "You win!";
                    break;
                case 2:
                    outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";
                    rollButton.IsEnabled = false;
                    winBox.Text = "You lose!";
                    break;
                case 3:
                    outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";
                    rollButton.IsEnabled = false;
                    winBox.Text = "You lose!";
                    break;
                case 12:
                    outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";
                    rollButton.IsEnabled = false;
                    winBox.Text = "You lose!";
                    break;
                default:
                    score.points += totalNum;
                    pointBox.Text = score.points.ToString();
                    outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";
                    playButton.IsEnabled = false;
                    rollButton.IsEnabled = true;
                    break;

            }
        }


        private void rollClicked(object sender, RoutedEventArgs e)
        {
            int pointValues = int.Parse(pointBox.Text);
            Score score = new Score(pointValues, 0,0);
            int rollNum = score.CalculateNum();
            

            if (rollNum == pointValues)
            {
                winBox.Text = "You win! Click Play to play again.";
                rollButton.IsEnabled = false;
                playButton.IsEnabled = true;
                outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";

            }
            else if(rollNum == 7)
            {
                winBox.Text = "You lose! Click Play to play again.";
                rollButton.IsEnabled = false;
                playButton.IsEnabled = true;
                outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";

            }
            else
            {
                rollButton.IsEnabled = true;
                playButton.IsEnabled = false;
                winBox.Text = "Roll again.";
                outcomeBox.Text = $"Outcome is:{score.dice1}, {score.dice2} ";
            }
        }
    }
}
