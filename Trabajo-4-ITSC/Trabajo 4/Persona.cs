using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_4
{
    public class Persona
    {
        public int edad { get; set; }

        public string apellido { get; set; }

        public string nombre { get; set; }

        public int Id { get; set; }

        public bool Validar()
        {
            bool resp = false;

            if (edad > 0 )
            {
                resp = true;
            }
            return resp;
        }

    }
}
