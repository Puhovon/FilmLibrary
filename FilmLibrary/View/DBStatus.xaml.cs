using System.ComponentModel;
using System.Windows;
using FilmLibrary.ViewModel;

namespace FilmLibrary.View
{
    /// <summary>
    /// Логика взаимодействия для DBStatus.xaml
    /// </summary>
    public partial class DBStatus : Window
    {
        public DBStatus()
        {
            InitializeComponent();
            this.DataContext = new DBStatusViewModel();
        }
    }
}
