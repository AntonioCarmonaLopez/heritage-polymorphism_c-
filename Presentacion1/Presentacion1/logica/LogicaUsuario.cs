using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Presentacion1.modelo;

namespace Presentacion1.logica
{
	public abstract class LogicaUsuario
	{
		public abstract void ejecutarSelect();

		public static bool existeUsuario(Usuario u)
        {
            String qwery = "SELECT *FROM usuarios WHERE id=@id";
            MySqlCommand cmd = null;
            MySqlDataReader resultados;
            Conexion con = new Conexion();

            cmd = new MySqlCommand(qwery, con.conectar());
            //añadir parámetros
            cmd.Parameters.AddWithValue("@id", u.ID);

            // Ejecuta la consulta
            resultados = cmd.ExecuteReader();
            if (resultados.HasRows)
                return true;
            con.desconectar();
            return false;
        }

        public static DevolverUsuario getUsuario(Usuario u)
        {
            String qwery = "SELECT *FROM usuarios WHERE id=@id";
            MySqlCommand cmd = null;
            MySqlDataReader resultados;
            Conexion con = new Conexion();
            DevolverUsuario devolverUsuario = new DevolverUsuario();

            cmd = new MySqlCommand(qwery, con.conectar());
            //añadir parámetros
            cmd.Parameters.AddWithValue("@id", u.ID);

            // Ejecuta la consulta
            resultados = cmd.ExecuteReader();
            while (resultados.Read())
            {
                devolverUsuario.Id = resultados.GetInt32(0);
                devolverUsuario.Nombre = resultados.GetString(1);
                devolverUsuario.Edad = resultados.GetInt32(2);
                devolverUsuario.Posicion = resultados.GetString(3);
                return devolverUsuario;
            }
            return null;

        }

        public static void ejecutarInsert(Usuario u)
        {

            MySqlCommand cmd = null;
            MySqlDataReader resultados;
            Conexion con = new Conexion();
            if (u is Entrenador)
            {
                String qwery = "INSERT INTO usuarios(nombre,edad) values(@nombre,@edad)";
                try
                {

                    cmd = new MySqlCommand(qwery, con.conectar());
                    //añadir parámetros
                    cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                    cmd.Parameters.AddWithValue("@edad", ((Entrenador)u).EDAD);
                    // Ejecuta la consulta
                    resultados = cmd.ExecuteReader();

                }
                catch (Exception e)
                {
                    throw new Exception("Método ejecutar insert", e);
                }
                finally
                {
                    con.desconectar();
                }
            }
            else if (u is Jugador)
            {
                String qwery = "INSERT INTO usuarios(nombre,posicion) values(@nombre,@posicion)";
                try
                {

                    cmd = new MySqlCommand(qwery, con.conectar());
                    //añadir parámetros
                    cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                    cmd.Parameters.AddWithValue("@posicion", ((Jugador)u).POS);
                    // Ejecuta la consulta
                    resultados = cmd.ExecuteReader();

                }
                catch (Exception e)
                {
                    throw new Exception("Método ejecutar insert", e);
                }
                finally
                {
                    con.desconectar();
                }
            }
        }

        public static void ejecutarUpdate(Usuario u)
        {

            MySqlCommand cmd = null;
            MySqlDataReader resultados;
            Conexion con = new Conexion();
            if (u is Entrenador)
            {
                String qwery = "UPDATE usuarios SET nombre=@nombre,edad=@edad WHERE id=@id";

                try
                {

                    cmd = new MySqlCommand(qwery, con.conectar());
                    //añadir parámetros
                    cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                    cmd.Parameters.AddWithValue("@edad", ((Entrenador)u).EDAD);
                    // Ejecuta la consulta
                    resultados = cmd.ExecuteReader();

                }
                catch (Exception e)
                {
                    throw new Exception("Método ejecutar update", e);
                }
                finally
                {
                    con.desconectar();
                }
            }
            else if (u is Jugador)
            {
                String qwery = "UPDATE usuarios SET nombre=@nombre,posicion=@posicion WHERE id=@id";

                try
                {

                    cmd = new MySqlCommand(qwery, con.conectar());
                    //añadir parámetros
                    cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                    cmd.Parameters.AddWithValue("@posicion", ((Jugador)u).POS);
                    // Ejecuta la consulta
                    resultados = cmd.ExecuteReader();

                }
                catch (Exception e)
                {
                    throw new Exception("Método ejecutar update", e);
                }
                finally
                {
                    con.desconectar();
                }
            }
        }



        public static void ejecutarDelete(Usuario u)
        {
            String qwery = "DELETE FROM usuarios WHERE id=@id";
            MySqlCommand cmd = null;
            MySqlDataReader resultados;
            Conexion con = new Conexion();

            try
            {

                cmd = new MySqlCommand(qwery, con.conectar());
                //añadir parámetros
                cmd.Parameters.AddWithValue("@id", u.ID);


                // Ejecuta la consulta
                resultados = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                throw new Exception("Método ejecutar delete", e);
            }
            finally
            {
                con.desconectar();
            }
        }   

	}
}
