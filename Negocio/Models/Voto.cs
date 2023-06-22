using Model.Abstract;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.Models
{
    public class Voto : ModelBase
    {
        #region Properties
        public long Id { get; set; }
        public int EleicaoId { get; set; }
        public short? CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
        public virtual Eleicao Eleicao { get; set; } = null!;
        public bool Branco { get; set; } = false;
        
        #endregion

        #region Methods
        public Voto()
        {

        }

        public Voto(int eleicaoId, short candidatoId)
        {
            this.EleicaoId = eleicaoId;
            this.CandidatoId = candidatoId;
            this.Validate();
        }

        public Voto(int eleicaoId)
        {
            this.EleicaoId = eleicaoId;
            this.Validate();
        }


        //Método usado para validar o contexto do modelo
        public override void Validate()
        {
            var msg = new StringBuilder();
            var hasException = false;

            if (CandidatoId!=null&&CandidatoId <= 0)
            {
                msg.AppendFormat("{0}: {1}", "Candidato", "Candidato inválido /n");
                hasException = true;
            }

            if (EleicaoId <= 0)
            {
                msg.AppendFormat("{0}: {1}", "Eleção", "Eleição inválido /n");
                hasException = true;
            }


            if (hasException)
                throw new Exception(msg.ToString());
        }

        public void VotoNulo()
        {
            this.Branco= false;
            this.CandidatoId = null;
        }

        public void VotoBranco()
        {
            this.Branco = true;
            this.CandidatoId = null;
        }
        #endregion
    }
}
