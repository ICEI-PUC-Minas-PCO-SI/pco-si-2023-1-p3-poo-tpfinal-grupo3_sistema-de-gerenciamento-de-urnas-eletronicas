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
    public class Partido : ModelBase
    {
        #region Properties
        public short Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        [NotMapped]
        public int Coeficiente { get; set; }
        [NotMapped]
        public int Media { get; set; }
        [NotMapped]
        public int SobraGanha { get; set; }
        public virtual HashSet<Candidato> Candidatos { get; set; } = new HashSet<Candidato>();
        #endregion

        #region Methods
        public Partido()
        {

        }

        public Partido(string nome, string numero)
        {
            this.Nome = nome;
            this.Numero = numero;
            this.Validate();
        }

        //Método usado para validar o contexto do modelo
        public override void Validate()
        {
            var msg = new StringBuilder();
            var hasException = false;

            if (string.IsNullOrEmpty(Nome))
            {
                msg.AppendFormat("{0}: {1}", "Nome", "Nome vazio ou inválido /n");
                hasException = true;
            }

            if (string.IsNullOrEmpty(Numero))
            {
                msg.AppendFormat("{0}: {1}", "Número", "Número vazio ou inválido /n");
                hasException = true;
            }
            else
            {
                if (this.Numero.Length != 2)
                {
                    msg.AppendFormat("{0}: {1}", "Número", "Partidos devem conter 2 digitos /n");
                    hasException = true;
                }

            }

            if (hasException)
                throw new Exception(msg.ToString());
        }
        #endregion
    }
}
