using System;
namespace Presentacion1.modelo
{
	public class Entrenador:Usuario
    {
		private int edad;

        public Entrenador()
		{
			edad = 0;
		}

		public int EDAD{
			get{
				return edad;
			}
			set{
				edad = value;
			}
		}
    }
}
