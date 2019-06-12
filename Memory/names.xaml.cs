using System.Windows;
using System;
using System.Collections.Generic;

namespace Memory
{
    /// <summary>
    /// Interaction logic for names.xaml
    /// </summary>
    public partial class names : Window
    {
        public names()
        {
            InitializeComponent();
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            startup start = new startup();
            start.Show();
            this.Hide();
        }

        private void startGame(object sender, RoutedEventArgs e)
        {
            DateTime now = new DateTime();
            long date = now.Year + now.Month + now.Day + now.Hour + now.Minute;

            Board board = new Board();

            players spelers = new players() { player1 = textbox_player_1.Text, player2 = textbox_player_2.Text };

            savedGame game = new savedGame
            {
                GameName = date.ToString(),
                Status = board.Generate(),
                Players = spelers,
                Score1 = "0",
                Score2 = "0",
                Turn = spelers.player1
            };

            MainWindow mainWindow = new MainWindow("new", game);
            mainWindow.Show();
            this.Close();
        }
    }
}
