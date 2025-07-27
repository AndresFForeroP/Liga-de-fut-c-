using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_Fut.models
{
    public class Persona
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public string? Origen { get; set; }
        public string? Email { get; set; }

        public Persona(int id, string nombre, int edad, string origen, string email)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Origen = origen;
            Email = email;
        }
        public Persona(){}
    }
}