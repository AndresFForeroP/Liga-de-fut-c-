using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_Fut.models
{
    public class Jugador : Persona
    {
        public int Dorsal { get; set; }
        public string? Posicion { get; set; }

        public Jugador(int id, string nombre, int edad, string origen, string email)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Origen = origen;
            Email = email;
        }
        public Jugador() { }
        public String datosjugador()
        {
            return $"{Nombre} ({Posicion}) - Dorsal: {Dorsal}, Origen: {Origen}, Email: {Email}";
        }
    }
}