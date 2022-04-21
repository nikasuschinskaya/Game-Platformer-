using OpenTK;
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

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для RestartWindow.xaml
    /// </summary>
    public partial class RestartWindow : Window
    {
        /// <summary>
        /// Окно для повторного прохождения игры.
        /// </summary>
        public RestartWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            RestWindow.Hide();

            using (Platformer gameWindow = new Platformer())
            {
                gameWindow.WindowBorder = WindowBorder.Fixed;
                gameWindow.Run();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
