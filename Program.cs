﻿using System;
using System.Collections.Generic;

namespace TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido al juego 'Quién es Quién' versión clásica!");
            Console.WriteLine("Piensa en uno de los siguientes 8 personajes y yo intentaré adivinarlo:");
            Console.WriteLine("- Alex");
            Console.WriteLine("- Anita");
            Console.WriteLine("- Bill");
            Console.WriteLine("- Claire");
            Console.WriteLine("- David");
            Console.WriteLine("- Maria");
            Console.WriteLine("- Susan");
            Console.WriteLine("- Alfred");
            Console.WriteLine("\nPresiona cualquier tecla para comenzar...");
            Console.ReadKey();

    
            ArbolBinario<DecisionData> arbolPersonajes = CrearArbolWhoIsWho();

       
            JugarAdivinanza(arbolPersonajes);

            Console.WriteLine("\n--- Demostración de métodos del árbol de decisiones ---");
            Console.WriteLine("Ahora podemos ver cómo se estructuran las preguntas y predicciones.");

        
            Estrategia estrategiaDemo = new Estrategia(arbolPersonajes.getDatoRaiz());
           

            string opcion = "";
            while (opcion != "4")
            {
                Console.WriteLine("\nElige una opción para ver la estructura del árbol:");
                Console.WriteLine("1. Ver todas las preguntas en orden de nivel (Consulta1)");
                Console.WriteLine("2. Ver todos los posibles caminos hacia los personajes (Consulta2)");
                Console.WriteLine("3. Ver el árbol por niveles (Consulta3)");
                Console.WriteLine("4. Salir");
                Console.Write("Tu opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- Preguntas en orden de recorrido (BFS/por niveles) ---");
                        Console.WriteLine(estrategiaDemo.Consulta1(arbolPersonajes));
                        break;
                    case "2":
                        Console.WriteLine("\n--- Todos los posibles caminos hacia los personajes (ramas del árbol) ---");
                        Console.WriteLine(estrategiaDemo.Consulta2(arbolPersonajes));
                        break;
                    case "3":
                        Console.WriteLine("\n--- Estructura del árbol por niveles ---");
                        Console.WriteLine(estrategiaDemo.Consulta3(arbolPersonajes));
                        break;
                    case "4":
                        Console.WriteLine("Saliendo de la demostración.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, elige un número del 1 al 4.");
                        break;
                }
            }

            Console.WriteLine("\n¡Gracias por jugar!");
            Console.ReadKey();
        }

        public static ArbolBinario<DecisionData> CrearArbolWhoIsWho()
        {
            
            DecisionData alex = new DecisionData(new Dictionary<string, int> { { "Alex", 1 } });
            DecisionData anita = new DecisionData(new Dictionary<string, int> { { "Anita", 1 } });
            DecisionData bill = new DecisionData(new Dictionary<string, int> { { "Bill", 1 } });
            DecisionData claire = new DecisionData(new Dictionary<string, int> { { "Claire", 1 } });
            DecisionData david = new DecisionData(new Dictionary<string, int> { { "David", 1 } });
            DecisionData maria = new DecisionData(new Dictionary<string, int> { { "Maria", 1 } });
            DecisionData susan = new DecisionData(new Dictionary<string, int> { { "Susan", 1 } });
            DecisionData alfred = new DecisionData(new Dictionary<string, int> { { "Alfred", 1 } });

            Pregunta esHombre = new Pregunta("¿Es un hombre?");
            Pregunta usaSombrero = new Pregunta("¿Usa sombrero?");
            Pregunta tieneLentes = new Pregunta("¿Usa lentes?");
            Pregunta tieneBigote = new Pregunta("¿Tiene bigote?");
            Pregunta tienePeloRubio = new Pregunta("¿Tiene pelo rubio?");
            Pregunta tienePeloNegro = new Pregunta("¿Tiene el pelo negro?");


            ArbolBinario<DecisionData> arbolRaiz = new ArbolBinario<DecisionData>(new DecisionData(esHombre));

            ArbolBinario<DecisionData> nodoEsHombre = new ArbolBinario<DecisionData>(new DecisionData(tieneBigote));
            arbolRaiz.agregarHijoIzquierdo(nodoEsHombre);

            ArbolBinario<DecisionData> nodoTieneBigoteHombre = new ArbolBinario<DecisionData>(new DecisionData(tienePeloRubio));
            nodoEsHombre.agregarHijoIzquierdo(nodoTieneBigoteHombre);

            nodoTieneBigoteHombre.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(alfred));

            nodoTieneBigoteHombre.agregarHijoDerecho(new ArbolBinario<DecisionData>(bill));


        
            ArbolBinario<DecisionData> nodoNoTieneBigote = new ArbolBinario<DecisionData>(new DecisionData(usaSombrero));
            nodoEsHombre.agregarHijoDerecho(nodoNoTieneBigote);

     
            nodoNoTieneBigote.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(david));

            ArbolBinario<DecisionData> nodoNoUsaSombrero = new ArbolBinario<DecisionData>(new DecisionData(tieneLentes));
            nodoNoTieneBigote.agregarHijoDerecho(nodoNoUsaSombrero);

         
            nodoNoUsaSombrero.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(alex));

            ArbolBinario<DecisionData> nodoEsMujer = new ArbolBinario<DecisionData>(new DecisionData(tienePeloRubio));
            arbolRaiz.agregarHijoDerecho(nodoEsMujer);

            nodoEsMujer.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(anita));


            ArbolBinario<DecisionData> nodoNoPeloRubio = new ArbolBinario<DecisionData>(new DecisionData(tieneLentes));
            nodoEsMujer.agregarHijoDerecho(nodoNoPeloRubio);

      
            nodoNoPeloRubio.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(susan));

            ArbolBinario<DecisionData> nodoNoLentesMujer = new ArbolBinario<DecisionData>(new DecisionData(tienePeloNegro));
            nodoNoPeloRubio.agregarHijoDerecho(nodoNoLentesMujer);

            nodoNoLentesMujer.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(maria));

            nodoNoLentesMujer.agregarHijoDerecho(new ArbolBinario<DecisionData>(claire));

            return arbolRaiz;
        }
         public static void JugarAdivinanza(ArbolBinario<DecisionData> arbol)
        {
            if (arbol == null || arbol.esVacio())
            {
                Console.WriteLine("El árbol de decisiones está vacío. No se puede jugar.");
                return;
            }

            ArbolBinario<DecisionData> nodoActual = arbol;

            while (!nodoActual.esHoja())
            {
                if (nodoActual.getDatoRaiz().Interrogacion != null)
                {
                    Console.WriteLine($"\nPregunta: {nodoActual.getDatoRaiz().Interrogacion.Pre} (responde S/N)");
                    string respuesta = Console.ReadLine().Trim().ToUpper();

                    if (respuesta == "S")
                    {
                        if (nodoActual.obtenerClasificadorIzquierdo() != null && !nodoActual.obtenerClasificadorIzquierdo().esVacio())
                        {
                            nodoActual = nodoActual.obtenerClasificadorIzquierdo();
                        }
                        else
                        {
                            Console.WriteLine("Lo siento, no puedo continuar. Parece que la rama 'S' está vacía o no lleva a un personaje conocido. ¡Asegúrate de haber respondido correctamente!");
                            return;
                        }
                    }
                    else if (respuesta == "N")
                    {
                        if (nodoActual.obtenerClasificadorDerecho() != null && !nodoActual.obtenerClasificadorDerecho().esVacio())
                        {
                            nodoActual = nodoActual.obtenerClasificadorDerecho();
                        }
                        else
                        {
                            Console.WriteLine("Lo siento, no puedo continuar. Parece que la rama 'N' está vacía o no lleva a un personaje conocido. ¡Asegúrate de haber respondido correctamente!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Respuesta inválida. Por favor, responde 'S' para Sí o 'N' para No.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Se esperaba una pregunta en este nodo del árbol.");
                    return;
                }
            }

            if (nodoActual.getDatoRaiz().Prediccion != null)
            {
                Console.WriteLine($"\n¡Tu personaje es: {nodoActual.getDatoRaiz().ObtenerTexto()}!");
            }
            else
            {
                Console.WriteLine("\nNo pude adivinar tu personaje. Asegúrate de haber respondido correctamente.");
            }
        }
    }
}