using System.ComponentModel.DataAnnotations;

namespace FilmLibrary.Model
{
    public class Film 
    {
        [Required]
        [Key]
        public int Id
        {
            get; set;
        }
        public string FilmName
        {
            get; set;
        }
        public string Country
        {
            get; set;
        }
        public string? Director
        {
            get; set;
        }
        public string Genre
        {
            get; set;
        }
    }
}
