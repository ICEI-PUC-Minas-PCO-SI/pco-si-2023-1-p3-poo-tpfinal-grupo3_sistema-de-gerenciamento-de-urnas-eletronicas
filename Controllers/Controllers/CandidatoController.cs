using Controller.Generic;
using Microsoft.EntityFrameworkCore;
using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visao;
using static Model.Helpers.Enums;

namespace Controller.Controllers
{
    public class CandidatoController : ControllerBase<Candidato>
    {
        public List<CandidatoDTO> ListGrid()
        {
            return this.List().Select(x => new CandidatoDTO()
            {
                Id = x.Id,
                Nome = x.Nome,
                Numero = x.Numero,
                Cargo = (int)x.Cargo!.Value,
                DataNascimento = x.DataNascimento,
                PartidoId = x.PartidoId
            }).ToList();
        }
        public void InsertUpdate(List<CandidatoDTO> data)
        {
            using (var cnx = new UrnaEletronicaContext())
            {
                var dbSet = cnx.Set<Candidato>();
                var dataModelInsert = data.Where(x => !x.Id.HasValue).Select(x => new Candidato(x.Nome, x.Numero, x.DataNascimento, x.PartidoId.GetValueOrDefault(), (ECargo?)x.Cargo)).ToList();

                var candidatosRepetidos = dbSet.AsNoTracking().AsEnumerable().Where(x => dataModelInsert.Any(y => y.Numero == x.Numero)).ToList();

                if (candidatosRepetidos.Count > 0)
                {
                    var sb = new StringBuilder();
                    candidatosRepetidos.ForEach(x => sb.AppendFormat("{0}: Já existe um candidato com o número {1}", x.Nome, x.Numero));
                    throw new Exception(sb.ToString());
                }

                var dataModelUpdate = data.Where(x => x.Id.HasValue).Select(x => new Candidato(x.Nome, x.Numero, x.DataNascimento, x.PartidoId.GetValueOrDefault(), (ECargo?)x.Cargo) { Id = x.Id!.Value }).ToList();

                candidatosRepetidos = dbSet.AsNoTracking().AsEnumerable().Where(x => dataModelUpdate.Any(y => y.Id != x.Id && y.Numero == x.Numero)).ToList();

                if (candidatosRepetidos.Count > 0)
                {
                    var sb = new StringBuilder();
                    dataModelInsert.ForEach(x => sb.AppendFormat("{0}: Já existe um partido com o número {1}", x.Nome, x.Numero));
                    throw new Exception(sb.ToString());
                }
                dbSet.AddRange(dataModelInsert);
                dbSet.UpdateRange(dataModelUpdate);
                cnx.SaveChanges();
            }
        }

        public void Delete(short candidatoId)
        {
            using (var cnx = new UrnaEletronicaContext())
            {
                if (cnx.Set<Candidato>().AsNoTracking().Where(x => x.Id == candidatoId && x.Votos.Count > 0).Count() > 0)
                {
                    throw new Exception("Candidato: Candidato não pode ser excluído, pois ele ja participou de alguma eleição.");
                }

                cnx.Remove(cnx.Set<Candidato>().Find(candidatoId)!);
                cnx.SaveChanges();
            }
        }

        public CandidatoDTO? GetByNumeroEmEleicao(string numero, ETipoEleicao tipoEleicao)
        {
            using (var cnx = new UrnaEletronicaContext())
            {
               return cnx.Set<Candidato>().AsNoTracking().Where(x =>  x.Numero == numero && 
                      cnx.Set<Eleicao>().AsNoTracking().Any(e => e.TipoEleicao == tipoEleicao && e.StatusEleicao == EStatusEleicao.ABERTA &&
                                            ((e.TipoEleicao == ETipoEleicao.EXECUTIVO &&
                                             x.Cargo == ECargo.PRESIDENTE ||
                                             x.Cargo == ECargo.GOVERNADOR ||
                                             x.Cargo == ECargo.PREFEITO) ||
                                             (e.TipoEleicao == ETipoEleicao.LEGISLATIVO &&
                                             !(x.Cargo == ECargo.PRESIDENTE ||
                                             x.Cargo == ECargo.GOVERNADOR ||
                                             x.Cargo == ECargo.PREFEITO))
                                             ))).Select(x=> new CandidatoDTO()
                                             {
                                                 Cargo = (int)x.Cargo!.Value,
                                                 DataNascimento = x.DataNascimento,
                                                 Id = x.Id,
                                                 Nome = x.Nome,
                                                 Numero = x.Numero,
                                                 PartidoId = x.PartidoId,
                                                 PartidoNome = x.Partido.Nome
                                             }).FirstOrDefault();
            }
        }
    }
}
