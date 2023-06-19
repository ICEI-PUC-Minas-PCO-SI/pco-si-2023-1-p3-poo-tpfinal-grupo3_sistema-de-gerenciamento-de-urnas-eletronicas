using Controller.Generic;
using Model.DTO;
using Model.Helpers;
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
    public class PartidoController : ControllerBase<Partido>
    {
        public List<EnumHelperObject> ListCargos()
        {
            return Enums.ToSelectList<ECargo>();
        }

        public List<PartidoDTO> ListGrid()
        {
            return this.List().Select(x => new PartidoDTO()
            {
                Id = x.Id,
                Nome = x.Nome,
                Numero = x.Numero
            }).ToList();
        }


        public void InsertUpdate(List<PartidoDTO> data)
        {
            using (var cnx = new UrnaEletronicaContext())
            {
                var dbSet = cnx.Set<Partido>();

                var dataModelInsert = data.Where(x => !x.Id.HasValue).Select(x => new Partido(x.Nome, x.Numero)).ToList();

                var partidosRepetidos = dbSet.Where(x => dataModelInsert.Any(y => y.Numero == x.Numero)).ToList();

                if (partidosRepetidos.Count > 0)
                {
                    var sb = new StringBuilder();
                    partidosRepetidos.ForEach(x => sb.AppendFormat("{0}: Já existe um partido com o número {1}", x.Nome, x.Numero));
                    throw new Exception(sb.ToString());
                }

                var dataModelUpdate = data.Where(x => x.Id.HasValue).Select(x => new Partido(x.Nome, x.Numero) { Id = x.Id!.Value }).ToList();
                partidosRepetidos = dbSet.Where(x => dataModelUpdate.Any(y => y.Id != x.Id && y.Numero == x.Numero)).ToList();

                if (partidosRepetidos.Count > 0)
                {
                    var sb = new StringBuilder();
                    partidosRepetidos.ForEach(x => sb.AppendFormat("{0}: Já existe um partido com o número {1}", x.Nome, x.Numero));
                    throw new Exception(sb.ToString());
                }


                dbSet.AddRange(dataModelInsert);
                dbSet.UpdateRange(dataModelUpdate);

                cnx.SaveChanges();
            }

        }

        public void Delete(short partidoId)
        {
            using (var cnx = new UrnaEletronicaContext())
            {
                if (cnx.Set<Partido>().Where(x => x.Id == partidoId && x.Candidatos.Count > 0).Count() > 0)
                {
                    throw new Exception("Partido: Partido não pode ser excluído, pois ele ja participou de alguma eleição ou há algum candidato vinculado");
                }

                cnx.Remove(cnx.Set<Partido>().Find(partidoId)!);
                cnx.SaveChanges();
            }
        }
    }
}
