using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteVueloFramework
{
    public class Vuelo
    {
        public string CodigoVuelo { get; set; }
        public string FechaVuelo { get; set; }
        public string Origen { get; set; }
        public string HoraSalida { get; set; }
        public string Destino { get; set; }
        public string HoraLlegada { get; set; }
        public string Matricula { get; set; }
        public List<Tripulante> Tripulacion { get; set; }

        public Vuelo()
        {
            Tripulacion = new List<Tripulante>();
        }

        public override string ToString()
        {
            return $"{CodigoVuelo} {FechaVuelo} {Origen} {HoraSalida} {Destino} {HoraLlegada} {Matricula}";
        }
    }
}
