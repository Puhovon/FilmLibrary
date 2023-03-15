using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmLibrary.Model;
using FilmLibrary.ViewModel.Base;

namespace FilmLibrary.ViewModel
{
    class FilmsViewModel : ViewModelBase
    {
        private readonly Film _film;
        public FilmsViewModel(Film film)
        {
            _film = film;
        }

        public string FilmName
        {
            get { return _film.FilmName; }
            set
            {
                if (_film.FilmName != value)
                {
                    _film.FilmName = value;
                }
                base.OnPropertyChanged();
            }
        }
    }
}
