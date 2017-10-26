using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        static string mensaje = "La nacionalidad no coincide con el numero de dni.";

        public NacionalidadInvalidaException() : base(mensaje)
        {

        }

        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {

        }
    }
}
