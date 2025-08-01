using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_Fut.models
{
    public class Torneo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Capacidad { get; set; }
        public string? Pais { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafinal { get; set; }
        public HashSet<Equipo> EquiposRegistrados = new HashSet<Equipo>();
        public Torneo(int id, string nombre, int capacidad)
        {
            Id = id;
            Nombre = nombre;
            Capacidad = capacidad;
        }
        public String datostorneo()
        {
            return $"Id Torneo #{Id}-- Nombre: {Nombre}, Capacidad: {Capacidad} equipos";
        }
    }
}