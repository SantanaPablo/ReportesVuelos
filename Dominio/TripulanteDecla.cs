using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteVueloFramework
{
    public class TripulanteDecla : Tripulante
    {
        public TripulanteDecla(string tipo, string legajo, string operacion, string rol, string nombre) : base(tipo, legajo, operacion, rol, nombre)
        {
        }

        public DateTime fechaNacimiento { get; set; }
        public string dni { get; set; }

        public string nacionalidad { get; set; }

    }
}
