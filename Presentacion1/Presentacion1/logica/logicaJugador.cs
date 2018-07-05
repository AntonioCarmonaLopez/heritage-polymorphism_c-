using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Presentacion1.modelo;


namespace Presentacion1.logica
{
    public class LogicaJugador : LogicaUsuario
    {
		private List<Jugador> tJugadores;

        public LogicaJugador()
        {
            tJugadores = new List<Jugador>();
        }

        public List<Jugador> Jugadores { get { return tJugadores; } set { tJugadores = value; } }

        public override void ejecutarSelect()
        {
			String qwery = "SELECT id,nombre,posicion FROM usuarios WHERE posicion<> ''";
            MySqlCommand cmd = null;
            MySqlDataReader resultados;
            Conexion con = new Conexion();

            cmd = new MySqlCommand(qwery, con.conectar());

            // Ejecuta la consulta
            resultados = cmd.ExecuteReader();
            while (resultados.Read())
            {
				Jugador jugador = new Jugador();
                jugador.ID = resultados.GetInt32(0);
				jugador.Nombre = resultados.GetString(1);
				jugador.POS = resultados.IsDBNull(2) ? null : resultados.GetString("posicion");
				tJugadores.Add(jugador);
            }

        }
        

    }
}