using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Liga_Fut.models
{
    public class MenusTorneo
    {
        public int MenuPrincipal()
        {
            Console.Clear();
            int salida = 0;
            do
            {
                Console.WriteLine(MenuPrin);
                if (!int.TryParse(Console.ReadLine(), out salida) || salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 5 && salida != 9)
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Thread.Sleep(2000);
                    Console.Clear();
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
            Console.Clear();
            int salida = 0;
            do
            {
                Console.WriteLine(Menutor);
                if (!int.TryParse(Console.ReadLine(), out salida) || salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 9)
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                if (salida == 9)
                {
                    Console.WriteLine("Volviendo al Menu Principal...");
                    Thread.Sleep(2000);
                    Console.Clear();

                }
            }
            while (salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 9);
            return salida;
        }
        public int MenuBuscarTorneo()
        {
            Console.Clear();
            int salida = 0;
            do
            {
                Console.WriteLine(MenuBuscarTor);
                if (!int.TryParse(Console.ReadLine(), out salida) || salida != 1 && salida != 2)
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            while (salida != 1 && salida != 2);
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
        private string MenuBuscarTor = """
╔════════════════════════════════════╗
║         BUSCAR  TORNEO             ║
╠════════════════════════════════════╣
║  1. Buscar Por Id                  ║
║  2. Buscar Por nombre              ║
╚════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
""";
    }
}