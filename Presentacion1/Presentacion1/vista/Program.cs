using System;
using System.Collections.Generic;
using Presentacion1.modelo;
using Presentacion1.logica;


namespace Presentacion1
{
    class MainClass
    {
		public static String mostrarMenu(){
			Console.WriteLine("1.Alta usuario");
			Console.WriteLine("2.Baja usuario");
			Console.WriteLine("3.Modificar usuario");
			Console.WriteLine("4.Listado usuarios");
			Console.WriteLine("5.Salir");
			Console.WriteLine("Opción?");
			return Console.ReadLine();

		}
		protected static void Main(string[] args)
        {
			List<DevolverUsuario> tDevolverUsuarios = new List<DevolverUsuario>();

			string op;
			do
			{
				Console.Clear();
				op = mostrarMenu();
				switch (op)
				{					
    				case "1":
						try
						{

							
							Console.WriteLine("(E) entrenador, (J) jugador");
							String tipo = Console.ReadLine();
							if (tipo.Equals("E"))
							{
								Entrenador entrenador = new Entrenador();
								Console.WriteLine("Into nombre:");
								entrenador.Nombre = Console.ReadLine();
								Console.WriteLine("Intro edad");
								entrenador.EDAD=Convert.ToInt32(Console.ReadLine());
								LogicaUsuario.ejecutarInsert(entrenador);
								Console.WriteLine("usuario Nº {0} insetado corectamente", entrenador.Nombre);
							}
							else if(tipo.Equals("J"))
							{
								Jugador jugador = new Jugador();
								Console.WriteLine("Into nombre:");
                                jugador.Nombre = Console.ReadLine();
                                Console.WriteLine("Intro posición");
								jugador.POS = Console.ReadLine();                        
								LogicaUsuario.ejecutarInsert(jugador);
								Console.WriteLine("usuario Nº {0} insertado corectamente", jugador.Nombre);
							}
                                                     

							Console.WriteLine("Pulsa tecla para continuar");
                            Console.ReadKey();
						}catch{
							Console.WriteLine("ERROR");
						}
						break;
					case "2":
						Usuario usuario = new Usuario();
						do
                        {
                            Console.WriteLine("Intro id:");
                            usuario.ID = Convert.ToInt32(Console.ReadLine());
                        } while (!LogicaUsuario.existeUsuario(usuario));
                        LogicaUsuario.ejecutarDelete(usuario);
                        Console.WriteLine(String.Format("usuario Nº {0} borrado corectamente", usuario.ID));
                        Console.WriteLine("Pulsa tecla para continuar");
                        Console.ReadKey();
                        break;
					case "3":
						Usuario usu = new Usuario();
						do
                        {
                            Console.WriteLine("Intro id:");
                            usu.ID = Convert.ToInt32(Console.ReadLine());
                        } while (!LogicaUsuario.existeUsuario(usu));
						Console.WriteLine("Intro nombre");
						usu.Nombre = Console.ReadLine();
                        LogicaUsuario.ejecutarUpdate(usu);
						Console.WriteLine(String.Format("usuario Nº {0} actualizado corectamente", usu.ID));
                        Console.WriteLine("Pulsa tecla para continuar");
                        Console.ReadKey();
						break;
					case "4":
						LogicaDevolverUsuario logicaDevolverUsuario = new LogicaDevolverUsuario();
						logicaDevolverUsuario.ejecutarselect();

						foreach (DevolverUsuario value in logicaDevolverUsuario.Usuarios){


									
							if (value.Edad != 0)
							{
								LogicaEntrenador logicaEntrenador = new LogicaEntrenador();
								logicaEntrenador.ejecutarSelect();
								foreach (Entrenador value1 in logicaEntrenador.Entrenadores)
								{
									Console.WriteLine("----------------------------");
									Console.WriteLine("-Entrenador nº{0}:         -", value1.ID);
                                    Console.WriteLine("----------------------------");
                                    Console.WriteLine("Nombre: {0}", value1.Nombre);
									Console.WriteLine("La Edad del Entrenador: {0}", value1.EDAD);
								}
							}
							else{
								LogicaJugador logicaJugador = new LogicaJugador();
                                logicaJugador.ejecutarSelect();
								foreach (Jugador value2 in logicaJugador.Jugadores)
                                {
                                    Console.WriteLine("----------------------------");
                                    Console.WriteLine("-Jugador nº{0}:         -", value2.ID);
                                    Console.WriteLine("----------------------------");
                                    Console.WriteLine("Nombre: {0}", value2.Nombre);
									Console.WriteLine("La Posición del Jugador es: {0}", value2.POS);
                                }
							}
	
						}
						
                        Console.WriteLine("Pulsa tecla para continuar");
                        Console.ReadKey();
						break;
					case "5":
						Console.WriteLine("Saliendo ...");
						break;
					default:
						Console.WriteLine("Opción Incorrecta");
						break;

				}
			} while(!op.Equals("5"));
        }
    }
}
