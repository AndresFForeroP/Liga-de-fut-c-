using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_Fut.models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public HashSet<Jugador> jugadores = new HashSet<Jugador>();

        public Equipo(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public Equipo()
        {

        }
        public String datosequipo()
        {
            return $"Id Equipo #{Id}-- Nombre: {Nombre}";
        }
    }
}