using System.ComponentModel.DataAnnotations;

namespace NPS.Models
{
    public class Voto
    {
        public int VotoId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Vl_voto { get; set; }
        public string Nr_telefone { get; set; }
        public string Justificativa_voto { get; set; }
        public int SetorId { get; set; }
        public virtual Setor Setor { get; set; }
    }
}