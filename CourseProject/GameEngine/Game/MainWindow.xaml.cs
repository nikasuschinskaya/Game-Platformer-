using OpenTK;
using System.Windows;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Окно главного меню.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            using (Platformer gameWindow = new Platformer())
            {
                gameWindow.WindowBorder = WindowBorder.Fixed;
                gameWindow.Run(60, 60);
            }
        }

        private void AutorButton_Click(object sender, RoutedEventArgs e)
        {
            AutorWindow autorWindow = new AutorWindow();
            autorWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }
    }
}
