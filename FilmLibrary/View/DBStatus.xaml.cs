using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FilmLibrary.View
{
    /// <summary>
    /// Логика взаимодействия для DBStatus.xaml
    /// </summary>
    public partial class DBStatus : Window
    {
        public DBStatus()
        {
        public static readonly DependencyProperty FilmNameProperty = DependencyProperty.Register(
            nameof(DBStatusText),
            typeof(string),
            typeof(DBStatus),
            new PropertyMetadata(default(string)));
        [Description("Название фильма")]
        public string DBStatusText
        {
            get => (string)GetValue(FilmNameProperty);
            set => SetValue(FilmNameProperty, value);
        }
        InitializeComponent();
        }
    }
}
