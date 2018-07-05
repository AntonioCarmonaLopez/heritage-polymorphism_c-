using System;
namespace Presentacion1.modelo
{
    public class DevolverUsuario
    {
		private int id;
        private String nombre;
		private String posicion;
		private int edad;

		public int Id { get { return id; } set { id = value; } }
		public string Nombre { get { return nombre; } set { nombre = value; } }
		public string Posicion { get { return posicion; } set { posicion = value; } }
		public int Edad { get { return edad; } set { edad = value; } }
	}
}
