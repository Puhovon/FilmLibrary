using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FilmLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Data
{
    public class NpgSqlData
    {
        public NpgSqlData(Context context)
        {
            _context = context;
        }


        private Context _context;
        public ObservableCollection<Film> FilmsCollection { get; set; }
        
        public IEnumerable<Film> GetAllData => _context.Films.AsNoTracking();

        public void Add(Film film)
        {
            int id = GetAllData.Count() + 1;
            film.Id = id;
            _context.Films.Add(film);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Film film = _context.Films.First(e => e.Id == id);
            _context.Films.Remove(film);
            _context.SaveChanges();
        }

        public void Update(Film film)
        {
            Film f = _context.Films.First(e => e.Id == film.Id);
            _context.Entry(f).State = EntityState.Detached;
            _context.Films.Update(film);
            _context.SaveChanges();

        }
    }
}
