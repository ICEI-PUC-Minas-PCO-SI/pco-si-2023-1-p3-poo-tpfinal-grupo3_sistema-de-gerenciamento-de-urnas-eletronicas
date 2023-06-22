using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Abstract
{
    //classe abstrata para formalizar um model
    public abstract class ModelBase : IModelBase
    {
        public virtual void Validate() { }

       
    }
}
