using System.ComponentModel.DataAnnotations;

namespace LOTRAPI.Models
{
    public class Personaje
    {
        [Key]
        public int IdPersonaje { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
    }
}