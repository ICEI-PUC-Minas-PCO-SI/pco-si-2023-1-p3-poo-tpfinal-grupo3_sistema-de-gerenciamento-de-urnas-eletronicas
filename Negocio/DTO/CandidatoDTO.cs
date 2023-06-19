using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Helpers.Enums;

namespace Model.DTO
{
    public class CandidatoDTO
    {
        public short? Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Numero { get; set; } = String.Empty;
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
        public short? PartidoId { get; set; }
        public int? Cargo { get; set; }
    }
}
