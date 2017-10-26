using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private Enacionalidad _nacionalidad;
        private string _nombre;

        public enum Enacionalidad
        {
            Argentino, Extranjero
        }

        //public string Apellido
        //{
        //    get
        //    {
        //        return this.Apellido;
        //    }
        //    set
        //    {
        //        this._apellido = this.ValidarNombreApellido(value);
        //    }
        //}
        //public int DNI
        //{
        //    get
        //    {
        //        return this._dni;
        //    }
        //    set
        //    {
        //        this._dni = this.ValidarDNI(this._nacionalidad, value);
        //    }
        //}
        //public Enacionalidad Nacionalidad
        //{
        //    get
        //    {
        //        return this._nacionalidad;
        //    }
        //    set
        //    {
        //        this._nacionalidad = value;
        //    }
        //}
        //public string Nombre
        //{
        //    get
        //    {
        //        return this._nombre;
        //    }
        //    set
        //    {
        //        this._nombre = this.ValidarNombreApellido(value);
        //    }
        //}
        //public string StringToDNI
        //{
        //    set
        //    {
        //        this._dni = int.Parse(value);
        //    }
        //}
        //public Persona()
        //{
        //    this._apellido = "Sin apellido";
        //    this._dni = 0;
        //    this._nacionalidad = Enacionalidad.Argentino;
        //    this._nombre = "Sin nombre";
        //}
        //public Persona(string nombre, string apellido, Enacionalidad nacionalidad) : this()
        //{
        //    this._nombre = nombre;
        //    this._apellido = apellido;
        //    this._nacionalidad = nacionalidad;
        //}
        //public Persona(string nombre, string apellido, int dni, Enacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        //{
        //    this._dni = dni;
        //}
        //public Persona(string nombre, string apellido, string dni, Enacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        //{
        //    this.StringToDNI = dni;
        //}
        //private int ValidarDNI(Enacionalidad nacionalidad, int dato)
        //{
        //    //if (this._nacionalidad == Enacionalidad.Argentino)
        //    //{
        //    //    if (dato < 1 || dato > 89999999)
        //    //    {
        //    //        throw new DniInvalidoException();
        //    //    }
        //    //    else
        //    //    {
        //    //        return dato;
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    throw new NacionalidadInvalidaException();
        //    //}
        //    if (dato > 0 && dato < 89999999)
        //    {
        //        if (nacionalidad == Enacionalidad.Argentino)
        //        {
        //            return dato;
        //        }
        //        else
        //        {
        //            throw new NacionalidadInvalidaException();
        //        }
        //    }
        //    else
        //    {
        //        if (nacionalidad == Enacionalidad.Argentino)
        //        {
        //            throw new NacionalidadInvalidaException();
        //        }
        //        else
        //        {
        //            return dato;
        //        }
        //    }
        //}
        //private int ValidarDNI(Enacionalidad nacionalidad, string dato)
        //{
        //    //return this.ValidarDNI(nacionalidad, int.Parse(dato));
        //    int resultado = 0;
        //    if (int.TryParse(dato, out resultado))
        //    {
        //        return this.ValidarDNI(nacionalidad, resultado);
        //    }
        //    else
        //    {
        //        throw new DniInvalidoException("El dni contiene letras.");
        //    }
        //}
        //private string ValidarNombreApellido(string dato)
        //{
        //    for (int i = 0; i < dato.Length; i++)
        //    {
        //        if (char.IsDigit(dato[i]) == true || char.IsSymbol(dato[i]) == true)
        //        {
        //            return "";
        //        }
        //    }
        //    return dato;
        //}
        //public override string ToString()
        //{
        //    return "NOMBRE COMPLETO: " + this.Apellido + " " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad + "\n";
        //}
        public int DNI
        {
            get { return this._dni; }
            set
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }

        }

        public string Apellido { get { return this._apellido; } set { this._apellido = value; } }
        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    this._nombre = value;

            }
        }
        public Enacionalidad Nacionalidad { get { return this._nacionalidad; } set { this._nacionalidad = value; } }
        public string StringToDNI { set { this._dni = ValidarDni(this.Nacionalidad, value); } }

        public Persona()
        {
            this.Apellido = "Sin apellido";
            this._nacionalidad = Enacionalidad.Extranjero;
            this.DNI = -1;
            this.Nombre = "Sin nombre";
        }

        public Persona(string nombre, string apellido, Enacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, Enacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, Enacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Apellido + " " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad.ToString() + "\n";
        }

        private int ValidarDni(Enacionalidad nacionalidad, int dato)
        {
            if (dato > 0 && dato < 89999999)
            {
                if (nacionalidad == Enacionalidad.Argentino)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else
            {
                if (nacionalidad == Enacionalidad.Argentino)
                {
                    throw new NacionalidadInvalidaException();
                }
                else
                {
                    return dato;
                }
            }

        }
        private int ValidarDni(Enacionalidad nacionalidad, string dato)
        {
            int resultado = 0;
            if (int.TryParse(dato, out resultado))
            {
                return this.ValidarDni(nacionalidad, resultado);
            }
            else
            {
                throw new DniInvalidoException("El dni contiene letras.");
            }

        }

        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato[i]))
                {
                    return null;
                }
            }
            return dato;
        }
    }
}
