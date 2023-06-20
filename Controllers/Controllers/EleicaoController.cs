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
using Microsoft.EntityFrameworkCore;

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
                Vagas = x.Vagas,
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
                var dataModelInsert = data.Where(x => !x.Id.HasValue).Select(x => new Eleicao(x.Ano, x.Mes, (ETipoEleicao)x.TipoEleicao, x.Vagas)).ToList();

                var eleicoesAbertas = dbSet.AsNoTracking().AsEnumerable().Where(x => x.StatusEleicao == EStatusEleicao.ABERTA && dataModelInsert.Any(y=> y.TipoEleicao == x.TipoEleicao)).ToList();

                if (eleicoesAbertas.Count > 0)
                {
                    var sb = new StringBuilder();
                    eleicoesAbertas.ForEach(x => sb.AppendFormat("{0}: Já existe uma eleição aberta, encerre a eleição para inserir novas eleições.", x.TipoEleicao.GetDescription()));
                    throw new Exception(sb.ToString());
                }

                var dataModelUpdate = data.Where(x => x.Id.HasValue).Select(x => new Eleicao(x.Ano, x.Mes, (ETipoEleicao)x.TipoEleicao, x.Vagas) { Id = x.Id!.Value }).ToList();



                dbSet.AddRange(dataModelInsert);
                dbSet.UpdateRange(dataModelUpdate);

                cnx.SaveChanges();
            }

        }

        public void Delete(int eleicaoId)
        {
            using (var cnx = new UrnaEletronicaContext())
            {
                if (cnx.Set<Eleicao>().AsNoTracking().Where(x => x.Votos.Count > 0).Count() > 0)
                {
                    throw new Exception("Eleição: Eleição não pode ser excluída, pois ela ja possuí votos.");
                }

                cnx.Remove(cnx.Set<Eleicao>().Find(eleicaoId)!);
                cnx.SaveChanges();
            }
        }


        public void FinalizarEleicao(int eleicaoId)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                var dbset = dc.Set<Eleicao>();

                var eleicao = dbset.Find(eleicaoId);
                double totalVotos = eleicao!.Votos.Count;
                double totalVotosValidos = eleicao.Votos.Where(x => x.CandidatoId.HasValue).Count();

                var tituloArquivo = $"Eleição-{(eleicao.SegundoTurno ? "Seg.Turno" : "P.Turno")} {eleicao!.Ano.ToString("0000")}-{eleicao.Mes.ToString("00")} a {DateTime.Now.ToString("dd-MM-yyy HH-mm")}.txt";
                var linhas = new List<string>();


                if (eleicao.TipoEleicao == ETipoEleicao.EXECUTIVO)
                {
                    linhas.Add($"Eleição do Executivo ------------------------");
                    var votosGroupByCargo = eleicao.Votos.AsQueryable().Where(x => x.CandidatoId.HasValue).GroupBy(x => new { x.Candidato.Cargo }).OrderByDescending(x => x.Count());
                    Eleicao? segundoTurno = null;
                    votosGroupByCargo.ToList().ForEach(chave =>
                    {
                        linhas.AddRange(new[]{
                        $"Total de votos válidos: {(int)totalVotosValidos}.",
                        $"Total de votos nulos: {eleicao.Votos.Where(x => !x.CandidatoId.HasValue && !x.Branco).Count()}.",
                        $"Total de votos brancos: {eleicao.Votos.Where(x => x.Branco).Count()}."
                        });
                        linhas.Add("");


                        var votosGroupByCandidato = chave.Select(x => x).GroupBy(x => x.Candidato).OrderByDescending(x => x.Count());
                        votosGroupByCandidato.ToList().ForEach(candidato => linhas.Add($"Candidato {candidato.Key.Nome} do partido {candidato.Key.Partido.Nome}, recebeu: {candidato.Count()} votos."));

                        linhas.Add("");
                        var maisVotado = votosGroupByCandidato.FirstOrDefault();
                        double totalMaisVotado = maisVotado!.Count();

                        if (maisVotado != null && totalMaisVotado > (totalVotosValidos / 2))
                        {
                            linhas.Add($"{maisVotado.Key.Nome} foi eleito como o mais votado, partido {maisVotado.Key.Partido.Nome}, com número de votos: {(int)totalMaisVotado}");
                            this.GravarArquivo(tituloArquivo, linhas);
                            eleicao.FinalizarEleicao(EStatusEleicao.FINALIZADA);


                        }
                        else
                        {
                            linhas.Add($"Eleiçao não concluída, o vencedor sera escolhido no segundo turno.");
                            linhas.Add("");
                            linhas.Add($"{maisVotado!.Key.Nome} 1º mais bem votado, partido {maisVotado.Key.Partido.Nome}, com número de votos: {(int)totalMaisVotado}");

                            if (eleicao.StatusEleicao != EStatusEleicao.FINALIZADA_SEGUNDO_TURNO)
                                eleicao.FinalizarEleicao(EStatusEleicao.FINALIZADA_SEGUNDO_TURNO);


                            if (segundoTurno == null)
                            {
                                segundoTurno = new Eleicao(eleicao.Ano, eleicao.Mes, eleicao.TipoEleicao, eleicao.Vagas)
                                {
                                    Ano = eleicao.Ano,
                                    IdPrimeiroTurno = eleicao.Id,
                                };

                                segundoTurno.EleicaoSegundoTurno();

                                if (votosGroupByCandidato.Count() > 1)
                                {
                                    var segundoMaisVotado = votosGroupByCandidato.ElementAt(1);
                                    var votosIguais = votosGroupByCandidato.Where(x => x.Key!.Id != maisVotado.Key.Id && x.Key!.Id != segundoMaisVotado.Key.Id && x.Count() == segundoMaisVotado.Count()).ToList();
                                    var segundoMaisVotadoMaiorIdade = votosIguais.Where(x => x.Key!.DataNascimento > segundoMaisVotado.Key.DataNascimento).FirstOrDefault();

                                    if (segundoMaisVotadoMaiorIdade != null)
                                        segundoMaisVotado = segundoMaisVotadoMaiorIdade;

                                    segundoTurno.CandidatosSegundoTurno.Add(maisVotado!.Key);
                                    segundoTurno.CandidatosSegundoTurno.Add(segundoMaisVotado!.Key);
                                    linhas.Add($"{segundoMaisVotado!.Key.Nome} 2º mais bem votado, partido {segundoMaisVotado.Key.Partido.Nome}, com número de votos: {(int)segundoMaisVotado.Count()}");
                                }



                                this.GravarArquivo(tituloArquivo, linhas);
                            }
                        }

                    });

                    dbset.Update(eleicao);
                    if (segundoTurno != null)
                        dbset.Add(segundoTurno);

                    dc.SaveChanges();
                }
                else
                {
                    linhas.Add($"Eleição do Legislativo ------------------------");
                    var votosGroupByPartido = eleicao.Votos.AsQueryable().Where(x => x.CandidatoId.HasValue).GroupBy(x => new { x.Candidato.Partido }).OrderByDescending(x => x.Count());
                    double coeficiente = totalVotosValidos / eleicao.Vagas!.Value;

                    linhas.AddRange(new[]{
                        $"Total de votos válidos: {totalVotosValidos}.",
                        $"Total de votos nulos: {eleicao.Votos.Where(x => !x.CandidatoId.HasValue && !x.Branco).Count()}.",
                        $"Total de votos brancos: {eleicao.Votos.Where(x => x.Branco).Count()}."
                        });
                    linhas.Add("");

                    votosGroupByPartido.ToList().ForEach(x =>
                    {
                        x.Key.Partido.Coeficiente = (int)(x.Count()/coeficiente);
                        linhas.Add($"Partido {x.Key.Partido.Nome} recebeu {x.Count()} Votos, e recebeu {x.Key.Partido.Coeficiente} das {eleicao.Vagas} disponíveis.");
                       
                        
                    });

                    linhas.Add("");
                    var somatorioSobra = (eleicao.Vagas - votosGroupByPartido.Sum(x => x.Key.Partido.Coeficiente))??0;
                    if (somatorioSobra>0)
                    {
                        linhas.Add($"Houve sobra de {somatorioSobra} cadeiras.");
                        for (int i = somatorioSobra; i > 0; i--)
                        {
                            votosGroupByPartido.ToList().ForEach(x =>
                            {
                                x.Key.Partido.Media = x.Count() / (somatorioSobra + 1);
                            });

                             votosGroupByPartido.OrderByDescending(x => x.Key.Partido.Media).ToList().First().Key.Partido.SobraGanha+=1;

                        }

                        var partidosComSobra = votosGroupByPartido.Where(x => x.Key.Partido.SobraGanha > 0).ToList();
                        partidosComSobra.ForEach(x => linhas.Add($"Partido {x.Key.Partido.Nome} recebeu {x.Key.Partido.SobraGanha} cadeira(s) da sobra de {somatorioSobra}."));

                    }

                    eleicao.FinalizarEleicao(EStatusEleicao.FINALIZADA);

                    this.GravarArquivo(tituloArquivo, linhas);
                    dbset.Update(eleicao);
                    

                    dc.SaveChanges();
                }
            }
        }


    }
}
