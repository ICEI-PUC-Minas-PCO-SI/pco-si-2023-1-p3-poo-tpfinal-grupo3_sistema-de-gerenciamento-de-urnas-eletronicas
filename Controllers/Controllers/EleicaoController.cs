using Controller.Generic;
using Model.DTO;
using Model.Helpers;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Helpers.Enums;
using Visao;

namespace Controller.Controllers
{
    public class EleicaoController : ControllerBase<Eleicao>
    {
        public List<EnumHelperObject> ListStatusEleicao()
        {
            return Enums.ToSelectList<EStatusEleicao>();
        }

        public List<EnumHelperObject> ListTiposEleicao()
        {
            return Enums.ToSelectList<ETipoEleicao>();
        }

        public List<EleicaoDTO> ListGrid()
        {
            return this.List().Select(x => new EleicaoDTO()
            {
                Id = x.Id,
                Ano = x.Ano,
                Mes = x.Mes,
                SegundoTurno = x.SegundoTurno,
                StatusEleicao = (int)x.StatusEleicao,
                TipoEleicao = (int)x.TipoEleicao
            }).ToList();
        }


        public void InsertUpdate(List<EleicaoDTO> data)
        {
            using (var cnx = new UrnaEletronicaContext())
            {

                var dbSet = cnx.Set<Eleicao>();
                var dataModelInsert = data.Where(x => !x.Id.HasValue).Select(x => new Eleicao(x.Ano, x.Mes, (ETipoEleicao)x.TipoEleicao)).ToList();

               var eleicoesAbertas = dbSet.Where(x => x.StatusEleicao == EStatusEleicao.ABERTA && (x.TipoEleicao == ETipoEleicao.LEGISLATIVO || x.TipoEleicao == ETipoEleicao.EXECUTIVO)).ToList();

                if (eleicoesAbertas.Count > 0)
                {
                    var sb = new StringBuilder();
                    eleicoesAbertas.ForEach(x => sb.AppendFormat("{0}: Já existe uma eleição aberta, encerre a eleição para inserir novas eleições.", x.TipoEleicao.GetDescription()));
                    throw new Exception(sb.ToString());
                }

                var dataModelUpdate = data.Where(x => x.Id.HasValue).Select(x => new Eleicao(x.Ano, x.Mes, (ETipoEleicao)x.TipoEleicao) { Id = x.Id!.Value }).ToList();



                dbSet.AddRange(dataModelInsert);
                dbSet.UpdateRange(dataModelUpdate);

                cnx.SaveChanges();
            }

        }

        public void Delete(int eleicaoId)
        {
            using (var cnx = new UrnaEletronicaContext())
            {
                if (cnx.Set<Eleicao>().Where(x => x.Votos.Count>0).Count() > 0)
                {
                    throw new Exception("Eleição: Eleição não pode ser excluída, pois ela ja possuí votos.");
                }

                cnx.Remove(cnx.Set<Eleicao>().Find(eleicaoId)!);
                cnx.SaveChanges();
            }
        }
    }
}
