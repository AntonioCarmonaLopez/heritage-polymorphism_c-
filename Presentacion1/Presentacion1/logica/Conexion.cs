using System;
using MySql.Data.MySqlClient;

namespace Presentacion1.logica
{
    public class Conexion
    {
		//atributos
		private MySqlConnection con;
		private String servidor = "localhost";
		private String puerto = "3306";
		private String user = "root";
        private String pass = "root";
		private String database = "test";

		public MySqlConnection CON
        {
            get
            {
                return con;
            }
        }

		public MySqlConnection conectar()
        {
            con = new MySqlConnection();
            con.ConnectionString = string.Format("server={0}; port={1}; user id ={2}; password ={3}; database ={4}", servidor, puerto, user, pass, database);

            con = new MySqlConnection(con.ConnectionString);
			try{
            con.Open();
				return con;
			}catch(Exception e){
				return null;
				throw new Exception("Método conectar", e);            
			}     
        }  

		public void desconectar(){
			try
			{
				con.Close();
			}catch(Exception e)
			{
				throw new Exception("Cerrar conexión", e);
			}
			
		}
	}
}
