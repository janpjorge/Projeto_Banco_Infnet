using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Repositorios
{
    public abstract class IRepositorio<T>
    {
        protected IRepositorio()
        {

        }

        protected static IRepositorio<T> instance;
          
        protected static List<T> Items = new List<T>();

        public virtual void Adiciona(T item)
        {
            Items.Add(item);
        }

        public virtual T[] RetornaTodos()
        {
            return Items.ToArray();
        }
    }
}
