namespace TP
{
    class ArbolBinario<T>
    {
        private Clasificador raiz;
        public ArbolBinario(DecisionData clasificador)
        {
            this.raiz = new Clasificador(clasificador);   
        }
        private ArbolBinario(Clasificador nodo)
        {
            this.raiz = nodo;
        }
        private Clasificador getRaiz() 
        {
            return raiz;
        }
        public DecisionData getDatoRaiz() 
        {                                
           
                return this.getRaiz().getDato();
        }
        public ArbolBinario<T> obtenerClasificadorIzquierdo() 
        {
            if (this.raiz.obtenerClasificadorIzquierdo() == null)
            {
                return null;
            }
            return new ArbolBinario<T>(this.raiz.obtenerClasificadorIzquierdo());
            
        }
        public ArbolBinario<T> obtenerClasificadorDerecho()
        {
            if (this.raiz.obtenerClasificadorDerecho() == null)
            {
                return null;
            }
            return new ArbolBinario<T>(this.raiz.obtenerClasificadorDerecho());
        }
        public void agregarHijoIzquierdo(ArbolBinario<T> hijo)
        {
            if (hijo != null) 
            {
                this.raiz.modClasificadorIzquierdo(hijo.getRaiz());
            }
            else 
            {
                this.raiz.modClasificadorIzquierdo(null);
            }
        }

        public void agregarHijoDerecho(ArbolBinario<T> hijo)
        {
              if (hijo != null) 
            {
                this.raiz.modClasificadorDerecho(hijo.getRaiz());
            }
            else 
            {
                this.raiz.modClasificadorDerecho(null);
            }
        }

        public void setDatoRaiz(DecisionData dato)
        {
            this.raiz.setDato(dato);
        }
        public void eliminarHijoIzquierdo()
        {
            this.raiz.modClasificadorIzquierdo(null);
        }
         public void eliminarHijoDerecho()
        {
          
            this.raiz.modClasificadorDerecho(null);
            
        }
        public bool esVacio()
        {
            return this.raiz == null; 
        }
        public bool esHoja()
        {
            if (this.raiz == null)
            {
                return false;
            }
            return (this.obtenerClasificadorIzquierdo() == null || this.obtenerClasificadorIzquierdo().esVacio()) &&
                   (this.obtenerClasificadorDerecho() == null || this.obtenerClasificadorDerecho().esVacio());
        }

    }
    
}