using Model.Abstract;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Helpers.Enums;

namespace Model.Models
{
    public class Candidato : ModelBase
    {
        #region Properties
        public short Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Numero { get; set; } = String.Empty;
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
        public short PartidoId { get; set; }
        public virtual Partido Partido { get; set; } = null!;
        public ECargo? Cargo { get; set; }
        public virtual HashSet<Voto> Votos { get; set; } = new HashSet<Voto>();
        #endregion

        #region Methods
        public Candidato()
        {

        }

        public Candidato(string nome, string numero, DateTime idade, short partidoId, ECargo? cargo)
        {
            this.Nome = nome;
            this.Numero = numero;
            this.DataNascimento = idade;
            this.PartidoId = partidoId;
            this.Cargo = cargo;
            this.Validate();
        }

        public override void Validate()
        {
            var msg = new StringBuilder();
            var hasException = false;

            if (string.IsNullOrEmpty(Nome))
            {
                msg.AppendFormat("{0}: {1}", "Nome", "Nome vazio ou inválido /n");
                hasException = true;
            }
            if (!this.Cargo.HasValue)
            {
                msg.AppendFormat("{0}: {1}", "Cargo", "Cargo inválido /n");
            }

            if (string.IsNullOrEmpty(Numero))
            {
                msg.AppendFormat("{0}: {1}", "Número", "Número vazio ou inválido /n");
                hasException = true;
            }
            else
            {
                if ((this.Cargo == ECargo.DEPUTADO_FEDERAL && this.Numero.Length != 4))
                {
                    msg.AppendFormat("{0}: {1}", "Número", "Deputados Federais devem conter 4 digitos /n");
                    hasException = true;
                }
                else if ((this.Cargo == ECargo.DEPUTADO_ESTADUAL && this.Numero.Length != 5))
                {
                    msg.AppendFormat("{0}: {1}", "Número", "Deputados Estaduais devem conter 5 digitos /n");
                    hasException = true;
                }
                else if (this.Numero.Length != 2)
                {
                    msg.AppendFormat("{0}: {1}", "Número", "Prefeitos, Presidentes e Senadores devem conter 2 digitos /n");
                    hasException = true;
                }

            }

            if (PartidoId <= 0)
            {
                msg.AppendFormat("{0}: {1}", "Partido", "Partido inválido /n");
                hasException = true;
            }

            if (hasException)
                throw new Exception(msg.ToString());
        }
    }
    #endregion
}