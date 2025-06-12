﻿using System;
using System.Collections.Generic;

namespace TP
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcionJuego = "";
            while (opcionJuego != "3")
            {
               
                Console.WriteLine("¡Bienvenido al juego de Adivinanza con Árboles de Decisión!");
                Console.WriteLine("\nElige el tipo de juego:");
                Console.WriteLine("1. Quién es Quién Clásico (Personajes clásicos)");
                Console.WriteLine("2. Bonus Track: Superhéroes y Villanos");
                Console.WriteLine("3. Salir del programa");
                Console.Write("Tu opción: ");
                opcionJuego = Console.ReadLine();

                ArbolBinario<DecisionData> arbolSeleccionado = null;
                string tituloJuego = "";
                List<string> personajesDisponibles = new List<string>();
                bool esJuegoClasico = false; 

                switch (opcionJuego)
                {
                    case "1":
                        tituloJuego = "Quién es Quién Clásico";
                        personajesDisponibles = new List<string> { "Alex", "Anita", "Bill", "Claire", "David", "Maria", "Susan", "Alfred" };
                        arbolSeleccionado = CrearArbolWhoIsWho();
                        esJuegoClasico = true; 
                        break;
                    case "2":
                        tituloJuego = "Bonus Track: Superhéroes y Villanos";
                        personajesDisponibles = new List<string> { "Superman", "Batman", "Wonder Woman", "Spiderman", "Wolverine", "Capitán América", "Joker", "Duende Verde" };
                        arbolSeleccionado = CrearArbolSuperheroes();
                        esJuegoClasico = false; 
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        return; 
                    default:
                        Console.WriteLine("Opción inválida. Por favor, elige 1, 2 o 3.");
                        Console.ReadKey();
                        continue; 
                }

                Console.Clear();
                Console.WriteLine($"¡Bienvenido al juego '{tituloJuego}'!");
                Console.WriteLine("Piensa en uno de los siguientes 8 personajes y yo intentaré adivinarlo:");
                foreach (string personaje in personajesDisponibles)
                {
                    Console.WriteLine($"- {personaje}");
                }
                Console.WriteLine("\nPresiona cualquier tecla para comenzar la adivinanza...");
                Console.ReadKey();

                JugarAdivinanza(arbolSeleccionado);

                if (esJuegoClasico) 
                {
                    Console.WriteLine("\n--- Demostración de métodos del árbol de decisiones ---");
                    Console.WriteLine("Ahora podemos ver cómo se estructuran las preguntas y predicciones para el juego clásico.");

                    Estrategia estrategiaDemo = new Estrategia(arbolSeleccionado.getDatoRaiz());

                    string opcionConsulta = "";
                    while (opcionConsulta != "4")
                    {
                        Console.WriteLine("\nElige una opción para ver la estructura del árbol:");
                        Console.WriteLine("1. Ver todas las preguntas en orden de nivel (Consulta1)");
                        Console.WriteLine("2. Ver todos los posibles caminos hacia los personajes (Consulta2)");
                        Console.WriteLine("3. Ver el árbol por niveles (Consulta3)");
                        Console.WriteLine("4. Volver al menú principal");
                        Console.Write("Tu opción: ");
                        opcionConsulta = Console.ReadLine();

                        switch (opcionConsulta)
                        {
                            case "1":
                                Console.WriteLine("\n--- Preguntas en orden de recorrido (BFS/por niveles) ---");
                                Console.WriteLine(estrategiaDemo.Consulta1(arbolSeleccionado));
                                break;
                            case "2":
                                Console.WriteLine("\n--- Todos los posibles caminos hacia los personajes (ramas del árbol) ---");
                                Console.WriteLine(estrategiaDemo.Consulta2(arbolSeleccionado));
                                break;
                            case "3":
                                Console.WriteLine("\n--- Estructura del árbol por niveles ---");
                                Console.WriteLine(estrategiaDemo.Consulta3(arbolSeleccionado));
                                break;
                            case "4":
                                Console.WriteLine("Volviendo al menú principal.");
                                break;
                            default:
                                Console.WriteLine("Opción inválida. Por favor, elige un número del 1 al 4.");
                                break;
                        }
                        if (opcionConsulta != "4")
                        {
                            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                }
                else 
                {
                    Console.WriteLine("\nJuego de Superhéroes y Villanos terminado. Volviendo al menú principal.");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                
            }
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
        public static ArbolBinario<DecisionData> CrearArbolSuperheroes()
        {
            DecisionData superman = new DecisionData(new Dictionary<string, int> { { "Superman", 1 } });
            DecisionData batman = new DecisionData(new Dictionary<string, int> { { "Batman", 1 } });
            DecisionData wonderWoman = new DecisionData(new Dictionary<string, int> { { "Wonder Woman", 1 } });
            DecisionData spiderman = new DecisionData(new Dictionary<string, int> { { "Spiderman", 1 } });
            DecisionData wolverine = new DecisionData(new Dictionary<string, int> { { "Wolverine", 1 } });
            DecisionData capitanAmerica = new DecisionData(new Dictionary<string, int> { { "Capitán América", 1 } });
            DecisionData joker = new DecisionData(new Dictionary<string, int> { { "Joker", 1 } });
            DecisionData duendeVerde = new DecisionData(new Dictionary<string, int> { { "Duende Verde", 1 } });

            Pregunta esVillano = new Pregunta("¿Es un villano?");
            Pregunta usaCapa = new Pregunta("¿Usa capa?");
            Pregunta vuela = new Pregunta("¿Vuela?");
            Pregunta esMujer = new Pregunta("¿Es una mujer?");
            Pregunta usaEscudo = new Pregunta("¿Usa escudo?");
            Pregunta tieneGarras = new Pregunta("¿Tiene garras?");
            Pregunta usaMaquillajePayaso = new Pregunta("¿Usa maquillaje de payaso?");

            ArbolBinario<DecisionData> arbolRaiz = new ArbolBinario<DecisionData>(new DecisionData(esVillano));

            ArbolBinario<DecisionData> nodoEsVillano = new ArbolBinario<DecisionData>(new DecisionData(usaMaquillajePayaso));
            arbolRaiz.agregarHijoIzquierdo(nodoEsVillano);

            nodoEsVillano.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(joker));
            nodoEsVillano.agregarHijoDerecho(new ArbolBinario<DecisionData>(duendeVerde));

            ArbolBinario<DecisionData> nodoEsHeroe = new ArbolBinario<DecisionData>(new DecisionData(usaCapa));
            arbolRaiz.agregarHijoDerecho(nodoEsHeroe);

            ArbolBinario<DecisionData> nodoUsaCapaHeroe = new ArbolBinario<DecisionData>(new DecisionData(vuela));
            nodoEsHeroe.agregarHijoIzquierdo(nodoUsaCapaHeroe);

            nodoUsaCapaHeroe.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(superman));
            nodoUsaCapaHeroe.agregarHijoDerecho(new ArbolBinario<DecisionData>(batman));

            ArbolBinario<DecisionData> nodoNoUsaCapaHeroe = new ArbolBinario<DecisionData>(new DecisionData(esMujer));
            nodoEsHeroe.agregarHijoDerecho(nodoNoUsaCapaHeroe);

            nodoNoUsaCapaHeroe.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(wonderWoman));
            ArbolBinario<DecisionData> nodoHombreSinCapa = new ArbolBinario<DecisionData>(new DecisionData(usaEscudo));
            nodoNoUsaCapaHeroe.agregarHijoDerecho(nodoHombreSinCapa);

            nodoHombreSinCapa.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(capitanAmerica));
            ArbolBinario<DecisionData> nodoHombreSinCapaNiEscudo = new ArbolBinario<DecisionData>(new DecisionData(tieneGarras));
            nodoHombreSinCapa.agregarHijoDerecho(nodoHombreSinCapaNiEscudo);

            nodoHombreSinCapaNiEscudo.agregarHijoIzquierdo(new ArbolBinario<DecisionData>(wolverine));
            nodoHombreSinCapaNiEscudo.agregarHijoDerecho(new ArbolBinario<DecisionData>(spiderman));

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