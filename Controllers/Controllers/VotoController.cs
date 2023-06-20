using Controller.Generic;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Helpers.Enums;
using Visao;
using Microsoft.EntityFrameworkCore;

namespace Controller.Controllers
{
    public class VotoController : ControllerBase<Voto>
    {
        public void InserirVotosArquivo(FileStream arquivo)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                var candidatos = dc.Set<Candidato>().ToList();
                var eleicoes = dc.Set<Eleicao>().Where(x => x.StatusEleicao == EStatusEleicao.ABERTA).ToList();
                using (var sr = new StreamReader(arquivo))
                {
                    while (!sr.EndOfStream)
                    {

                        var numero = sr.ReadLine();
                        if (!string.IsNullOrEmpty(numero))
                        {
                            var numeroSplit = numero.Split(',');
                            if (numeroSplit.Length > 1)
                            {
                                if (eleicoes.Any(x => x.StatusEleicao == EStatusEleicao.ABERTA&& x.Id.ToString() == numeroSplit[1]))
                                {
                                    var voto = new Voto(int.Parse(numeroSplit[1]));
                                    if (numeroSplit[0].ToLower() == "branco")
                                        voto.VotoBranco();
                                    else if (numeroSplit[1].ToLower() == "nulo")
                                        voto.VotoNulo();

                                    this.Insert(voto);
                                }
                            }
                            else
                            {
                                var candidato = candidatos.Where(x => x.Numero.ToLower() == numero?.ToLower()).FirstOrDefault();
                                var eleicao = eleicoes.Where(x => candidato != null && (x.TipoEleicao == ETipoEleicao.EXECUTIVO && (
                                (candidato!.Cargo == ECargo.PRESIDENTE || candidato!.Cargo == ECargo.GOVERNADOR || candidato!.Cargo == ECargo.PREFEITO))) ||
                                (x.TipoEleicao == ETipoEleicao.LEGISLATIVO && (
                                !(candidato!.Cargo == ECargo.PRESIDENTE || candidato!.Cargo == ECargo.GOVERNADOR || candidato!.Cargo == ECargo.PREFEITO)))).FirstOrDefault();

                                if (eleicao != null)
                                {
                                    if (!eleicao.SegundoTurno || (eleicao.SegundoTurno && eleicao.CandidatosSegundoTurno.Any(y => y.Id == candidato!.Id)))
                                    {
                                        var voto = new Voto(eleicao.Id, candidato!.Id);
                                        this.Insert(voto);
                                    }
                                    else
                                        Console.WriteLine("Candidato não encontrato");
                                }
                                else
                                    Console.WriteLine("Candidato não encontrato");
                            }
                        }
                    }
                }
            }
        }

        public void InsertNulo(ETipoEleicao tipo)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                var eleicaoId = dc.Set<Eleicao>().AsNoTracking().Where(x => x.TipoEleicao == tipo && x.StatusEleicao == EStatusEleicao.ABERTA).Select(x => x.Id).FirstOrDefault();

                if (eleicaoId > 0)
                {
                    var voto = new Voto(eleicaoId);
                    voto.VotoNulo();
                    dc.Set<Voto>().Add(voto);
                    dc.SaveChanges();
                }
                else
                {
                    throw new Exception($"Não existe votação aberta para o {tipo.GetDescription()}");
                }
            }
        }

        public void InsertBranco(ETipoEleicao tipo)
        {

            using (var dc = new UrnaEletronicaContext())
            {
                var eleicaoId = dc.Set<Eleicao>().AsNoTracking().Where(x => x.TipoEleicao == tipo && x.StatusEleicao == EStatusEleicao.ABERTA).Select(x => x.Id).FirstOrDefault();

                if (eleicaoId > 0)
                {
                    var voto = new Voto(eleicaoId);
                    voto.VotoBranco();
                    dc.Set<Voto>().Add(voto);
                    dc.SaveChanges();
                }
                else
                {
                    throw new Exception($"Não existe votação aberta para o {tipo.GetDescription()}");
                }
            }

        }

        public void InsertCandidato(short candidatoId, ETipoEleicao tipo)
        {
            
            using (var dc = new UrnaEletronicaContext())
            {
                var eleicaoId = dc.Set<Eleicao>().AsNoTracking().Where(x => x.TipoEleicao == tipo && x.StatusEleicao == EStatusEleicao.ABERTA).Select(x => x.Id).FirstOrDefault();

                if (eleicaoId > 0)
                {
                    var voto = new Voto(eleicaoId, candidatoId);
                    voto.VotoBranco();
                    dc.Set<Voto>().Add(voto);
                    dc.SaveChanges();
                }
                else
                {
                    throw new Exception($"Não existe votação aberta para o {tipo.GetDescription()}");
                }
            }

        }
    }
}
