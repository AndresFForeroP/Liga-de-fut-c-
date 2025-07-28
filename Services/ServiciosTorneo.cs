using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_Fut.models;

namespace Liga_Fut.Services
{
    public class ServiciosTorneo
    {
        public int generarIdUnico(HashSet<Torneo> Torneos)
        {
            Random random = new Random();
            int id = random.Next(1, 100000);
            foreach (var item in Torneos)
            {
                if (item.Id == id)
                {
                    id = random.Next(1, 9999);
                }
            }
            return id;
        }
        public string validarNombre(HashSet<Torneo> Torneos)
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
            if (Torneos.Count > 0)
            {
                while (Torneos.Any(torneo => torneo.Nombre != null && torneo.Nombre.Equals(nombre.ToLower())) || nombre == "")
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
        public int validadCapacidad()
        {
            int capacidad = 0;
            Console.WriteLine("ingrese la cantidad de equipos que va a tener el torneo");
            while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad > 22 || capacidad <= 1)
            {
                Console.WriteLine("ingrese un capacidad valida");
                if (capacidad > 22 || capacidad <= 1)
                {
                    Console.WriteLine("la capacidad del torneo es de almenos 2 equipos hasta 22 equipos");
                }
            }
            Console.Clear();
            return capacidad;
        }
        public string validarCreacion(int id, string nombre, int capacidad)
        {
            Console.WriteLine("los datos del torneo son:");
            Console.WriteLine($"El id generad0 fue #{id}");
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
                    Console.WriteLine("esta seguro de eliminar el torneo?");
                    Console.WriteLine("ingrese si para eliminar el torneo o no si desea volver");
                    seguro = Console.ReadLine() ?? "";
                    while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                    {
                        Console.WriteLine("Valor invalido");
                        Console.WriteLine("ingrese si para eliminar el torneo o no si desea volver");
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
                    Console.WriteLine("esta seguro de eliminar el torneo?");
                    Console.WriteLine("ingrese si para eliminar el torneo o no si desea volver");
                    seguro = Console.ReadLine() ?? "";
                    while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                    {
                        Console.WriteLine("Valor invalido");
                        Console.WriteLine("ingrese si para eliminar el torneo o no si desea volver");
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
                Console.WriteLine("ingrese un id de torneo valida");
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
                    Console.WriteLine("ingrese la cantidad de equipos que va a tener el torneo actualizado");
                    while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad > 22 || capacidad <= 1)
                    {
                        Console.WriteLine("ingrese un capacidad valida");
                        if (capacidad > 22 || capacidad <= 1)
                        {
                            Console.WriteLine("la capacidad del torneo es de almenos 2 equipos hasta 22 equipos");
                        }
                    }
                    Console.WriteLine("los datos del nuevos del torneo son:");
                    Console.WriteLine($"nombre torneo = {nombre}, capacidad de equipos = {capacidad}");
                    Console.WriteLine("esta seguro de actualizar el torneo?");
                    Console.WriteLine("ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                    seguro = Console.ReadLine() ?? "";
                    while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                    {
                        Console.WriteLine("Valor invalido");
                        Console.WriteLine("ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
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
                    Console.WriteLine("ingrese la cantidad de equipos que va a tener el torneo actualizado");
                    while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad > 22 || capacidad <= 1)
                    {
                        Console.WriteLine("ingrese un capacidad valida");
                        if (capacidad > 22 || capacidad <= 1)
                        {
                            Console.WriteLine("la capacidad del torneo es de almenos 2 equipos hasta 22 equipos");
                        }
                    }
                    Console.WriteLine("los datos del nuevos del torneo son:");
                    Console.WriteLine($"nombre torneo = {nombre}, capacidad de equipos = {capacidad}");
                    Console.WriteLine("esta seguro de actualizar el torneo?");
                    Console.WriteLine("ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                    seguro = Console.ReadLine() ?? "";
                    while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                    {
                        Console.WriteLine("Valor invalido");
                        Console.WriteLine("ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
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