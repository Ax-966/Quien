using System;

namespace TP
{
    public class Clasificador
    {
        private DecisionData dato; 
        private Clasificador clasificadorIzquierdo; 
        private Clasificador clasificadorDerecho;

        public Clasificador(DecisionData dato)
        {

            this.dato = dato;
            this.clasificadorIzquierdo = null;
            this.clasificadorDerecho = null;
        }
        public DecisionData getDato()  
        {
            return this.dato;
        }
        public bool crearHoja()
        {
            bool p;  
            if (this.dato.Prediccion != null) 
            {
                p = true;
            }
            else 
            {
                p = false;
            }
            return p;
        }
        public Dictionary<string, int> obtenerDatoHoja()
        {
            if (crearHoja()) 
            {
                return this.dato.Prediccion;
            }
            else
            {
                return null; 
            }
        }
        public Pregunta obtenerInterrogante()
        {
            return this.dato.Interrogacion; 
        }
        public Clasificador obtenerClasificadorIzquierdo() 
        {
            return this.clasificadorIzquierdo;
        }
        public Clasificador obtenerClasificadorDerecho() 
        {
            return this.clasificadorDerecho;
        }
        public void modClasificadorIzquierdo(Clasificador clasIzq) 
        {
            this.clasificadorIzquierdo = clasIzq; 
        }
        public void modClasificadorDerecho(Clasificador clasDer)
        {
            this.clasificadorDerecho = clasDer;
          
        }
        public void setDato(DecisionData dato)
        {
            this.dato = dato;
        }
    }
}