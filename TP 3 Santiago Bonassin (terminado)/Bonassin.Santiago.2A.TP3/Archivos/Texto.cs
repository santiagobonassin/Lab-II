using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos en un archivo de texto
        /// </summary>
        /// <param name="archivo">Nombre del archivo que se va a guardar</param>
        /// <param name="datos">Datos que va a guardar</param>
        /// <returns>Retorna true si puede guardar el archivo</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + archivo, false))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee los datos de un archivo de texto
        /// </summary>
        /// <param name="archivo">Nombre del archivo que va a leerr</param>
        /// <param name="datos">Datos que va a leer</param>
        /// <returns>Retorna true si puede leer el archivo</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + archivo, false))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
