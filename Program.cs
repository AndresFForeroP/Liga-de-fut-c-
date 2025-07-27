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
                        switch (menutorneo)
                        {
                            case 1:
                                int id = Torneos.Count + 1;
                                string nombre = "";
                                int capacidad = 0;
                                string seguro = "";
                                Console.WriteLine("Ingrese el nombre del equipo");
                                nombre = Console.ReadLine();
                                if (Torneos.Count > 0)
                                {
                                    while (Torneos.Any(torneo => torneo.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
                                    {
                                        Console.WriteLine("EL nombre del torneo ya esta registrado");
                                        Console.WriteLine("Ingrese el nombre de un torneo que no este registrado");
                                        nombre = Console.ReadLine();
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
                                seguro = Console.ReadLine();
                                while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                                {
                                    Console.WriteLine("Valor invalido");
                                    Console.WriteLine("ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                                    seguro = Console.ReadLine();
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
                        }
                    } while (menutorneo != 9);
                    break;
                case 2:
                    Console.WriteLine("Elegiste Buscar Torneo");
                    
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