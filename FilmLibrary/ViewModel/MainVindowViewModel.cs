using FilmLibrary.Model;
using System.Collections.ObjectModel;
using FilmLibrary.ViewModel.Base;

namespace FilmLibrary.ViewModel
{
    internal class MainVindowViewModel : ViewModelBase
    {
        private string _title = "HomeWork17";
        public string Title
        {
            get=>_title;
            set
            {
                Title = value;
            }
        }

        public MainVindowViewModel()
        {

        }
    }
}
