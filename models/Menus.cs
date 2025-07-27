using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Liga_Fut.models
{
    public class Menus
    {
        public int MenuPrincipal()
        {
            int salida = 0;
            Console.WriteLine(MenuPrin);
            do
            {
                if (!int.TryParse(Console.ReadLine(), out salida))
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Console.WriteLine(MenuPrin);
                }
                if (salida == 9)
                {
                    Console.WriteLine("Saliendo del de la liga...");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
            while (salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 5 && salida != 9);
            return salida;
        }
        public int MenuTorneo()
        {
            int salida = 0;
            Console.WriteLine(MenuPrin);
            do
            {
                if (!int.TryParse(Console.ReadLine(), out salida))
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Console.WriteLine(MenuPrin);
                }
                if (salida == 9)
                {
                    Console.WriteLine("Volviendo al Menu Principal...");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
            while (salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 9);
            return salida;
        }

        private string MenuPrin = """
╔════════════════════════════════════╗
║    M E N Ú   P R I N C I P A L     ║
╠════════════════════════════════════╣
║  1. Crear Torneo                   ║
║  2. Registro de Equipos            ║
║  3. Registro de Jugadores          ║
║  4. Transferencias                 ║
║  5. Estadísticas                   ║
║  9. Salir                          ║
╚════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
""";
        private string Menutor = """
╔════════════════════════════════════╗
║         M E N Ú   TORNEO           ║
╠════════════════════════════════════╣
║  1. Agregar Torneo                 ║
║  2. Buscar Torneo                  ║
║  3. Eliminar Torneo                ║
║  4. Actualizar Torneo              ║
║  9. Volver al Menu Principal       ║
╚════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
""";
    }
}