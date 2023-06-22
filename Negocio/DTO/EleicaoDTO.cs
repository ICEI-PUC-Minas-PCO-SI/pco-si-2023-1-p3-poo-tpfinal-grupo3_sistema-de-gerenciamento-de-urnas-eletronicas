using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Helpers.Enums;

namespace Model.DTO
{
    public class EleicaoDTO
    {
        public int? Id { get; set; }
        public short Ano { get; set; }
        public short Mes { get; set; }
        public short? Vagas { get; set; }
        public int TipoEleicao { get; set; } = (int)ETipoEleicao.EXECUTIVO;
        public int StatusEleicao { get; set; } = (int)EStatusEleicao.ABERTA;
        public bool SegundoTurno { get; set; } = false;
    }
}
