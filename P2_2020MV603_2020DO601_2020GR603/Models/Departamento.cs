using System.ComponentModel.DataAnnotations;

namespace P2_2020MV603_2020DO601_2020GR603.Models
{
    public class Departamento
    {
        [Key]
        [Display(Name = "ID")]
        public int id_Departamento { get; set; }
        [Display(Name = "Nombre del departamento")]
        public string? nombre_Departamento { get; set; }
    }
}
