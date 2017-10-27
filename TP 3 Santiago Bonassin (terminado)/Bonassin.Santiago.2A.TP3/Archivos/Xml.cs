using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos en un archivo de formato xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo que se va a guardar</param>
        /// <param name="datos">Datos que va a guardar, segun el tipo que se le asigne</param>
        /// <returns>Retorna true si puede guardar el archivo</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + archivo, false))
                {
                    XmlSerializer xmls = new XmlSerializer(typeof(T));
                    xmls.Serialize(sw, datos);

                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee los datos del archivo de tipo xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo que se va a leer</param>
        /// <param name="datos">Datos que van a leer, segun el tipo que se le asigne</param>
        /// <returns>Retorna true si puede leer el archivo</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + archivo, false))
                {
                    XmlSerializer xmls = new XmlSerializer(typeof(T));
                    datos = (T)xmls.Deserialize(sr);
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
