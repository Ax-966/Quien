using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace TP
{
    public class Cola<T>
    {
        private List<T> datos = new List<T>();

        public void encolar(T elem)
        {
            this.datos.Add(elem);
        }
        public T desencolar()
        {
            T temp = this.datos[0];
            this.datos.RemoveAt(0);
            return temp;
        }
        public T tope() 
        {
            return this.datos[0];
        }
        public int Cantidad
        {
            get { return datos.Count; }
        }
        public bool esVacia()
        {
            return this.datos.Count == 0;
        }
    }
}