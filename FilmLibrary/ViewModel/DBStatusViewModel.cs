using FilmLibrary.Data;
using FilmLibrary.ViewModel.Base;

namespace FilmLibrary.ViewModel
{
    internal class DBStatusViewModel : ViewModelBase
    {
        NpgSqlData _context;

        #region Fields

        private string _pgConString;

        public string PgConString
        {
            get => _pgConString;
            set => Set(ref _pgConString, value);
        }

        private string _pgStatus;

        public string PgStatus
        {
            get => _pgStatus;
            set => Set(ref _pgStatus, value);
        }

        #endregion

        public DBStatusViewModel()
        {
            _context = new NpgSqlData();
            _pgStatus = "Строка подключения: ";
            _pgConString = _context.GetConnectionString();
        }
    }
}
