using System.ComponentModel.DataAnnotations;

namespace MovieMvc.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string MoviesType { get; set; }
        [Required]
        public string StarName { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set;}
    }
}
