using System;

namespace Presentacion1.modelo
{
	public class Jugador : Usuario
    {
		private String posicion;

		public String POS{
			get{
				return posicion;
			}
			set{
				posicion = value;
			}
		}
        public Jugador()
        {
        }
    }
}
