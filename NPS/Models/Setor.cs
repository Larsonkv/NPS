//Author: Larson Kremer Vicente

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NPS.Models
{
    public class Setor
    {
        public int SetorId { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nome { get; set; }
        public virtual ICollection<Voto> Votos { get; set; }
    }
}