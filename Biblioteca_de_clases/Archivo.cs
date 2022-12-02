using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Dynamic;
using System.Reflection.PortableExecutable;

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
                jsonString = System.Text.Json.JsonSerializer.Serialize(listado);
                sw.Write(jsonString);

                
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


        public List<Alumno> LeerArchivoJson()
        {

            string objetoJson = File.ReadAllText(path);
            List<Alumno> list = System.Text.Json.JsonSerializer.Deserialize<List<Alumno>>(objetoJson);

            return list;
        }


    }


}
