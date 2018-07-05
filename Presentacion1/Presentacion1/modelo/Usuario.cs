using System;
namespace Presentacion1.modelo
{
    public class Usuario
    {
		protected int id;
		protected String nombre;

		public Usuario()
		{
			nombre = null;
		}
		public int ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}
		public String Nombre
		{
			get
			{
				return nombre;
			}
			set
			{
				nombre = value;
			}
		}
	}
}
