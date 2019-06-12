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
using SpssLib.DataReader;
using SpssLib.FileParser;
using SpssLib.SpssDataset;
using System.Diagnostics;
using System.IO;

namespace Memory
{
    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        [Obsolete]
        savFile sav = new savFile("highscores.sav");

        [Obsolete]
        public HighScores()
        {
            List<string> values = new List<string> { "2000", "tie" };
            InitializeComponent();
            sav.writeHighscore("Pieter", values);
            highscores.ItemsSource = sav.getHighscores();
        }

        [Obsolete]
        private void clearHighscores(object sender, RoutedEventArgs e)
        {
            sav.clearData();
            highscores.ItemsSource = sav.getHighscores();
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            startup start = new startup();
            start.Show();
            this.Close();
        }
    }
}