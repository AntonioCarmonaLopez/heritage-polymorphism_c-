using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Presentacion1.modelo;

namespace Presentacion1.logica
{
    public class LogicaDevolverUsuario
    {
		private List<DevolverUsuario> tUsuarios;

		public LogicaDevolverUsuario()
        {
			tUsuarios = new List<DevolverUsuario>();
        }

		public List<DevolverUsuario> Usuarios { get { return tUsuarios; } set { tUsuarios = value; } }

        public  void ejecutarselect()
        {

            String qwery = "SELECT *FROM usuarios";
            MySqlCommand cmd = null;
            MySqlDataReader resultados;
            Conexion con = new Conexion();

            cmd = new MySqlCommand(qwery, con.conectar());

            // Ejecuta la consulta
            resultados = cmd.ExecuteReader();
            while (resultados.Read())
            {
				DevolverUsuario devolverUsuario= new DevolverUsuario();
				devolverUsuario.Id = resultados.GetInt32(0);
				devolverUsuario.Nombre = resultados.GetString(1);
				devolverUsuario.Edad = resultados.GetInt32(2)==0?0 : resultados.GetInt32(2);
				devolverUsuario.Posicion = resultados.IsDBNull(3) ? null : resultados.GetString(3);
				tUsuarios.Add(devolverUsuario);
            }

        }

    }
}
