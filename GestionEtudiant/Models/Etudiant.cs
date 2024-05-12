using System.ComponentModel.DataAnnotations;

namespace GestionEtudiant.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nom { get; set; }
        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }
        [Required]
        [Range(18, 100)]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string CNE { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

    }
}
