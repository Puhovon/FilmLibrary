﻿using System;
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
    /// Логика взаимодействия для AddNewFilmWindow.xaml
    /// </summary>
    public partial class AddNewFilmWindow : Window
    {
        #region Fields
        /*------------------------------------------------------------------------------------------------------------------------------*/
        public static readonly DependencyProperty FilmNameProperty = DependencyProperty.Register(
            nameof(FilmName),
            typeof(string),
            typeof(AddNewFilmWindow),
            new PropertyMetadata(default(string)));
        [Description("Название фильма")]
        public string FilmName
        {
            get => (string)GetValue(FilmNameProperty);
            set => SetValue(FilmNameProperty, value);
        }

        /*------------------------------------------------------------------------------------------------------------------------------*/
        public static readonly DependencyProperty CountryProperty = DependencyProperty.Register(
            nameof(Country),
            typeof(string),
            typeof(AddNewFilmWindow),
            new PropertyMetadata(default(string)));
        [Description("Название фильма")]
        public string Country
        {
            get => (string)GetValue(CountryProperty);
            set => SetValue(CountryProperty, value);
        }

        /*------------------------------------------------------------------------------------------------------------------------------*/
        public static readonly DependencyProperty GenreProperty = DependencyProperty.Register(
            nameof(Genre),
            typeof(string),
            typeof(AddNewFilmWindow),
            new PropertyMetadata(default(string)));
        [Description("Название фильма")]
        public string Genre
        {
            get => (string)GetValue(GenreProperty);
            set => SetValue(GenreProperty, value);
        }
        /*------------------------------------------------------------------------------------------------------------------------------*/
        public static readonly DependencyProperty DirectorProperty = DependencyProperty.Register(
            nameof(Director),
            typeof(string),
            typeof(AddNewFilmWindow),
            new PropertyMetadata(default(string)));
        [Description("Название фильма")]
        public string Director
        {
            get => (string)GetValue(DirectorProperty);
            set => SetValue(DirectorProperty, value);
        }
        /*------------------------------------------------------------------------------------------------------------------------------*/
        #endregion 
        public AddNewFilmWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick_(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Country) ||
                String.IsNullOrEmpty(FilmName) ||
                String.IsNullOrEmpty(Director) ||
                String.IsNullOrEmpty(Genre)
               )
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
                ;
            }

            DialogResult = true;
            Close();

        }
    }
}
