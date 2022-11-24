using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Biblioteca_de_clases
{
    public class Archivo<T> where T : usuarioUTN, IGestionUsuarios 
    {
        private string path;

        public Archivo(string path)
        {
            this.path = path;
        }

        //================ GUARDADO DE ARCHIVOS ========================


        public bool GuardarArchivoCSV(List<T> listado, bool append)
        {
            bool respuesta;
            var sw = new StreamWriter(path, append);

            try
            {
                foreach(T item in listado)
                {

                    sw.Write(item.Id + ",");
                    sw.Write(item.Nombre + ",");
                    sw.Write(item.Email + ",");
                    sw.Write(item.Password + ",");
                    sw.Write("\n");
                }

                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            finally
            {
                sw.Close();
                sw.Dispose();

            }

            return respuesta;
        }

        public bool GuardarArchivoCSV(List<T> listado)
        {
            return GuardarArchivoCSV(listado, false);
        }



        public bool GuardarArchivoJSON(List<T> listado, bool append)
        {
            bool respuesta;
            var sw = new StreamWriter(path, append);
            string jsonString; 
            try
            {
                foreach(T item in listado)
                {
                    jsonString = JsonSerializer.Serialize(item);
                    sw.Write(jsonString + "\n");
                }
                
                
                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            finally
            {
                sw.Close();
                sw.Dispose();

            }

            return respuesta;
        }

        public bool GuardarArchivoJSON(List<T> listado)
        {
            return GuardarArchivoJSON(listado, false);
        }


    }
}
