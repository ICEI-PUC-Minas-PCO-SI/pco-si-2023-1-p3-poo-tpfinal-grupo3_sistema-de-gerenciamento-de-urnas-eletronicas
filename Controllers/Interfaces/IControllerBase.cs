using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visao;

namespace Controller.Interfaces
{
    //interface para garantir o contrato de um controler.
    //métodos com auxilido de um parametro(tipo model) genérico para facilitar o crud base dos modelos
    public interface IControllerBase<M> where M : ModelBase
    {
        List<M> List();

        M? GetById(short id);

        M? GetById(int id);

        M? GetById(long id);

        void Insert(M model, bool saveChanges = true);

        void Update(M model, bool saveChanges = true);

        void Delete(M model, bool saveChanges = true);

        void Insert(List<M> models, bool saveChanges = true);

        void Update(List<M> models, bool saveChanges = true);

        void Delete(List<M> models, bool saveChanges = true);
    }
}
