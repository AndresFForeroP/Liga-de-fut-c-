using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Liga_Fut.Helpers;
using Liga_Fut.models;
using Liga_Fut.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<Torneo> Torneos = new HashSet<Torneo>();
        HashSet<Equipo> Equipos = new HashSet<Equipo>();
        HashSet<Jugador> Jugadores = new HashSet<Jugador>();
        Console.ForegroundColor = ConsoleColor.Magenta;
        MenusTorneo menusdetorneos = new MenusTorneo();
        MenusJugador menusdejugadores = new MenusJugador();
        ServiciosTorneo serviciosTorneo = new ServiciosTorneo();
        ServiciosEquipo serviciosEquipo = new ServiciosEquipo();
        ServiciosJugador serviciosJugador = new ServiciosJugador();
        HelperLiga helperGeneral = new HelperLiga();
        int menuprincipal = 0;
        do
        {
            menuprincipal = menusdetorneos.MenuPrincipal();
            switch (menuprincipal)
            {
                case 1:
                    int menutorneo = 0;
                    Console.Clear();
                    Console.WriteLine("Elegiste crear torneo ");
                    do
                    {
                        menutorneo = menusdetorneos.MenuTorneo();
                        Console.Clear();
                        int MenuBuscarTorneo = 0;
                        switch (menutorneo)
                        {
                            case 1:
                                int id = helperGeneral.GenerarIdUnico(Torneos,torneo => torneo.Id);
                                string nombre = helperGeneral.validarNombre(Torneos,torneo => torneo.Nombre?? "");
                                int capacidad = helperGeneral.validadCapacidad(22,2,"torneo");
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
                                    MenuBuscarTorneo = menusdetorneos.MenuBuscarTorneo();
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
                                    MenuBuscarTorneo = menusdetorneos.MenuBuscarTorneo();
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
                                    MenuBuscarTorneo = menusdetorneos.MenuBuscarTorneo();
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
                    int menuequipo = 0;
                    Console.Clear();
                    Console.WriteLine("Elegiste Registro Equipo ");
                    do
                    {
                        menuequipo = menusdejugadores.MenuPrincipal();
                        Console.Clear();
                        switch (menuequipo)
                        {
                            case 1:
                                int id = helperGeneral.GenerarIdUnico(Equipos,equipo => equipo.Id);
                                string nombre = helperGeneral.validarNombre(Equipos,equipo => equipo.Nombre?? "");
                                string seguro = serviciosEquipo.validarCreacion(id, nombre);
                                if (seguro == "si")
                                {
                                    Equipo nuevo_equipo = new Equipo(id, nombre);
                                    Console.WriteLine("Equipo creado con exito");
                                    Equipos.Add(nuevo_equipo);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Clear();
                                }
                                foreach (var item in Equipos)
                                {
                                    item.datosequipo();
                                    Console.ReadKey();
                                }
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                        }
                    } while (menuequipo != 9);
                    break;
                case 3:
                    int menujugador = 0;
                    Console.Clear();
                    Console.WriteLine("Elegiste Registro Jugador ");
                    do
                    {
                        menujugador = menusdejugadores.MenuPrincipal();
                        Console.Clear();
                        switch (menujugador)
                        {
                            case 1:
                                //pendiente agregar atributos necesarios para agregar un jugador
                                int id = helperGeneral.GenerarIdUnico(Jugadores,Jugador => Jugador.Id);
                                string nombre = helperGeneral.validarNombre(Jugadores,Jugador => Jugador.Nombre?? "");
                                string seguro = serviciosJugador.validarCreacion(id, nombre);
                                if (seguro == "si")
                                {
                                    Jugador nuevoJugador = new Jugador();
                                    Console.WriteLine("Jugador creado con exito");
                                    Jugadores.Add(nuevoJugador);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Clear();
                                }
                                foreach (var item in Jugadores)
                                {
                                    item.datosjugador();
                                }
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                        }
                    } while (menujugador != 9);
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