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
                        switch (menutorneo)
                        {
                            case 1:
                                int id = 0;
                                string nombre = "";
                                int capacidad = 0;
                                while (!int.TryParse(Console.ReadLine(), out id))
                                {
                                    Console.WriteLine("ingrese un id valido");
                                }
                                while (!int.TryParse(Console.ReadLine(), out capacidad))
                                {
                                    Console.WriteLine("ingrese un id valido");
                                }
                                break;
                        }
                    } while (menutorneo != 9);
                    break;
                case 2:
                    Console.WriteLine("Elegiste ");
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