using System.ComponentModel.DataAnnotations;

namespace P2_2020MV603_2020DO601_2020GR603.Models
{
    public class Genero
    {
        [Key]
        [Display(Name = "ID")]
        public int id_Genero { get; set; }
        [Display(Name = "Tipo de genero")]
        public string? Tipo_Genero { get; set; }
    }
}
