using System.ComponentModel.DataAnnotations;
using System.Text; 

namespace TP
{
    class Estrategia : ArbolBinario<DecisionData>
    {
        public Estrategia(DecisionData datoRaiz) : base(datoRaiz)
        {

        }
        public ArbolBinario<DecisionData> CrearArbol(Clasificador clasificador)
        {
            if (clasificador == null)
            {
                return null; 
            }
            ArbolBinario<DecisionData> arbolNuevo;
            if (clasificador.crearHoja())
            {
                arbolNuevo = new ArbolBinario<DecisionData>(new DecisionData(clasificador.obtenerDatoHoja()));
            }
            else
            {
                arbolNuevo = new ArbolBinario<DecisionData>(new DecisionData(clasificador.obtenerInterrogante()));
                arbolNuevo.agregarHijoIzquierdo(CrearArbol(clasificador.obtenerClasificadorIzquierdo()));
                arbolNuevo.agregarHijoDerecho(CrearArbol(clasificador.obtenerClasificadorDerecho()));
            }
            return arbolNuevo;
        }
        public string Consulta1(ArbolBinario<DecisionData> arbol)
        {

            Cola<ArbolBinario<DecisionData>> c = new Cola<ArbolBinario<DecisionData>>();

            string predicciones = "";

            if (arbol == null || arbol.esVacio())
            {
                return "Árbol inicial vacío o nulo para Consulta1.";
            }

            c.encolar(arbol);
            while (!c.esVacia())
            {
                ArbolBinario<DecisionData> arbolPre = c.desencolar();
                
             
                if (arbolPre.esVacio())
                {
                    continue; 
                }

               
                if (arbolPre.getDatoRaiz().Interrogacion != null && arbolPre.getDatoRaiz().Interrogacion.Pre != null)
                {
                    predicciones += arbolPre.getDatoRaiz().Interrogacion.Pre + ", ";
                    
               
                    ArbolBinario<DecisionData> hijoIzquierdo = arbolPre.obtenerClasificadorIzquierdo();
                    if (hijoIzquierdo != null && !hijoIzquierdo.esVacio())
                    {
                        c.encolar(hijoIzquierdo);
                    }
                    
                    ArbolBinario<DecisionData> hijoDerecho = arbolPre.obtenerClasificadorDerecho();
                    if (hijoDerecho != null && !hijoDerecho.esVacio())
                    {
                        c.encolar(hijoDerecho);
                    }
                }
            }
            return predicciones.ToString();
        }
        public string Consulta2(ArbolBinario<DecisionData> arbol)
        {
            List<string> caminos = new List<string>();
            List<string> caminoActual = new List<string>();
            this._Caminos(arbol, caminoActual, caminos);


            return string.Join("\n", caminos);
        }
        public void _Caminos(ArbolBinario<DecisionData> arbol, List<string> caminoActual, List<string> caminos)
        {
            if (arbol == null)
            {
                return;
            }
            caminoActual.Add(arbol.getDatoRaiz().ObtenerTexto());
            if (arbol.esHoja())
            {
                caminos.Add(string.Join(" --> ", caminoActual));
            }
            else
            {
                if (arbol.obtenerClasificadorIzquierdo() != null)
                {
                    List<string> caminoCopia = new List<string>(caminoActual);
                    caminoCopia.Add("Sí");
                    _Caminos(arbol.obtenerClasificadorIzquierdo(), caminoCopia, caminos);
                }
                if (arbol.obtenerClasificadorDerecho() != null)
                {
                    List<string> caminoCopia = new List<string>(caminoActual);
                    caminoCopia.Add("No");
                    _Caminos(arbol.obtenerClasificadorDerecho(), caminoCopia, caminos);
                }
            }

        }
        public string Consulta3(ArbolBinario<DecisionData> arbol)
        {
            string predicciones = "";
            Cola<ArbolBinario<DecisionData>> c = new Cola<ArbolBinario<DecisionData>>();
            int nivel = 0;

            if (arbol == null || arbol.esVacio())
            {
                return "Árbol vacío o nulo.";
            }

            c.encolar(arbol);

            while (!c.esVacia())
            {
                int cantidadEnNivel = c.Cantidad; 

                predicciones += "Nivel " + nivel + ": ";


                for (int i = 0; i < cantidadEnNivel; i++)
                {
                    ArbolBinario<DecisionData> arbolPre = c.desencolar();

                    
                    if (arbolPre.esVacio())
                    {
                        continue; 
                    }
                    if (arbolPre.getDatoRaiz().Interrogacion != null &&
                        arbolPre.getDatoRaiz().Interrogacion.Pre != null)
                    {
                        predicciones += arbolPre.getDatoRaiz().Interrogacion.Pre + ", ";
                    }
                    else if (arbolPre.getDatoRaiz().Prediccion != null)
                    {
                        predicciones += arbolPre.getDatoRaiz().ObtenerTexto() + ", ";
                    }

                    ArbolBinario<DecisionData> hijoIzquierdo = arbolPre.obtenerClasificadorIzquierdo();
                    if (hijoIzquierdo != null && !hijoIzquierdo.esVacio())
                    {
                        c.encolar(hijoIzquierdo);
                    }

                    ArbolBinario<DecisionData> hijoDerecho = arbolPre.obtenerClasificadorDerecho();
                    if (hijoDerecho != null && !hijoDerecho.esVacio())
                    {
                        c.encolar(hijoDerecho);
                    }
                }

                predicciones += "\n";
                nivel++;
            }

            return predicciones;
        }
    }
}