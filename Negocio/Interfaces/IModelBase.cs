using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    //interface para garantir o contrato de um model, onde o mesmo deve conter sua própia validação para garantir a consistência do modelo de negocio.
    public interface IModelBase
    {
        void Validate();
    }
}
