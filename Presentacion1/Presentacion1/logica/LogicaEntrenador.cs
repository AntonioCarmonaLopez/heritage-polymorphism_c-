using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Presentacion1.modelo;


namespace Presentacion1.logica
{
	public class LogicaEntrenador : LogicaUsuario
	{
		private List<Entrenador> tEntrenadores;

		public LogicaEntrenador()
		{
			tEntrenadores = new List<Entrenador>();
		}

		public List<Entrenador> Entrenadores { get { return tEntrenadores; } set { tEntrenadores = value; } }

		public override void ejecutarSelect()
		{
			String qwery = "SELECT id,nombre,edad FROM usuarios WHERE edad <>''";
			MySqlCommand cmd = null;
			MySqlDataReader resultados;
			Conexion con = new Conexion();

			cmd = new MySqlCommand(qwery, con.conectar());

			// Ejecuta la consulta
			resultados = cmd.ExecuteReader();
			while (resultados.Read())
			{
				Entrenador entrenador = new Entrenador();
				entrenador.ID=resultados.GetInt32(0);
				entrenador.Nombre = resultados.GetString(1);
				entrenador.EDAD = resultados.GetInt32(2);
				tEntrenadores.Add(entrenador);
			}

		}


	}
}