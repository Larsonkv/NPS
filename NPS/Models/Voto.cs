﻿//Author: Larson Kremer Vicente

using System;
using System.ComponentModel.DataAnnotations;

namespace NPS.Models
{
    public class Voto
    {
        public int VotoId { get; set; }
        [Required(ErrorMessage = "*")]
        public int Vl_voto { get; set; }
        public string Nr_telefone { get; set; }
        public string Justificativa_voto { get; set; }
        public int SetorId { get; set; }
        public virtual Setor Setor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dt_voto { get; set; }
    }
}