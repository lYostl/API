using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camioneros.Model
{
    public class Camionero
    {
        public int id {  get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string? Genero { get; set; }
        public string? Estado_Civil { get; set; }
        public int Cantidad_Hijo { get; set; }
    }
}
