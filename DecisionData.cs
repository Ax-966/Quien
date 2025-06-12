using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.Marshalling;

namespace TP
{
    public class DecisionData
    {
        private Pregunta interrogacion;
        private Dictionary<string, int> prediccion;

        public DecisionData(Pregunta interrogacion)
        {
            this.interrogacion = interrogacion; ;
        }
        public DecisionData(Dictionary<string, int> prediccion)
        {
            this.prediccion = prediccion;
        }
        public string ObtenerTexto()
        {
            string resultado = "";
            if (interrogacion != null)
            {
                resultado = this.interrogacion.Pre; 
            }
            else if (prediccion != null)
            {
                foreach (var entrada in prediccion)
                {
                    resultado = entrada.Key; 
                    break; 
                }
            }
            else
            {
                resultado = "No hay datos";
            }
            return resultado;
        }

        public Pregunta Interrogacion
        {
            get
            {
                return interrogacion;
            }
            set
            {
                interrogacion = value;
            }

        }
        public Dictionary<string, int> Prediccion
        {
            get
            {
                return prediccion;
            }
            set
            {
                prediccion = value;
            }
        }
    }
}
