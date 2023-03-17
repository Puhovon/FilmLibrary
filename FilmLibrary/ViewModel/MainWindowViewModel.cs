using System;
using FilmLibrary.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FilmLibrary.Infrastructure.Commands;
using FilmLibrary.View;
using FilmLibrary.ViewModel.Base;

namespace FilmLibrary.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        

        public ObservableCollection<Film> Films { get; }
        
        
        private Film _selectedFilm;

        public Film SelectedFilm
        {
            get =>  _selectedFilm;
            set => Set(ref _selectedFilm, value);
        }
        
        #region Title
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



        #region Fields

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

        #region ViewDataFromGridCommand

        public ICommand OpenEditWindow { get; }

        private void OnOpenEditWindowCommandExecuted(object p)
        {
            if (Convert.ToInt32(p) != 0 && SelectedFilm == null) return;

            EditFilmWindow eFW = new EditFilmWindow();
            if (Convert.ToInt32(p) == 0)
            {
                Debug.Write("Command accept");
                
                if (eFW.ShowDialog() == true)
                {
                    Film film = new Film();
                    film.Country = eFW.Country;
                    film.FilmName = eFW.FilmName;
                    film.Director = eFW.Director;
                    film.Genre = eFW.Genre;
                }
            }
            else
            { 
                eFW.Country = SelectedFilm.Country;
                eFW.FilmName = SelectedFilm.FilmName;
                eFW.Director = SelectedFilm.Director;
                eFW.Genre = SelectedFilm.Genre;
            }
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
        
        
        #endregion
        public MainWindowViewModel()
        {
            #region Commands
            
            CloseApplicationCommand =
                new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            OpenEditWindow =
                new LambdaCommand(OnOpenEditWindowCommandExecuted, CanOpenEditWindowCommandExecute);

            #endregion

            var films = Enumerable.Range(1, 25).Select(i => new Film
            {
                FilmName = $"Norvind {i}",
                Country = "Russia",
                Director = $"Arkadiy {i}",
                Genre = "Action"
            });
            Films = new ObservableCollection<Film>(films);
            

        }
    }
}
