using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Camioneros.Model
{
    public class Camion
    {
            public int id {  get; set; }
            public int id_Camionero { get; set; }
            public string? Marca { get; set; }
            public string? Patente { get; set; }
            public string? Tipo { get; set; }
            public string? Peso { get; set; }
            public string? Peso_Carga { get; set; }
            public string? GPS_Cortacorriente {  get; set; }
    }
}
