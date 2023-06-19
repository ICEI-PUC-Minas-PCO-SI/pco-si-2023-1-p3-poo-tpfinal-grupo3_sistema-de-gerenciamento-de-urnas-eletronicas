using Model.Abstract;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Helpers.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.Models
{
    public class Eleicao : ModelBase
    {
        #region Properties
        public int Id { get; set; }
        public short Ano { get; set; }
        public short Mes { get; set; }
        public ETipoEleicao TipoEleicao { get; set; } = ETipoEleicao.EXECUTIVO;
        public EStatusEleicao StatusEleicao { get; set; }
        public bool SegundoTurno { get; set; } = false;
        public virtual HashSet<Voto> Votos { get; set; } = new HashSet<Voto>();
        #endregion

        #region Methods
        public Eleicao()
        {

        }

        public Eleicao(short ano, short mes, ETipoEleicao tipoEleicao)
        {
            this.Ano = ano;
            this.Mes = mes;
            this.TipoEleicao = tipoEleicao;
            this.StatusEleicao = EStatusEleicao.ABERTA;
            this.Validate();
        }

        //Método usado para validar o contexto do modelo
        public override void Validate()
        {
            var msg = new StringBuilder();
            var hasException = false;

            if (Ano <= 2009)
            {
                msg.AppendFormat("{0}: {1}", "Ano", "Ano inválido, apenas anos superiores a 2009 /n");
                hasException = true;
            }

            if (Mes <= 0 || Mes > 13)
            {
                msg.AppendFormat("{0}: {1}", "Mês", "Mês inválido /n");
                hasException = true;
            }


            if (hasException)
                throw new Exception(msg.ToString());
        }
        #endregion
    }
}
