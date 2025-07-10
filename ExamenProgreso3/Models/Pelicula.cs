using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace ExamenProgreso3.Models
{
    [Table("Peliculas")]
    internal class Pelicula
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        [MaxLength(100)]
        public string titulo { get; set; }

        [MaxLength(20)]
        public string genero { get; set; }
        [NotNull]
        public int anio { get; set; }
        [NotNull]
        public int calificacion { get; set; }
    }
}
