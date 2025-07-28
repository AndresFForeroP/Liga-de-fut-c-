using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Liga_Fut.models;
using Liga_Fut.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<Torneo> Torneos = new HashSet<Torneo>();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Menus menus = new Menus();
        ServiciosTorneo serviciosTorneo = new ServiciosTorneo();
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
                                int id = serviciosTorneo.generarIdUnico(Torneos);
                                string nombre = serviciosTorneo.validarNombre(Torneos);
                                int capacidad = serviciosTorneo.validadCapacidad();
                                string seguro = serviciosTorneo.validarCreacion(id, nombre, capacidad);
                                if (seguro == "si")
                                {
                                    Torneo nuevo_torneo = new Torneo(id, nombre, capacidad);
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
                                    Console.WriteLine("Elegiste Buscar Torneo");
                                    MenuBuscarTorneo = menus.MenuBuscarTorneo();
                                    switch (MenuBuscarTorneo)
                                    {
                                        case 1:
                                            serviciosTorneo.buscarPorID(Torneos);
                                            break;
                                        case 2:
                                            serviciosTorneo.buscarPorNombre(Torneos);
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
                                    Console.WriteLine("Elegiste Eliminar Torneo");
                                    MenuBuscarTorneo = menus.MenuBuscarTorneo();
                                    switch (MenuBuscarTorneo)
                                    {
                                        case 1:
                                            serviciosTorneo.eliminarPorId(Torneos);
                                            break;
                                        case 2:
                                            serviciosTorneo.eliminarPorNombre(Torneos);
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
                                    Console.WriteLine("Elegiste Actualizar Torneo");
                                    MenuBuscarTorneo = menus.MenuBuscarTorneo();
                                    switch (MenuBuscarTorneo)
                                    {
                                        case 1:
                                            serviciosTorneo.actualizarPorId(Torneos);
                                            break;
                                        case 2:
                                            serviciosTorneo.actualizarPorNombre(Torneos);
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