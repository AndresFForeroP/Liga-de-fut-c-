using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_Fut.Services
{
    public class ServiciosEquipo
    {
        public string validarCreacion(int id, string nombre)
        {
            Console.WriteLine("Los datos del equipo son:");
            Console.WriteLine($"El id generado fue #{id}");
            Console.WriteLine($"Nombre de equipo: {nombre}");
            Console.WriteLine("Esta seguro de agreagar el equipo?");
            Console.WriteLine("Ingrese si para agregar el equipo o no si desea volver a ingresar los datos");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Ingrese si para agregar el equipo o no si desea volver a ingresar los datos");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro;
        }
    }
}