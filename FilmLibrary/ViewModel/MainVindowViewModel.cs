using FilmLibrary.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using FilmLibrary.Infrastructure.Commands;
using FilmLibrary.ViewModel.Base;

namespace FilmLibrary.ViewModel
{
    internal class MainVindowViewModel : ViewModelBase
    {
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

        #region Commands


        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }


        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion
        
        
        #endregion
        public MainVindowViewModel()
        {
            #region Commands

            CloseApplicationCommand =
                new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}
