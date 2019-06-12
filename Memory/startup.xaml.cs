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

namespace Memory
{
    /// <summary>
    /// Interaction logic for startup.xaml
    /// </summary>
    public partial class startup : Window
    {

        bool hasBeenStarted = false;

        public startup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Generates two input fields for entering a name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startGame(object sender, RoutedEventArgs e)
        {
            names name = new names();
            name.Show();
            this.Close();  
        }

        [Obsolete]
        private void startHighscores(object sender, RoutedEventArgs e)
        {
            HighScores highscores = new HighScores();
            highscores.Show();
            this.Close();

        }

        private void quitGame(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loadGame(object sender, RoutedEventArgs e)
        {
            loadGame load = new loadGame();
            load.Show();
            this.Close();
        }
    }
}
