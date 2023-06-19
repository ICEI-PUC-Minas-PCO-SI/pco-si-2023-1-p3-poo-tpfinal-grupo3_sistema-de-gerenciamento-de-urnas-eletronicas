using Controller.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Abstract;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visao;

namespace Controller.Generic
{
    public abstract class ControllerBase<M> : IControllerBase<M> where M : ModelBase
    {

        public List<M> List()
        {
            using (var dc = new UrnaEletronicaContext())
            {
                return dc.Set<M>().ToList();
            }
        }

        public M? GetById(short id)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                return dc.Set<M>().Find(id);
            }
        }

        public M? GetById(int id)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                return dc.Set<M>().Find(id);
            }
        }

        public M? GetById(long id)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                return dc.Set<M>().Find(id);
            }
        }

        public virtual void Insert(M model, bool saveChanges = true)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                dc.Set<M>().Add(model);

                if (saveChanges)
                    dc.SaveChanges();
            }
        }

        public virtual void Update(M model, bool saveChanges = true)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                dc.Set<M>().Update(model);
               
                if (saveChanges)
                    dc.SaveChanges();
            }
        }

        public virtual void Delete(M model, bool saveChanges = true)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                dc.Set<M>().Remove(model);

                if (saveChanges)
                    dc.SaveChanges();

            }
        }


        public virtual void Insert(List<M> models, bool saveChanges = true)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                dc.Set<M>().AddRange(models);

                if (saveChanges)
                    dc.SaveChanges();
            }
        }

        public virtual void Update(List<M> models, bool saveChanges = true)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                dc.Set<M>().UpdateRange(models);

                if (saveChanges)
                    dc.SaveChanges();
            }
        }

        public virtual void Delete(List<M> models, bool saveChanges = true)
        {
            using (var dc = new UrnaEletronicaContext())
            {
                dc.Set<M>().RemoveRange(models);

                if (saveChanges)
                    dc.SaveChanges();

            }
        }
    }
}
