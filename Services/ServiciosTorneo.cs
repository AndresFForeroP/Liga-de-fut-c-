using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_Fut.models;

namespace Liga_Fut.Services
{
    public class ServiciosTorneo
    {
        public string validarCreacion(int id, string nombre, int capacidad)
        {
            Console.WriteLine("los datos del torneo son:");
            Console.WriteLine($"El id generado fue #{id}");
            Console.WriteLine($"Nombre de torneo: {nombre} - Capacidad torneo: {capacidad} equipos");
            Console.WriteLine("esta seguro de agreagar el torneo?");
            Console.WriteLine("ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro;
        }
        public void buscarPorID(HashSet<Torneo> Torneos)
        {
            bool existe = false;
            int idbusqueda = 0;
            Console.WriteLine("Ingrese el id del torneo que desea buscar");
            while (!int.TryParse(Console.ReadLine(), out idbusqueda) || idbusqueda <= 0)
            {
                Console.WriteLine("ingrese un id de torneo valida");
            }
            foreach (var item in Torneos)
            {
                if (item.Id == idbusqueda)
                {
                    Console.Clear();
                    existe = true;
                    Console.WriteLine("Torneo encontrado");
                    Console.WriteLine(item.datostorneo());
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadKey();
                }
            }
            if (existe == false)
            {
                Console.Clear();
                Console.WriteLine("No exise ningun torneo registrado con ese id");
                Console.WriteLine("Presione enter para continuar");
                Console.ReadKey();
            }
        }
        public void buscarPorNombre(HashSet<Torneo> Torneos)
        {
            bool existe = false;
            string nombrebusqueda = "";
            Console.WriteLine("Ingrese el nombre del torneo que desea buscar");
            nombrebusqueda = Console.ReadLine() ?? "";
            while (nombrebusqueda == "")
            {
                Console.Clear();
                Console.WriteLine("EL torneo tiene que tener un nombre");
                Console.WriteLine("Ingrese el nombre del torneo que desea buscar");
                nombrebusqueda = Console.ReadLine() ?? "";
            }
            foreach (var item in Torneos)
            {
                if (item.Nombre == nombrebusqueda)
                {
                    Console.Clear();
                    existe = true;
                    Console.WriteLine("Torneo encontrado");
                    Console.WriteLine(item.datostorneo());
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadKey();
                }
            }
            if (existe == false)
            {
                Console.Clear();
                Console.WriteLine("No exise ningun torneo registrado con ese nombre");
                Console.WriteLine("Presione enter para continuar");
                Console.ReadKey();
            }
        }
        public void eliminarPorId(HashSet<Torneo> Torneos)
        {
            int idbusqueda = 0;
            bool existe = false;
            string seguro = "";
            Console.Clear();
            Console.WriteLine("Ingrese el id del torneo que desea buscar");
            while (!int.TryParse(Console.ReadLine(), out idbusqueda) || idbusqueda <= 0)
            {
                Console.WriteLine("Ingrese un id de torneo valida");
            }
            foreach (var item in Torneos)
            {
                if (item.Id == idbusqueda)
                {
                    Console.Clear();
                    existe = true;
                    Console.WriteLine("Torneo encontrado");
                    Console.WriteLine(item.datostorneo());
                    Console.WriteLine("Esta seguro de eliminar el torneo?");
                    Console.WriteLine("Ingrese si para eliminar el torneo o no si desea volver");
                    seguro = Console.ReadLine() ?? "";
                    while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                    {
                        Console.WriteLine("Valor invalido");
                        Console.WriteLine("Ingrese si para eliminar el torneo o no si desea volver");
                        seguro = Console.ReadLine() ?? "";
                    }
                    if (seguro == "si")
                    {
                        Torneos.RemoveWhere(torneo => torneo.Id == idbusqueda);
                        Console.WriteLine("Torneo eliminado con exito");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }
            if (existe == false)
            {
                Console.Clear();
                Console.WriteLine("No exise ningun torneo registrado con ese id");
                Console.WriteLine("Presione enter para continuar");
                Console.ReadKey();
            }
        }
        public void eliminarPorNombre(HashSet<Torneo> Torneos)
        {
            Console.Clear();
            string seguro = "";
            bool existe = false;
            string nombrebusqueda = "";
            Console.WriteLine("Ingrese el nombre del torneo que desea eliminar");
            nombrebusqueda = Console.ReadLine() ?? "";
            while (nombrebusqueda == "")
            {
                Console.Clear();
                Console.WriteLine("EL torneo tiene que tener un nombre");
                Console.WriteLine("Ingrese el nombre del torneo que desea eliminar");
                nombrebusqueda = Console.ReadLine() ?? "";
            }
            foreach (var item in Torneos)
            {
                if (item.Nombre == nombrebusqueda)
                {
                    Console.Clear();
                    existe = true;
                    Console.WriteLine("Torneo encontrado");
                    Console.WriteLine(item.datostorneo());
                    Console.WriteLine("Esta seguro de eliminar el torneo?");
                    Console.WriteLine("Ingrese si para eliminar el torneo o no si desea volver");
                    seguro = Console.ReadLine() ?? "";
                    while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                    {
                        Console.WriteLine("Valor invalido");
                        Console.WriteLine("Ingrese si para eliminar el torneo o no si desea volver");
                        seguro = Console.ReadLine() ?? "";
                    }
                    if (seguro == "si")
                    {
                        Torneos.RemoveWhere(torneo => torneo.Nombre == nombrebusqueda);
                        Console.WriteLine("Torneo eliminado con exito");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }
            if (existe == false)
            {
                Console.Clear();
                Console.WriteLine("No exise ningun torneo registrado con ese nombre");
                Console.WriteLine("Presione enter para continuar");
                Console.ReadKey();
            }
        }
        public void actualizarPorId(HashSet<Torneo> Torneos)
        {
            int idbusqueda = 0;
            bool existe = false;
            int capacidad = 0;
            string seguro = "";
            Console.WriteLine("Ingrese el id del torneo que desea Actualizar");
            while (!int.TryParse(Console.ReadLine(), out idbusqueda) || idbusqueda <= 0)
            {
                Console.WriteLine("Ingrese un id de torneo valida");
            }
            foreach (var item in Torneos)
            {
                if (item.Id == idbusqueda)
                {
                    string auxiliar = item.Nombre ?? "";
                    Console.Clear();
                    existe = true;
                    Console.WriteLine("Torneo encontrado");
                    Console.WriteLine(item.datostorneo());
                    item.Nombre = "";
                    Console.WriteLine("Ingrese el nombre nuevo del torneo");
                    string nombre = Console.ReadLine() ?? "";
                    while (nombre == "" || Torneos.Any(torneo => torneo.Nombre != null && torneo.Nombre.Equals(nombre.ToLower())))
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
                            Console.WriteLine($"EL torneo llamado {nombre} ya existe");
                            Console.WriteLine("Ingrese el nuevo nombre del torneo");
                            nombre = Console.ReadLine() ?? "";
                        }

                    }
                    Console.WriteLine("Ingrese la cantidad de equipos que va a tener el torneo actualizado");
                    while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad > 22 || capacidad <= 1)
                    {
                        Console.WriteLine("Ingrese un capacidad valida");
                        if (capacidad > 22 || capacidad <= 1)
                        {
                            Console.WriteLine("La capacidad del torneo es de almenos 2 equipos hasta 22 equipos");
                        }
                    }
                    Console.WriteLine("Los datos del nuevos del torneo son:");
                    Console.WriteLine($"Nombre torneo = {nombre}, capacidad de equipos = {capacidad}");
                    Console.WriteLine("Esta seguro de actualizar el torneo?");
                    Console.WriteLine("Ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                    seguro = Console.ReadLine() ?? "";
                    while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                    {
                        Console.WriteLine("Valor invalido");
                        Console.WriteLine("Ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                        seguro = Console.ReadLine() ?? "";
                    }
                    if (seguro == "si")
                    {
                        Console.WriteLine("Torneo actualizado con con exito");
                        item.Nombre = nombre;
                        item.Capacidad = capacidad;
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {
                        item.Nombre = auxiliar;
                        Console.Clear();
                    }
                    break;
                }
            }
            if (existe == false)
            {
                Console.Clear();
                Console.WriteLine("No exise ningun torneo registrado con ese id");
                Console.WriteLine("Presione enter para continuar");
                Console.ReadKey();
            }
        }
        public void actualizarPorNombre(HashSet<Torneo> Torneos)
        {
            string nombrebusqueda = "";
            bool existe = false;
            int capacidad = 0;
            string seguro = "";
            Console.WriteLine("Ingrese el nombre del torneo que desea actualizar");
            nombrebusqueda = Console.ReadLine() ?? "";
            while (nombrebusqueda == "")
            {
                Console.Clear();
                Console.WriteLine("EL torneo tiene que tener un nombre");
                Console.WriteLine("Ingrese el nombre del torneo que desea actualizar");
                nombrebusqueda = Console.ReadLine() ?? "";
            }
            foreach (var item in Torneos)
            {
                if (item.Nombre == nombrebusqueda)
                {
                    string auxiliar = item.Nombre ?? "";
                    Console.Clear();
                    existe = true;
                    Console.WriteLine("Torneo encontrado");
                    Console.WriteLine(item.datostorneo());
                    item.Nombre = "";
                    Console.WriteLine("Ingrese el nombre nuevo del torneo");
                    string nombre = Console.ReadLine() ?? "";
                    while (nombre == "" || Torneos.Any(torneo => torneo.Nombre != null && torneo.Nombre.Equals(nombre.ToLower())))
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
                            Console.WriteLine($"EL torneo llamado {nombre} ya existe");
                            Console.WriteLine("Ingrese el nuevo nombre del torneo");
                            nombre = Console.ReadLine() ?? "";
                        }

                    }
                    Console.WriteLine("Ingrese la cantidad de equipos que va a tener el torneo actualizado");
                    while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad > 22 || capacidad <= 1)
                    {
                        Console.WriteLine("Ingrese un capacidad valida");
                        if (capacidad > 22 || capacidad <= 1)
                        {
                            Console.WriteLine("La capacidad del torneo es de almenos 2 equipos hasta 22 equipos");
                        }
                    }
                    Console.WriteLine("Los datos del nuevos del torneo son:");
                    Console.WriteLine($"Nombre torneo = {nombre}, capacidad de equipos = {capacidad}");
                    Console.WriteLine("Esta seguro de actualizar el torneo?");
                    Console.WriteLine("Ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                    seguro = Console.ReadLine() ?? "";
                    while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                    {
                        Console.WriteLine("Valor invalido");
                        Console.WriteLine("Ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                        seguro = Console.ReadLine() ?? "";
                    }
                    if (seguro == "si")
                    {
                        Console.WriteLine("Torneo actualizado con con exito");
                        item.Nombre = nombre;
                        item.Capacidad = capacidad;
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {
                        item.Nombre = auxiliar;
                        Console.Clear();
                    }
                    break;                                                }
            }
            if (existe == false)
            {
                Console.Clear();
                Console.WriteLine("No exise ningun torneo registrado con ese nombre");
                Console.WriteLine("Presione enter para continuar");
                Console.ReadKey(); 
            }
        }
    }
}