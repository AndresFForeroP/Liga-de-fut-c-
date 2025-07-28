using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_Fut.models
{
    public class MenusJugador
    {
        public int MenuPrincipal()
        {
            Console.Clear();
            int salida = 0;
            do
            {
                Console.WriteLine(MenuJugadores);
                if (!int.TryParse(Console.ReadLine(), out salida) || salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 9)
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                if (salida == 9)
                {
                    Console.WriteLine("Volviendo al menu principal...");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
            while (salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 9);
            return salida;
        }
        private string MenuJugadores = """
╔════════════════════════════════════╗
║        M E N Ú   JUGADORES         ║
╠════════════════════════════════════╣
║  1. Registrar Jugador              ║
║  2. Buscar Jugador                 ║
║  3. Editar Jugador                 ║
║  4. Eliminar Jugador               ║
║  9. Volver al Menu Principal       ║
╚════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
""";
    }
}