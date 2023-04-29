using System.ComponentModel.DataAnnotations;

namespace P2_2020MV603_2020DO601_2020GR603.Models
{
    public class Casos_Reportados
    {
        [Key]
        [Display(Name = "ID")]
        public int id_Casos { get; set; }
        [Display(Name = "Casos Confirmados")]
        public int casos_Confirmados { get; set; }
        [Display(Name = "Casos Recuperados")]
        public int casos_Recuperados { get; set; }
        [Display(Name = "Casos Fallecidos")]
        public int casos_Fallecidos { get; set; }
    }
}
