using System.Windows;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        /// <summary>
        /// Окно для получения информации об управлении персонажем.
        /// </summary>
        public HelpWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
