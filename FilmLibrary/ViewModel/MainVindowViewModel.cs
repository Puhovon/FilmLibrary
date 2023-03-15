using FilmLibrary.Model;
using System.Collections.ObjectModel;
using FilmLibrary.ViewModel.Base;

namespace FilmLibrary.ViewModel
{
    internal class MainVindowViewModel : ViewModelBase
    {
        public ObservableCollection<Film> filmsCollection;
        public MainVindowViewModel()
        {
            filmsCollection = new ObservableCollection<Film>();
            var f1 = new Film("Russia");
            filmsCollection.Add(f1);
        }
    }
}
