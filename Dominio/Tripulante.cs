using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteVueloFramework
{
    public class Tripulante
    {



        public string Tipo { get; set; }         // F o C
        public string Legajo { get; set; }          // Número de legajo
        public string Operacion { get; set; }    // OP
        public string Rol { get; set; }          // CP, FO, CM, AX
        public string Nombre { get; set; }       // Nombre completo

        public Tripulante(string tipo, string legajo, string operacion, string rol, string nombre)
        {
            Tipo = tipo;
            Legajo = legajo;
            Operacion = operacion;
            Rol = rol;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"{Tipo} {Legajo} {Operacion} {Rol} {Nombre}";
        }
    }
}
