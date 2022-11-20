﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Biblioteca_de_clases
{
    public static class Connection
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static Connection()
        {
            connectionString = @"Data Source = .;
                                 Database = DB_UTN;
                                 Trusted_Connection = True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

        }


        //======================================  ALUMNO  ===========================================================
        public static List<Alumno> SelectAlumnos()
        {
            List<Alumno> alumnoList = new List<Alumno>();
            try
            {
                command.CommandText = "SELECT [ID], [NOMBRE], [APELLIDO] FROM Alumnos ";
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Alumno alumno = new Alumno(reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString());
                    Alumno alumno = new Alumno();
                    alumnoList.Add(alumno);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return alumnoList;
        }

        public static int InsertAlumno()
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "INSERT INTO dbo.Alumnos(NOMBRE, APELLIDO, ESTA_ACTIVO) VALUES(@nombre, @apellido, @esta_activo)";

                string nombreAleatorio = "STRING NOMBRE";
                string apellidoAleatorio = "STRING APELLIDO";
                command.Parameters.AddWithValue("@nombre", nombreAleatorio);
                command.Parameters.AddWithValue("@apellido", apellidoAleatorio);
                command.Parameters.AddWithValue("@esta_activo", 1);

                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return filas;
        }


        public static int DeleteAlumnos()
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "DELETE FROM Alumnos";

                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return filas;

        }
    
        //Obtiene los datos de acceso para validar login
        public static usuarioUTN ObtenerDatosAccesoUsuario(string user)
        {
            usuarioUTN usuario = new usuarioUTN();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[USUARIO] ,[PASSWORD] FROM [DB_UTN].[dbo].[USUARIOS] WHERE [USUARIO] = @user; ";
                connection.Open();

                command.Parameters.AddWithValue("@user", user);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usuario = new usuarioUTN(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["USUARIO"].ToString(), reader["PASSWORD"].ToString());
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return usuario;
        }


        //Retorna una BindingList<string> con los nombres de los usuarios
        public static BindingList<string> ObtenerNombresAlumnos()
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [NOMBRE] FROM [DB_UTN].[dbo].[USUARIOS] WHERE [TIPO_USUARIO] = 2; ";
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["NOMBRE"].ToString());
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return list;
        }


        //Retorna una BindingList<string> con los nombres de los profesores
        public static BindingList<string> ObtenerNombresProfesores()
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [NOMBRE] FROM [DB_UTN].[dbo].[USUARIOS] WHERE [TIPO_USUARIO] = 1; ";
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["NOMBRE"].ToString());
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return list;
        }

        //Crea un nuevo usuario y lo inserta en la DB
        public static void CrearNuevoUsuario(int tipoUsuario, string usuario, string password, string nombre, string telefono, string email)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO[DB_UTN].[dbo].[USUARIOS](TIPO_USUARIO, USUARIO, PASSWORD, NOMBRE, TELEFONO, EMAIL)" +
                "VALUES(@tipoUsuario, @userNuevoUsuario, @passNuevoUsuario, @nombreNuevoUsuario, @telefonoNuevoUsuario, @emailNuevoUsuario);";
               
                connection.Open();


                command.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                command.Parameters.AddWithValue("@userNuevoUsuario", usuario);
                command.Parameters.AddWithValue("@passNuevoUsuario", password);
                command.Parameters.AddWithValue("@nombreNuevoUsuario", nombre);
                command.Parameters.AddWithValue("@telefonoNuevoUsuario", telefono);
                command.Parameters.AddWithValue("@emailNuevoUsuario", email);


                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        
        
        public static int SeleccionarIDMateriasAlumnosCursando(int idAlumno, int idMateria)
        {
            int id = -1;

            try
            {
                command.CommandText = "SELECT  Materias_cursando_alumno.ID " +
                    "FROM  Materias_cursando_alumno " +
                    "LEFT JOIN dbo.USUARIOS ON USUARIOS.ID = Materias_cursando_alumno.ID_ALUMNO " +
                    "LEFT JOIN dbo.MATERIAS ON MATERIAS.ID = Materias_cursando_alumno.ID_MATERIA " +
                    "WHERE  1 = 1 " +
                    "AND USUARIOS.ID = @idUsuario " +
                    "AND MATERIAS.ID = @idMateria;";


                connection.Open();

                command.Parameters.AddWithValue("@idUsuario", idAlumno);
                command.Parameters.AddWithValue("@idMateria", idMateria);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = int.Parse(reader["ID"].ToString());
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return id;
        }


        public static Profesor BuscarProfesorPorNombre(string nombre)
        {
            Profesor user = new Profesor();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[NOMBRE] ,[USUARIO] ,[PASSWORD]" +
                    " FROM [DB_UTN].[dbo].USUARIOS" +
                    " WHERE [NOMBRE] = @nombre;";
                command.Parameters.AddWithValue("@nombre", nombre);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    user = new Profesor(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["USUARIO"].ToString(), reader["PASSWORD"].ToString());

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return user;
        }


        public static Alumno BuscarAlumnoPorNombre(string nombre)
        {
            Alumno user = new Alumno();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[NOMBRE] ,[USUARIO] ,[PASSWORD]" +
                    " FROM [DB_UTN].[dbo].USUARIOS" +
                    " WHERE [NOMBRE] = @nombre;";
                command.Parameters.AddWithValue("@nombre", nombre);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new Alumno(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["NOMBRE"].ToString(), reader["USUARIO"].ToString(), reader["PASSWORD"].ToString());

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return user;
        }


        public static Alumno BuscarAlumnoPorUser(string user)
        {
            Alumno alumno = new Alumno();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[NOMBRE] ,[USUARIO] ,[PASSWORD]" +
                    " FROM [DB_UTN].[dbo].USUARIOS" +
                    " WHERE [USUARIO] = @user;";
                command.Parameters.AddWithValue("@user", user);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    alumno = new Alumno(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["USUARIO"].ToString(), reader["PASSWORD"].ToString());

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return alumno;
        }


        public static Profesor BuscarProfesorPorUser(string user)
        {
            Profesor profesor = new Profesor();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[NOMBRE] ,[USUARIO] ,[PASSWORD]" +
                    " FROM [DB_UTN].[dbo].USUARIOS" +
                    " WHERE [USUARIO] = @user;";
                command.Parameters.AddWithValue("@user", user);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    profesor = new Profesor(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["USUARIO"].ToString(), reader["PASSWORD"].ToString());

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return profesor;
        }


        public static Materia BuscarMateriaPorNombre(string nombre)
        {
            Materia materia = new Materia();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[NOMBRE] ,[CUATRIMESTRE] " +
                    "FROM[DB_UTN].[dbo].[MATERIAS] " +
                    "WHERE[NOMBRE] = @nombre; ";
                command.Parameters.AddWithValue("@nombre", nombre);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    materia = new Materia(int.Parse(reader["ID"].ToString()), reader["NOMBRE"].ToString(), int.Parse(reader["CUATRIMESTRE"].ToString()));

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return materia;
        }


        public static int ObtenerEstadoMateria(int id)
        {
            int estado = -1;
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT[ESTADO] FROM[DB_UTN].[dbo].[Materias_cursando_alumno] WHERE ID = @idRelacion; ";
                command.Parameters.AddWithValue("@idRelacion", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    estado = int.Parse(reader["ESTADO"].ToString());

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return estado;
        }


        public static void CambiarEstadoMateria(int idRelacion, int nuevoEstado)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "UPDATE[DB_UTN].[dbo].[Materias_cursando_alumno]" +
                    " SET ESTADO = @nuevoEstado" +
                    " WHERE ID = @idRelacion;";

                command.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);
                command.Parameters.AddWithValue("@idRelacion", idRelacion);

                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public static BindingList<string> ObtenerListadoDeMateriasCursandoDeAlumnoSeleccionado(int id)
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT [MATERIAS].NOMBRE " +
                    "FROM dbo.Materias_cursando_alumno " +
                    "LEFT JOIN dbo.USUARIOS " +
                    "ON USUARIOS.ID = Materias_cursando_alumno.ID_ALUMNO " +
                    "LEFT JOIN dbo.MATERIAS " +
                    "ON MATERIAS.ID = Materias_cursando_alumno.ID_MATERIA " +
                    "WHERE USUARIOS.ID = @id;";

                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return list;
        }

        //Crea una nueva materia y la inserta en la DB
        public static void CrearNuevaMateria(string nombre, int cuatrimestre)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO dbo.MATERIAS (NOMBRE, CUATRIMESTRE) " +
                    "VALUES (@nombre, @cuatrimestre);";

                connection.Open();


                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@cuatrimestre", cuatrimestre);



                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        //Carga en la DB las materias correlativas de una materia
        public static void CargarMateriasCorrelativas(int idMateria, List<string> materiasCorrelativas)
        {
            int filas = 0;

            try
            {
                Materia materiaCorrelativaSeleccionada = new Materia();
                connection.Open();

                foreach (string materiaCorrelativa in materiasCorrelativas)
                {
                    materiaCorrelativaSeleccionada = Connection.BuscarMateriaPorNombre(materiaCorrelativa);
                    command.Parameters.Clear();

                    command.CommandText = "INSERT INTO dbo.Materias_correlativas_materia (ID_MATERIA, ID_MATERIA_CORRELATIVA) " +
                        "VALUES (@idMateria, @idMateriaCorrelativa);";
                    command.Parameters.AddWithValue("@idMateria", idMateria);
                    command.Parameters.AddWithValue("@idMateriaCorrelativa", materiaCorrelativaSeleccionada.Id);

                    filas = command.ExecuteNonQuery();
                }

                
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        
        public static BindingList<string> BuscarMateriasCorrelativasDeMateria(int idMateria)
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT ID_MATERIA_CORRELATIVA FROM Materias_correlativas_materia " +
                    "LEFT JOIN MATERIAS " +
                    "ON Materias_correlativas_materia.ID_MATERIA = MATERIAS.ID " +
                    "WHERE MATERIAS.ID = @idMateria;";


                connection.Open();

                command.Parameters.AddWithValue("@idMateria", idMateria);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return list;
        }
        
        //Retorna un listado de materias del cuatrimestre indicado por parametro.
        public static BindingList<string> CrearListadoDeMateriasPorCuatrimestre(int cuatrimestre)
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [NOMBRE] FROM MATERIAS " +
                    "WHERE CUATRIMESTRE = @cuatrimestre;";


                connection.Open();

                command.Parameters.AddWithValue("@cuatrimestre", cuatrimestre);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["NOMBRE"].ToString());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return list;
        }


        public static void AsignarProfesorAMateria(int idProfesor, int idMateria)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO dbo.Materias_dictando_profesor (ID_PROFESOR, ID_MATERIA) " +
                    "VALUES (@idProfesor, @idMateria);";

                connection.Open();


                command.Parameters.AddWithValue("@idProfesor", idProfesor);
                command.Parameters.AddWithValue("@idMateria", idMateria);

                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public static void AsignarAlumnoAMateria(int idAlumno, int idMateria)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [DB_UTN].[dbo].[Materias_cursando_alumno] (ID_ALUMNO, ID_MATERIA) " +
                    "VALUES (@idAlumno, @idMateria);";

                connection.Open();


                command.Parameters.AddWithValue("@idAlumno", idAlumno);
                command.Parameters.AddWithValue("@idMateria", idMateria);

                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public static BindingList<string> ObtenerListadoProfesores()
        {
            BindingList<string> list = new BindingList<string>();

            int filas;

            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = "SELECT [NOMBRE] FROM dbo.USUARIOS WHERE TIPO_USUARIO = 1;";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["NOMBRE"].ToString());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return list;
        }


        public static BindingList<string> ObtenerListadoDeMateriasDictandoDeProfesorSeleccionado(int idProfesor)
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT [MATERIAS].NOMBRE " +
                    "FROM dbo.Materias_dictando_profesor " +
                    "LEFT JOIN dbo.USUARIOS " +
                    "ON USUARIOS.ID = dbo.Materias_dictando_profesor.ID_PROFESOR " +
                    "LEFT JOIN dbo.MATERIAS " +
                    "ON MATERIAS.ID = dbo.Materias_dictando_profesor.ID_MATERIA " +
                    "WHERE USUARIOS.ID = @idProfesor;";

                command.Parameters.AddWithValue("@idProfesor", idProfesor);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return list;
        }



        public static BindingList<string> ObtenerListadoDeMateriasAprobadasDeAlumnoSeleccionado(int idAlumno)
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT [MATERIAS].NOMBRE " +
                    "FROM dbo.Materias_aprobadas_alumno " +
                    "LEFT JOIN dbo.USUARIOS " +
                    "ON USUARIOS.ID = Materias_aprobadas_alumno.ID_ALUMNO " +
                    "LEFT JOIN dbo.MATERIAS " +
                    "ON MATERIAS.ID = Materias_aprobadas_alumno.ID_MATERIA " +
                    "WHERE USUARIOS.ID = @idAlumno;";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return list;
        }
    
    
        public static BindingList<string> ObtenerListadoExamenesDeMateriaSeleccionada(int idMateria)
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT EXAMENES.NOMBRE " +
                    "FROM EXAMENES " +
                    "LEFT JOIN MATERIAS " +
                    "ON EXAMENES.ID_MATERIA = MATERIAS.ID " +
                    "WHERE MATERIAS.ID = @idMateria;";

                command.Parameters.AddWithValue("@idMateria", idMateria);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return list;
        }




        public static Examen BuscarExamenPorNombre(string nombre)
        {
            Examen examen = new Examen();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT ID, NOMBRE, FECHA, NOTA, ID_MATERIA " +
                    "FROM EXAMENES  " +
                    "WHERE[NOMBRE] = @nombre;";
                command.Parameters.AddWithValue("@nombre", nombre);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    examen = new Examen(int.Parse(reader["ID"].ToString()), reader["NOTA"].ToString(), reader["FECHA"].ToString() ,float.Parse(reader["NOTA"].ToString()), int.Parse(reader["ID"].ToString()));

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return examen;
        }

        public static BindingList<string> ObtenerListadoDeNombresDeAlumnosQueCursanLaMateria(int idMateria)
        {
            BindingList<string> list = new BindingList<string>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT USUARIOS.NOMBRE " +
                    "FROM dbo.Materias_cursando_alumno " +
                    "LEFT JOIN dbo.USUARIOS " +
                    "ON USUARIOS.ID = Materias_cursando_alumno.ID_ALUMNO " +
                    "LEFT JOIN dbo.MATERIAS " +
                    "ON MATERIAS.ID = Materias_cursando_alumno.ID_MATERIA " +
                    "WHERE MATERIAS.ID = @idMateria;";

                command.Parameters.AddWithValue("@idMateria", idMateria);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return list;


        }



        public static List<Alumno> ObtenerListadoDeAlumnosQueCursanLaMateria(int idMateria)
        {
            List<Alumno> list = new List<Alumno>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT USUARIOS.TIPO_USUARIO, USUARIOS.USUARIO, USUARIOS.PASSWORD," +
                    " USUARIOS.NOMBRE, USUARIOS.TELEFONO, USUARIOS.EMAIL" +
                    " FROM dbo.Materias_cursando_alumno" +
                    " LEFT JOIN dbo.USUARIOS" +
                    " ON USUARIOS.ID = Materias_cursando_alumno.ID_ALUMNO" +
                    " LEFT JOIN dbo.MATERIAS" +
                    " ON MATERIAS.ID = Materias_cursando_alumno.ID_MATERIA" +
                    " WHERE MATERIAS.ID = @idMateria;";

                command.Parameters.AddWithValue("@idMateria", idMateria);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Alumno alumno = new Alumno(int.Parse(reader[0].ToString()), reader[1].ToString(),
                        reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                    list.Add(alumno);
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return list;


        }


        public static void CargarNotaAAlumno(int idAlumno, int idMateria, float nota)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "INSERT INTO dbo.Materias_nota_alumno (ID_ALUMNO, ID_MATERIA, NOTA) " +
                    "VALUES (@idAlumno, @idMateria, @nota);";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);
                command.Parameters.AddWithValue("@idMateria", idMateria);
                command.Parameters.AddWithValue("@nota", nota);

                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }


        public static void CrearNuevoExamen(string nombre, string fecha, int idMateria)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO EXAMENES (NOMBRE, FECHA, ID_MATERIA) " +
                    "VALUES (@nombre, @fecha, @idMateria);";

                connection.Open();


                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@idMateria", idMateria);



                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static BindingList<string> ListarMateriasTotales()
        {
            List<string> list = new List<string>();

            list.AddRange(Connection.CrearListadoDeMateriasPorCuatrimestre(1));
            list.AddRange(Connection.CrearListadoDeMateriasPorCuatrimestre(2));
            list.AddRange(Connection.CrearListadoDeMateriasPorCuatrimestre(3));
            list.AddRange(Connection.CrearListadoDeMateriasPorCuatrimestre(4));

            return new BindingList<string>(list);
        }
    }
}
