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
using Newtonsoft.Json;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        private const int cols = 4;
        private const int rows = 4;
        MemoryGrid grid;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action">The action. 'new' for a new game</param>
        /// <param name="game">A game object</param>
        public MainWindow(string action, savedGame game)
        {
            InitializeComponent();
            if (action == "new")
            {
                grid = new MemoryGrid(GameGrid, cols, rows);
                Board board = new Board();
                List<List<List<int>>> values = new List<List<List<int>>>();
                values = board.Generate();
                AddImages(values);

            } else
            {
                grid = new MemoryGrid(GameGrid, cols, rows);
                AddImages(game.Status);
            }
            label_player1.Content = game.Players.player1 + " : " + game.Score1;
            label_player2.Content = game.Players.player2 + " : " + game.Score2;
            label_turn.Content = game.Turn + " is aan de beurt";
        }

        /// <summary>
        /// Add images to the grid. This is done by looping through the grid and using the ImagesList() 
        /// function to provide the images with the necessary data
        /// </summary>
        private void AddImages(List<List<List<int>>> values)
        {
            for (int i = 0; i < values.Count(); i++)
            {
                for (int j = 0; j < values[i].Count(); j++)
                {
                    Image image = new Image();
                    if (values[i][j][1] == 0)
                    {
                        image.Source = new BitmapImage(new Uri("Images/back.png", UriKind.Relative));
                    } else
                    {
                        string path = "Images/" + values[i][j][0] + ".png";
                        image.Source = new BitmapImage(new Uri(path, UriKind.Relative));
                    }

                    image.MouseDown += new MouseButtonEventHandler(Click);
                    string pathTag = "Images/" + values[i][j][0] + ".png";
                    image.Tag = new BitmapImage(new Uri(pathTag, UriKind.Relative));
                    Grid.SetColumn(image, j);
                    Grid.SetRow(image, i);
                    GameGrid.Children.Add(image);
                }
            }
        }

        /// <summary>
        /// Adding an event handler to the grid
        /// The tag of an image becomes the source of the image, thus changing the display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click(object sender, MouseButtonEventArgs e)
        {
            Image card1 = (Image)sender;
            ImageSource front = (ImageSource)card1.Tag;
            card1.Source = front;
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            startup startup = new startup();
            startup.Show();
            this.Close();
        }

        private void shuffle(object sender, RoutedEventArgs e)
        {
            GameGrid.Children.Clear();
            Board board = new Board();
            List<List<List<int>>> values = new List<List<List<int>>>();
            values = board.Generate();
            AddImages(values);

        }
    }
}
