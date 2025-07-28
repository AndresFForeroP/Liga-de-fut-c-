using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Liga_Fut.models;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<Torneo> Torneos = new HashSet<Torneo>();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Menus menus = new Menus();
        bool existe = false;
        int menuprincipal = 0;
        do
        {
            menuprincipal = menus.MenuPrincipal();
            switch (menuprincipal)
            {
                case 1:
                    int menutorneo = 0;
                    Console.Clear();
                    Console.WriteLine("Elegiste crear torneo ");
                    do
                    {
                        menutorneo = menus.MenuTorneo();
                        Console.Clear();
                        int MenuBuscarTorneo = 0;
                        switch (menutorneo)
                        {
                            case 1:
                                Random random = new Random();          
                                int id = random.Next(1, 100000);
                                foreach (var item in Torneos)
                                {
                                    if (item.Id == id)
                                    {
                                        id = random.Next(1, 9999);
                                    }
                                }
                                string nombre = "";
                                int capacidad = 0;
                                string seguro = "";
                                Console.WriteLine("Ingrese el nombre del torneo");
                                nombre = Console.ReadLine() ?? "";
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
                                Torneo nuevo_torneo = new Torneo(id, nombre, capacidad);
                                Console.WriteLine("los datos del torneo son:");
                                Console.WriteLine(nuevo_torneo.datostorneo());
                                Console.WriteLine("esta seguro de agreagar el torneo?");
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
                                    Console.WriteLine("Torneo agregado con exito");
                                    Torneos.Add(nuevo_torneo);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                else
                                {
                                    menutorneo = 1;
                                    Console.Clear();
                                }
                                break;
                            case 2:
                                if (Torneos.Count == 0)
                                {
                                    Console.WriteLine("No hay torneos registrados");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    existe = false;
                                    Console.WriteLine("Elegiste Buscar Torneo");
                                    MenuBuscarTorneo = menus.MenuBuscarTorneo();
                                    switch (MenuBuscarTorneo)
                                    {
                                        case 1:
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
                                                    Console.Read();
                                                }
                                            }
                                            if (existe == false)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("No exise ningun torneo registrado con ese id");
                                                Console.WriteLine("Presione enter para continuar");
                                                Console.Read();
                                            }
                                            break;
                                        case 2:
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
                                                    Console.Read();
                                                }
                                            }
                                            if (existe == false)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("No exise ningun torneo registrado con ese nombre");
                                                Console.WriteLine("Presione enter para continuar");
                                                Console.Read();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case 3:
                                if (Torneos.Count == 0)
                                {
                                    Console.WriteLine("No hay torneos registrados");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    existe = false;
                                    Console.WriteLine("Elegiste Eliminar Torneo");
                                    MenuBuscarTorneo = menus.MenuBuscarTorneo();
                                    switch (MenuBuscarTorneo)
                                    {
                                        case 1:
                                            int idbusqueda = 0;
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
                                                Console.Read();
                                            }
                                            break;
                                        case 2:
                                            Console.Clear();
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
                                                Console.Read();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case 4:
                                if (Torneos.Count == 0)
                                {
                                    Console.WriteLine("No hay torneos registrados");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    existe = false;
                                    Console.WriteLine("Elegiste Actualizar Torneo");
                                    MenuBuscarTorneo = menus.MenuBuscarTorneo();
                                    switch (MenuBuscarTorneo)
                                    {
                                        case 1:
                                            int idbusqueda = 0;
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
                                                    nombre = Console.ReadLine() ?? "";
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
                                                        menutorneo = 1;
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
                                                Console.Read();
                                            }
                                            break;
                                        case 2:
                                            string nombrebusqueda = "";
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
                                                    nombre = Console.ReadLine() ?? "";
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
                                                        menutorneo = 1;
                                                        Console.Clear();
                                                    }
                                                    break;                                                }
                                            }
                                            if (existe == false)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("No exise ningun torneo registrado con ese nombre");
                                                Console.WriteLine("Presione enter para continuar");
                                                Console.Read();
                                            }
                                            break;
                                    }
                                    
                                }
                                break;
                        }
                    } while (menutorneo != 9);
                    break;
                case 2:
                    
                    break;
                case 3:
                    Console.WriteLine("Elegiste ");
                    break;
                case 4:
                    Console.WriteLine("Elegiste ");
                    break;
                case 5:
                    Console.WriteLine("Elegiste ");
                    break;
            }
        } while (menuprincipal != 9);
    }
}