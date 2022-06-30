using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAuto.Models
{
    public class AlumnoM
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string curp { get; set; }
        public decimal sueldo { get; set; }
        public string idestadoorigen { get; set; }
        public string idEstatus { get; set; }

    }
}