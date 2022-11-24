using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Biblioteca_de_clases
{
    public static class ConnectionDao
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static ConnectionDao()
        {
            connectionString = @"Data Source = .;
                                 Database = DB_UTN;
                                 Trusted_Connection = True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

        }

        //============================================================= CREAR =================================================================
        public static int CrearNuevoUsuario(int tipoUsuario, string nombre, string email, string password)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO[DB_UTN].[dbo].[USUARIOS](TIPO_USUARIO, NOMBRE, EMAIL, PASSWORD)" +
                "VALUES(@tipoUsuario, @nombreNuevoUsuario, @emailNuevoUsuario, @passNuevoUsuario);";

                connection.Open();


                command.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                command.Parameters.AddWithValue("@nombreNuevoUsuario", nombre);
                command.Parameters.AddWithValue("@emailNuevoUsuario", email);
                command.Parameters.AddWithValue("@passNuevoUsuario", password);

                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la creacion de un nuevo usuario");
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
                throw new Exception("Ha habido un error en la creacion de una nueva materia");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public static void CargarMateriasCorrelativas(int idMateria, List<int> idsMateriasCorrelativas)
        {
            int filas = 0;

            try
            {
                Materia materiaCorrelativaSeleccionada = new Materia();
                connection.Open();

                foreach(int idMateriaCorrelativa in idsMateriasCorrelativas)
                {
                    command.Parameters.Clear();

                    command.CommandText = "INSERT INTO dbo.Materias_correlativas_materia (ID_MATERIA, ID_MATERIA_CORRELATIVA) " +
                        "VALUES (@idMateria, @idMateriaCorrelativa);";
                    command.Parameters.AddWithValue("@idMateria", idMateria);
                    command.Parameters.AddWithValue("@idMateriaCorrelativa", idMateriaCorrelativa);

                    filas = command.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la carga de materias correlativas");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        } //Carga las materias correlativas en la nueva materia.
        public static void CrearNuevoExamen(int idMateria, string nombre, DateTime fecha)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO EXAMENES (ID_MATERIA, NOMBRE, FECHA)" +
                    "VALUES (@idMateria, @nombre, @fecha);";

                connection.Open();

                command.Parameters.AddWithValue("@idMateria", idMateria);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@fecha", fecha);




                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la creacion de un nuevo examen");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }





        //====================================================== OBTENCION DE DATOS =============================================================
        public static usuarioUTN ObtenerDatosAccesoUsuario(string email)
        {
            usuarioUTN usuario = new usuarioUTN();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO], [NOMBRE] ,[EMAIL] ,[PASSWORD] FROM [DB_UTN].[dbo].[USUARIOS] WHERE [EMAIL] = @email; ";
                connection.Open();

                command.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usuario = new usuarioUTN(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["NOMBRE"].ToString(), reader["EMAIL"].ToString(), reader["PASSWORD"].ToString());
                }

            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en carga de datos de acceso");
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
                throw new Exception("Ha habido un error");
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
                throw new Exception("Ha habido un error en la obtencion del estado de la materia");
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
        public static int ObtenerEstadoMateria(int idAlumno, int idMateria)
        {
            int estado = -1;

            try
            {
                command.CommandText = "SELECT [ESTADO] FROM[DB_UTN].[dbo].[Materias_cursando_alumno] " +
                    "WHERE ID_ALUMNO = idAlumno AND ID_MATERIA = idMateria;";


                connection.Open();

                command.Parameters.AddWithValue("@idAlumno", idAlumno);
                command.Parameters.AddWithValue("@idMateria", idMateria);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    estado = int.Parse(reader["ESTADO"].ToString());
                }


            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error");
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

        public static bool ValidarProfesorDictaMateria(int idProfesor, int idMateria)
        {
            bool respuesta = false;
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[ID_PROFESOR] ,[ID_MATERIA] FROM [DB_UTN].[dbo].[Materias_dictando_profesor]" +
                    " WHERE ID_PROFESOR = @idProfesor AND ID_MATERIA = @idMateria;";
                
                command.Parameters.AddWithValue("@idProfesor", idProfesor);
                command.Parameters.AddWithValue("@idMateria", idMateria);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    respuesta = true;
                    break;

                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion del estado de la materia");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return respuesta;
        }
        public static int ObtenerUltimoIdMateria()
        {
            int ultimoId = -1;
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT TOP (1) [ID]" +
                    " FROM [DB_UTN].[dbo].[MATERIAS]" +
                    " ORDER BY ID DESC;";

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ultimoId = int.Parse(reader["ID"].ToString());
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion del estado de la materia");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return ultimoId;
        }

        public static bool ValidarNoHayAsistenciasAMateriaEnFechaSeleccionada(int idAlumno, int idMateria, DateTime asistenciaActual)
        {
            bool respuesta = true;
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT ID ,ID_ALUMNO ,ID_MATERIA ,FECHA " +
                    "FROM Materias_asistencia_alumno " +
                    "WHERE ID_ALUMNO = @idAlumno AND ID_MATERIA = @idMateria;";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);
                command.Parameters.AddWithValue("@idMateria", idMateria);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (asistenciaActual.ToString() == reader["FECHA"].ToString())
                    {
                        respuesta = false;
                        break;
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion del estado de la materia");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return respuesta;
        }

        public static int ObtenerCantidadDeMateriasQueCursaAlumno(int idAlumno)
        {
            int count = -1;
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT COUNT(ID)" +
                    " FROM Materias_cursando_alumno" +
                    " WHERE ID_ALUMNO = @idAlumno;";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    count = int.Parse(reader[0].ToString());
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion del conteo de materias cursando");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return count;

        }


        public static int ObtenerCantidadDeExamenesQueTieneMateria(int idMateria)
        {
            int count = -1;
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT COUNT(ID)" +
                    " FROM EXAMENES" +
                    " WHERE ID_MATERIA = @idMateria;";
                
                command.Parameters.AddWithValue("@idMateria", idMateria);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    count = int.Parse(reader[0].ToString());
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion del conteo de materias cursando");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return count;

        }














        //========================================================================================================================================
        //============================================================= BUSQUEDA =================================================================
        //========================================================================================================================================

        public static Profesor BuscarProfesorPorId(int id)
        {
            Profesor profesor = new Profesor();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[NOMBRE] ,[EMAIL] ,[PASSWORD]" +
                    " FROM [DB_UTN].[dbo].USUARIOS" +
                    " WHERE [ID] = @id;";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    profesor = new Profesor(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["NOMBRE"].ToString(), reader["EMAIL"].ToString(), reader["PASSWORD"].ToString());

                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la busqueda de profesor");
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
                throw new Exception("Ha habido un error en la busqueda de alumno");
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
        public static Alumno BuscarAlumnoPorId(int id)
        {
            Alumno user = new Alumno();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[NOMBRE] ,[EMAIL] ,[PASSWORD]" +
                    " FROM [DB_UTN].[dbo].USUARIOS" +
                    " WHERE [ID] = @id;";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new Alumno(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["NOMBRE"].ToString(), reader["EMAIL"].ToString(), reader["PASSWORD"].ToString());

                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la busqueda de alumno");
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
                throw new Exception("Ha habido un error en la busqueda de materia");
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
        public static Materia BuscarMateriaPorId(int id)
        {
            Materia materia = new Materia();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[NOMBRE] ,[CUATRIMESTRE] " +
                    "FROM[DB_UTN].[dbo].[MATERIAS] " +
                    "WHERE[ID] = @id; ";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    materia = new Materia(int.Parse(reader["ID"].ToString()), reader["NOMBRE"].ToString(), int.Parse(reader["CUATRIMESTRE"].ToString()));

                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la busqueda de materia");
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
        public static Examen BuscarExamenPorId(int idExamen)
        {
            Examen examen = new Examen();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT ID, NOMBRE, FECHA, ID_MATERIA " +
                    "FROM EXAMENES  " +
                    "WHERE[ID] = @idExamen;";
                command.Parameters.AddWithValue("@idExamen", idExamen);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    examen = new Examen(int.Parse(reader["ID"].ToString()), reader["NOMBRE"].ToString(), DateTime.Parse(reader["FECHA"].ToString()), int.Parse(reader["ID_MATERIA"].ToString()));

                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la busqueda de examen");
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





        //====================================================== OBTENCION DE LISTADOS =============================================================

        public static List<Alumno> ObtenerListadoDeAlumnos()
        {
            List<Alumno> list = new List<Alumno>();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[NOMBRE] ,[EMAIL] ,[PASSWORD]" + "" +
                    " FROM [DB_UTN].[dbo].USUARIOS WHERE TIPO_USUARIO = 2";
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Alumno(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["NOMBRE"].ToString(), reader["EMAIL"].ToString(), reader["PASSWORD"].ToString()));
                }

            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de nombres de alumnos");
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
        public static List<Profesor> ObtenerListadoDeProfesores()
        {
            List<Profesor> list = new List<Profesor>();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [ID] ,[TIPO_USUARIO] ,[NOMBRE] ,[EMAIL] ,[PASSWORD]" + "" +
                    " FROM [DB_UTN].[dbo].USUARIOS WHERE TIPO_USUARIO = 1";
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Profesor(int.Parse(reader["ID"].ToString()), int.Parse(reader["TIPO_USUARIO"].ToString()), reader["NOMBRE"].ToString(), reader["EMAIL"].ToString(), reader["PASSWORD"].ToString()));
                }

            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de nombres de alumnos");
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

        public static List<Materia> ObtenerListadoDeMaterias()
        {
            List<Materia> listadoMaterias = new List<Materia>();
            try
            {
                listadoMaterias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(1));
                listadoMaterias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(2));
                listadoMaterias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(3));
                listadoMaterias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(4));
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de alumnos que cursan la materia seleccionada");
            }

            return listadoMaterias;
        }

        public static List<Materia> ObtenerListadoDeMateriasPorCuatrimestre(int cuatrimestre)
        {
            List<Materia> list = new List<Materia>();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT ID, NOMBRE, CUATRIMESTRE FROM MATERIAS " +
                    "WHERE CUATRIMESTRE = @cuatrimestre;";


                connection.Open();

                command.Parameters.AddWithValue("@cuatrimestre", cuatrimestre);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Materia(int.Parse(reader["ID"].ToString()), reader["NOMBRE"].ToString(), int.Parse(reader["CUATRIMESTRE"].ToString())));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de materias por cuatrimestre");
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

        public static List<Materia> ObtenerListadoDeMateriasCursandoDelAlumno(int idAlumno)
        {
            List<Materia> list = new List<Materia>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT MATERIAS.ID, MATERIAS.NOMBRE, MATERIAS.CUATRIMESTRE " +
                    "FROM Materias_cursando_alumno " +
                    "LEFT JOIN USUARIOS " +
                    "ON USUARIOS.ID = Materias_cursando_alumno.ID_ALUMNO " +
                    "LEFT JOIN MATERIAS " +
                    "ON MATERIAS.ID = Materias_cursando_alumno.ID_MATERIA " +
                    "WHERE USUARIOS.ID = @idAlumno;";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Materia(int.Parse(reader["ID"].ToString()), reader["NOMBRE"].ToString(), int.Parse(reader["CUATRIMESTRE"].ToString())));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de materias cursando de alumno");
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


        public static List<Materia> ObtenerListadoDeMateriasAprobadasDelAlumno(int idAlumno)
        {
            List<Materia> list = new List<Materia>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT MATERIAS.ID, MATERIAS.NOMBRE, MATERIAS.CUATRIMESTRE" +
                    " FROM dbo.Materias_aprobadas_alumno" +
                    " LEFT JOIN dbo.USUARIOS" +
                    " ON USUARIOS.ID = Materias_aprobadas_alumno.ID_ALUMNO" +
                    " LEFT JOIN dbo.MATERIAS" +
                    " ON MATERIAS.ID = Materias_aprobadas_alumno.ID_MATERIA" +
                    " WHERE USUARIOS.ID = @idAlumno;";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Materia(int.Parse(reader["ID"].ToString()), reader["NOMBRE"].ToString(), int.Parse(reader["CUATRIMESTRE"].ToString())));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de materias cursando de alumno");
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
        
        public static List<string[]> ObtenerInformacionDeMateriasAprobadas(int idAlumno)
        {
            List<string[]> list = new List<string[]>();
            
            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT MATERIAS.NOMBRE ,NOTA_1 ,NOTA_2 ,PROMEDIO " +
                    "FROM Materias_aprobadas_alumno " +
                    "LEFT JOIN MATERIAS " +
                    "ON Materias_aprobadas_alumno.ID_MATERIA = MATERIAS.ID " +
                    "WHERE ID_ALUMNO = @idAlumno;";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string[] fila = new string[4];

                    fila[0] = reader[0].ToString();
                    fila[1] = reader[1].ToString();
                    fila[2] = reader[2].ToString();
                    fila[3] = reader[3].ToString();

                    list.Add(fila);

                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de datos de materias aprobadas");
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

        public static List<string[]> ObtenerInformacionDeMateriasCursando(int idAlumno)
        {
            List<string[]> list = new List<string[]>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT MATERIAS.NOMBRE, ASISTENCIAS, NOTA_1, NOTA_2, ESTADO" +
                    " FROM Materias_cursando_alumno" +
                    " LEFT JOIN MATERIAS" +
                    " ON Materias_cursando_alumno.ID_MATERIA = MATERIAS.ID" +
                    " WHERE ID_ALUMNO = @idAlumno;";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string[] fila = new string[5];

                    fila[0] = reader[0].ToString();
                    fila[1] = reader[1].ToString();
                    fila[2] = reader[2].ToString();
                    fila[3] = reader[3].ToString();
                    fila[4] = reader[4].ToString();

                    list.Add(fila);

                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de materias cursando de alumno");
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

        public static List<int> ObtenerListadoIdsMateriasCorrelativasDeMateria(int idMateria)
        {
            List<int> list = new List<int>();
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
                    list.Add(int.Parse(reader[0].ToString()));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de materias correlativas");
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

        public static List<int> ObtenerListadoIdsMateriasAprobadasDelAlumno(int idAlumno)
        {
            List<int> list = new List<int>();
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [MATERIAS].ID " +
                    "FROM dbo.Materias_aprobadas_alumno " +
                    "LEFT JOIN dbo.USUARIOS " +
                    "ON USUARIOS.ID = Materias_aprobadas_alumno.ID_ALUMNO " +
                    "LEFT JOIN dbo.MATERIAS " +
                    "ON MATERIAS.ID = Materias_aprobadas_alumno.ID_MATERIA " +
                    "WHERE USUARIOS.ID = @idAlumno;";


                connection.Open();

                command.Parameters.AddWithValue("@idAlumno", idAlumno);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(int.Parse(reader[0].ToString()));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de materias correlativas");
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
        public static List<int> ObtenerListadoIdsMateriasCursandoDelAlumno(int idAlumno)
        {
            List<int> list = new List<int>();
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT [MATERIAS].ID " +
                    "FROM dbo.Materias_cursando_alumno " +
                    "LEFT JOIN dbo.USUARIOS " +
                    "ON USUARIOS.ID = Materias_cursando_alumno.ID_ALUMNO " +
                    "LEFT JOIN dbo.MATERIAS " +
                    "ON MATERIAS.ID = Materias_cursando_alumno.ID_MATERIA " +
                    "WHERE USUARIOS.ID = @idAlumno;";


                connection.Open();

                command.Parameters.AddWithValue("@idAlumno", idAlumno);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(int.Parse(reader[0].ToString()));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de materias correlativas");
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
                throw new Exception("Ha habido un error en la obtencion de listado de nombres de alumnos");
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
                throw new Exception("Ha habido un error en la obtencion de listado de nombres de profesores");
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
                throw new Exception("Ha habido un error en la obtencion de listado de materias correlativas");
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

        public static List<Materia> ObtenerListadoDeMateriasDictandoDeProfesorSeleccionado(int idProfesor)
        {
            List<Materia> list = new List<Materia>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT MATERIAS.ID, MATERIAS.NOMBRE, MATERIAS.CUATRIMESTRE" +
                    " FROM dbo.Materias_dictando_profesor" +
                    " LEFT JOIN dbo.USUARIOS" +
                    " ON USUARIOS.ID = Materias_dictando_profesor.ID_PROFESOR" +
                    " LEFT JOIN dbo.MATERIAS" +
                    " ON MATERIAS.ID = Materias_dictando_profesor.ID_MATERIA" +
                    " WHERE USUARIOS.ID = @idProfesor;";

                command.Parameters.AddWithValue("@idProfesor", idProfesor);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Materia(int.Parse(reader["ID"].ToString()), reader["NOMBRE"].ToString(), int.Parse(reader["CUATRIMESTRE"].ToString())));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de materias de profesor");
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
       
        public static List<Examen> ObtenerListadoExamenesDeMateriaSeleccionada(int idMateria)
        {
            List<Examen> list = new List<Examen>();

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "SELECT ID, NOMBRE, FECHA, ID_MATERIA" +
                    " FROM EXAMENES" +
                    " WHERE ID_MATERIA = @idMateria;";

                command.Parameters.AddWithValue("@idMateria", idMateria);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Examen(int.Parse(reader[0].ToString()), reader[1].ToString(), DateTime.Parse(reader[2].ToString()), int.Parse(reader[3].ToString())));
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de examenes de materia seleccionada");
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
                throw new Exception("Ha habido un error en la obtencion de listado de nombres de alumnos que cursan la materia seleccionada");
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


                command.CommandText = "SELECT USUARIOS.ID, USUARIOS.TIPO_USUARIO, USUARIOS.NOMBRE, USUARIOS.EMAIL," +
                    " USUARIOS.PASSWORD" +
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
                    Alumno alumno = new Alumno(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()),
                        reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                    list.Add(alumno);
                }

            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la obtencion de listado de alumnos que cursan la materia seleccionada");
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



        //========================================================================================================================================
        //====================================================== EDICION DE DATOS ================================================================
        //========================================================================================================================================
        public static void CambiarEstadoMateria(int idAlumno, int idMateria, int nuevoEstado)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "UPDATE[DB_UTN].[dbo].[Materias_cursando_alumno]" +
                    " SET ESTADO = @nuevoEstado" +
                    " WHERE ID_ALUMNO = @idAlumno AND ID_MATERIA = @idMateria;";

                
                command.Parameters.AddWithValue("@idAlumno", idAlumno);
                command.Parameters.AddWithValue("@idMateria", idMateria);
                command.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);

                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en el cambio de estado de la materia seleccionada");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

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
                throw new Exception("Ha habido un error en la asignacion del profesor a la materia");
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
                throw new Exception("Ha habido un error en la asignacion del alumno a la materia");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
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
                throw new Exception("Ha habido un error en la carga de nota al alumno");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public static void CargarAsistenciaAlumno(int idAlumno, int idMateria)
        {
            int filas = 0;

            try
            {
                command.Parameters.Clear();
                connection.Open();


                command.CommandText = "INSERT INTO Materias_asistencia_alumno (ID_ALUMNO, ID_MATERIA, FECHA) " +
                    "VALUES (@idAlumno, @idMateria, CAST(GETDATE() AS Date));";

                command.Parameters.AddWithValue("@idAlumno", idAlumno);
                command.Parameters.AddWithValue("@idMateria", idMateria);


                filas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Ha habido un error en la carga de asistencia al alumno");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
