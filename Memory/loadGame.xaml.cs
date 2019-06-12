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
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Memory
{
    /// <summary>
    /// Interaction logic for loadGame.xaml
    /// </summary>
    public partial class loadGame : Window
    {

        [Obsolete]
        savFile saved = new savFile("memory.sav");

        [Obsolete]
        public loadGame()
        {
            List<List<List<int>>> total = new List<List<List<int>>>()
            {
                new List<List<int>>()
                {
                    new List<int>(){ 1, 1 },
                    new List<int>(){ 4, 0 },
                    new List<int>(){ 3, 0 },
                    new List<int>(){ 8, 1 }
                },

                new List<List<int>>()
                {
                    new List<int>(){ 4, 1 },
                    new List<int>(){ 5, 1 },
                    new List<int>(){ 8, 1 },
                    new List<int>(){ 7, 1 }
                },

                new List<List<int>>()
                {
                    new List<int>(){ 1, 0 },
                    new List<int>(){ 2, 0 },
                    new List<int>(){ 6, 0 },
                    new List<int>(){ 6, 1 }
                },

                new List<List<int>>()
                {
                    new List<int>(){ 2, 0 },
                    new List<int>(){ 7, 0 },
                    new List<int>(){ 3, 1 },
                    new List<int>(){ 5, 1 }
                }
            };

            List<string> values = new List<string> { "Pieter", "Joost", "2000", "5000", "Pieter" };
            InitializeComponent();
            saved.clearData();
            saved.writeGame("Game1", values, total);
            savedgames.ItemsSource = saved.getGames();
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            startup start = new startup();
            start.Show();
            this.Close();
        }

        [Obsolete]
        private void clearGames(object sender, RoutedEventArgs e)
        {
            saved.clearData();
            savedgames.ItemsSource = saved.getGames();
        }

        public void LoadGame(object sender, RoutedEventArgs e)
        {

            List<List<List<int>>> freshBoard = new List<List<List<int>>>()
                {
                    new List<List<int>>()
                    {
                        new List<int>(){ 1, 0 },
                        new List<int>(){ 1, 0 },
                        new List<int>(){ 2, 0 },
                        new List<int>(){ 2, 0 }
                    },

                    new List<List<int>>()
                    {
                        new List<int>(){ 3, 0 },
                        new List<int>(){ 3, 0 },
                        new List<int>(){ 4, 0 },
                        new List<int>(){ 4, 0 }
                    },

                    new List<List<int>>()
                    {
                        new List<int>(){ 5, 0 },
                        new List<int>(){ 5, 0 },
                        new List<int>(){ 6, 1 },
                        new List<int>(){ 6, 0 }
                    },

                    new List<List<int>>()
                    {
                        new List<int>(){ 7, 0 },
                        new List<int>(){ 7, 0 },
                        new List<int>(){ 8, 0 },
                        new List<int>(){ 8, 0 }
                    }
                };

            Board board = new Board();
            List<List<List<int>>> values = new List<List<List<int>>>();
            values = board.Random();

            savedGame test = new savedGame
            {
                GameName = "Testing",
                Status = values,
                Players = new players() { player1 = "Pieter", player2 = "Joost" },
                Score1 = "1000",
                Score2 = "2000",
                Turn = "Pieter"
            };

            MainWindow laden = new MainWindow("load", test);
            this.Close();
            laden.Show();
        }

        /// <summary>
        /// Returns a list of lists of ints which are randomly generated
        /// </summary>
        /// <returns>Returns a random list of lists of ints</returns>
    
    }
}
