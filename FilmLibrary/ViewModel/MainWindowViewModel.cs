using FilmLibrary.Infrastructure.Commands;
using FilmLibrary.Model;
using FilmLibrary.View;
using FilmLibrary.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FilmLibrary.Data;

namespace FilmLibrary.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private NpgSqlData _context;
        private ObservableCollection<Film> _filmCollection;
        public ObservableCollection<Film> Films { get =>_filmCollection; set=>Set(ref _filmCollection,value); }


        #region Selected Film
        
        private Film _selectedFilm;

        public Film SelectedFilm
        {
            get => _selectedFilm;
            set => Set(ref _selectedFilm, value);
        } 
        
        #endregion

        #region Title & Films Count

        private string _filmsCount;
        public string FilmsCount
        {
            get => _filmsCount;
            set => Set(ref _filmsCount, $"{Films.Count}");
        }
        private string _title = "HomeWork17";
        public string Title
        {
            get => _title;
            set
            {
                Title = value;
            }
        }
        #endregion



        #region Fields Film

        private string _filmName;
        private string _director;
        private string _country;
        private string _genre;

        
        
        public string FilmName
        {
            get => _filmName;
            set => Set(ref _filmName, value);
        }

        public string Director
        {
            get => _director;
            set => Set(ref _director, value);
        }

        public string Country
        {
            get => _country;
            set => Set(ref _country, value);
        }

        public string Genre
        {
            get => _genre;
            set => Set(ref _genre, value);
        }
        #endregion


        #region Commands

        #region DeleteFilmCommand

        

        public ICommand DeleteFilmCommand { get; }

        private void OnDeleteFilmCommand(object p)
        {
            _context.Delete(SelectedFilm.Id);
            Films.Remove(SelectedFilm);
            ClearList();
            FillList();
        }

        private bool CanDeleteFilmCommand(object p)
        {
            if (SelectedFilm == null)
                return false;
            return true;
        }

        #endregion

        #region OpenInfoDialog

        private string _infoAboutMe =
            "Я начинающий разработчик на C#, это один из первых моих полноценных проектов с использованием паттерна MVVM\n"
            + "Telegram: @Puhovon\n"
            + "vk: arkadon14";

        public ICommand OpenInfoDialogCommand { get; }

        private void OnOpenInfoDialogCommand(object p)
        {

            MessageBox.Show(_infoAboutMe, "About me", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanOpenInfoDialogCommand(object p) => true;

        #endregion

        #region OpenAddFilmWindowCommand

        public ICommand OpenAddFilmWindowCommand { get; }

        private void OnOpenAddFilmWindowCommand(object p)
        {
            if (Convert.ToInt32(p) != 0 && SelectedFilm == null) return;

            AddNewFilmWindow anfw = new AddNewFilmWindow();
            Film film;

            if (anfw.ShowDialog() == true)
            {
                film = new Film();
                film.FilmName = anfw.FilmName;
                film.Director = anfw.Director;
                film.Country = anfw.Country;
                film.Genre = anfw.Genre;
                _context.Add(film);
                MessageBox.Show("Успешное добавление", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ClearList();
            FillList();
        }

        private bool CanOpenAddFilmWindowCommand(object p) => true;

        #endregion

        #region OpenEditWindowCommand

        public ICommand OpenEditWindow { get; }

        private void OnOpenEditWindowCommandExecuted(object p)
        {
            if (Convert.ToInt32(p) != 0 && SelectedFilm == null) return;

            EditFilmWindow eFW = new EditFilmWindow();

            eFW.Country = SelectedFilm.Country;
            eFW.FilmName = SelectedFilm.FilmName;
            eFW.Director = SelectedFilm.Director;
            eFW.Genre = SelectedFilm.Genre;

            if (eFW.ShowDialog() == true)
            {
                SelectedFilm.FilmName = eFW.FilmName;
                SelectedFilm.Country = eFW.Country;
                SelectedFilm.Genre = eFW.Genre;
                SelectedFilm.Director = eFW.Director;
                _context.Update(SelectedFilm);
            }
            ClearList();
            FillList();
        }

        private bool CanOpenEditWindowCommandExecute(object p)
        {
            if(SelectedFilm == null)
                return false;
            return true;
        }
        #endregion

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }


        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion

        #region Open Data Base Status Window

        public ICommand OpenDataBaseStatusWindow { get; }

        private void OnOpenDataBaseStatusWindow(object p)
        {
            DBStatus dbStatus = new DBStatus();
            dbStatus.Show();
        }

        private bool CanOpenDataBaseStatusWindow(object p) => true;

        #endregion


        #endregion
        public MainWindowViewModel()
        {
            _context = new NpgSqlData();
            #region Commands

            CloseApplicationCommand =
                new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            OpenEditWindow =
                new LambdaCommand(OnOpenEditWindowCommandExecuted, CanOpenEditWindowCommandExecute);
            OpenAddFilmWindowCommand = 
                new LambdaCommand(OnOpenAddFilmWindowCommand, CanOpenAddFilmWindowCommand);
            OpenInfoDialogCommand 
                = new LambdaCommand(OnOpenInfoDialogCommand, CanOpenInfoDialogCommand);
            DeleteFilmCommand
                = new LambdaCommand(OnDeleteFilmCommand, CanDeleteFilmCommand);
            OpenDataBaseStatusWindow = new LambdaCommand(OnOpenDataBaseStatusWindow, CanOpenDataBaseStatusWindow);

            #endregion

            Films = new ObservableCollection<Film>();
            FillList();
        }

        private void FillList()
        {
            var films = _context.GetAllData.ToList();
            foreach (var film in films)
            {
                Films.Add(film);
            }
        }

        public void ClearList() => Films.Clear();
    }
}
