﻿using System;
using System.ComponentModel;
using System.Windows;

namespace FilmLibrary.View
{
    /// <summary>
    /// Логика взаимодействия для EditFilm.xaml
    /// </summary>
    public partial class EditFilmWindow : Window
    {
        #region Fields
        /*------------------------------------------------------------------------------------------------------------------------------*/
        public static readonly DependencyProperty FilmNameProperty = DependencyProperty.Register(
            nameof(FilmName),
            typeof(string),
            typeof(EditFilmWindow),
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
            typeof(EditFilmWindow),
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
            typeof(EditFilmWindow),
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
            typeof(EditFilmWindow),
            new PropertyMetadata(default(string)));
        [Description("Название фильма")]
        public string Director
        {
            get => (string)GetValue(DirectorProperty);
            set => SetValue(DirectorProperty, value);
        }
        /*------------------------------------------------------------------------------------------------------------------------------*/
        #endregion
        public EditFilmWindow()
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
                MessageBox.Show("Все поля должны быть заполнены","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
                ;
            }

            DialogResult = true;
            Close();

        }
    }
}
