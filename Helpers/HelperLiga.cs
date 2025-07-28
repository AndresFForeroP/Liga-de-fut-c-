using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_Fut.Helpers
{
    public class HelperLiga
    {
        public int GenerarIdUnico<T>(HashSet<T> objetos, Func<T, int> obtenerId)
        {
            Random random = new Random();
            int id;
            bool idRepetido;
            do
            {
                id = random.Next(1, 100000);
                idRepetido = objetos.Any(item => obtenerId(item) == id);
            } while (idRepetido);
            return id;
        }
        public string validarNombre<T>(HashSet<T> objetos, Func<T, string> obtenerNombre)
        {
            Console.WriteLine("Ingrese el nombre del torneo");
            string nombre = Console.ReadLine() ?? "";
            while (nombre == "")
            {
                Console.Clear();
                Console.WriteLine("EL torneo tiene que tener un nombre");
                Console.WriteLine("Ingrese el nombre del torneo");
                nombre = Console.ReadLine() ?? "";
            }
            if (objetos.Count > 0)
            {
                while (objetos.Any(torneo => obtenerNombre != null && obtenerNombre.Equals(nombre.ToLower())) || nombre == "")
                {
                    if (nombre == "")
                    {
                        Console.Clear();
                        Console.WriteLine("EL torneo tiene que tener un nombre");
                        Console.WriteLine("Ingrese el nombre del torneo");
                        nombre = Console.ReadLine() ?? "";
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("EL nombre del torneo ya esta registrado");
                        Console.WriteLine("Ingrese el nombre de un torneo que no este registrado");
                        nombre = Console.ReadLine() ?? "";
                    }
                }
            }
            return nombre;
        }
        public int validadCapacidad(int capacidadMaxima, int capacidadMinima,string formato)
        {
            int capacidad = 0;
            string pedirCantidad = "";
            string mensajeError = "";
            if (formato == "torneo")
            {
                pedirCantidad = "Ingrese la cantidad de equipos que va a tener el torneo";
                mensajeError = $"la capacidad del torneo es de almenos {capacidadMinima} equipos hasta {capacidadMaxima} equipos";
            }
            else
            {
                pedirCantidad = "Ingrese la cantidad de jugadores que va a tener el equipo";
                if (capacidadMinima == 1)
                {
                    
                }
                mensajeError = $"la capacidad del equipo es de almenos {capacidadMinima} jugador hasta {capacidadMaxima}";
            }
            Console.WriteLine(pedirCantidad);
            while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad > capacidadMaxima || capacidad <= capacidadMinima)
            {
                Console.WriteLine("ingrese un capacidad valida");
                if (capacidad > 22 || capacidad <= 1)
                {
                    Console.WriteLine(mensajeError);
                }
            }
            Console.Clear();
            return capacidad;
        }
    }
}