using System;
using System.Collections;
namespace TrabajoGrupal
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			empresa ConstruAR = new empresa();
			GrupoObrero grupoObrero = null;
			Console.WriteLine("Bienvenido a Nuestra empresa constructora ConstruAR!! ");
			Console.WriteLine("-------");
			Console.WriteLine("Menu: ");
			Console.WriteLine("Ingrese 1 para: Contratar un obrero nuevo. ");
			Console.WriteLine("Ingrese 2 para: Eliminar un obrero. ");
			Console.WriteLine("Ingrese 3 para: Mostrar la lista de obreros. ");
			Console.WriteLine("Ingrese 4 para: Mostrar la lista de obras. ");
			Console.WriteLine("Ingrese 5 para: Agregar una obra y asignarle un grupo de obreros. ");
			Console.WriteLine("Ingrese 6 para: Modificar el estado de avance de una obra. ");
			Console.WriteLine("Ingrese 7 para: Mostrar la lista de obras finalizadas. ");
			Console.WriteLine("Ingrese fin para: Finalizar con el programa");
			Console.WriteLine("-------");
			string r = Console.ReadLine();
			
			while (r!="fin")
			{
				if (r=="1")
				{

					//Datos Obrero
					Console.WriteLine("Ingrese nombre y apellido: ");
					string nomyape = Console.ReadLine();
					
					Console.WriteLine("Ingrese dni: ");
					int dni = int.Parse(Console.ReadLine());
					
					Console.WriteLine("Ingrese legajo: ");
					int legajo = int.Parse(Console.ReadLine());
					
					Console.WriteLine("Ingrese cargo:");
					string cargo = Console.ReadLine();
					
					Console.WriteLine("Ingrese codigo de obra o 0 si no esta asignado a ninguna");
					int codigo=int.Parse(Console.ReadLine());
					
					obrero nuevoObrero = new obrero(nomyape, dni, legajo, cargo, null);
					
					if (codigo == 0)
					{
						int indiceGrupo = -1;
						for (int i = 0; i < ConstruAR.GruposObreros.Length; i++)
						{
							if (ConstruAR.GruposObreros[i] != null && ConstruAR.GruposObreros[i].CodigoObra == 0)
							{
								indiceGrupo = i;
								break;
							}
						}

						if (indiceGrupo != -1)
						{
							nuevoObrero.ObreroGrupo = ConstruAR.GruposObreros[indiceGrupo];
							ConstruAR.GruposObreros[indiceGrupo].AgregarAlGrupo(nuevoObrero);
							grupoObrero=ConstruAR.GruposObreros[indiceGrupo];
							grupoObrero.AgregarAlGrupo(nuevoObrero);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("El obrero ha sido contratado con éxito.");
							Console.ResetColor();
						}
						else
						{
							grupoObrero = new GrupoObrero(0);
							nuevoObrero.ObreroGrupo = grupoObrero;
							grupoObrero.AgregarAlGrupo(nuevoObrero);
							ConstruAR.agregarGrupoObrero(grupoObrero);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("El obrero ha sido contratado con éxito y agregado a la lista de grupos obreros de la empresa.");
							Console.ResetColor();
						}
					}
					else
					{
						
						for (int i = 0; i < ConstruAR.GruposObreros.Length; i++)
						{
							if (ConstruAR.GruposObreros[i] != null && ConstruAR.GruposObreros[i].CodigoObra == codigo)
							{
								grupoObrero = ConstruAR.GruposObreros[i];
								break;
							}
						}//lo asigno como nulo para que este instanciado

						if (grupoObrero != null)
						{
							nuevoObrero.ObreroGrupo=grupoObrero;
							grupoObrero.AgregarAlGrupo(nuevoObrero);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("El obrero ha sido contratado con éxito.");
							Console.ResetColor();
						}

						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("No se encontró un grupo con el código de obra ingresado.");
							Console.ResetColor();
						}
					}
				}

				else if (r=="2")
				{
					Console.WriteLine("Ingrese el dni del obrero a eliminar. ");
					int dniEliminar = int.Parse(Console.ReadLine());

					int encontrado = -1;
					foreach (GrupoObrero g in ConstruAR.GruposObreros)
					{
						if (g != null)
						{
							int indiceIntegrante = g.ExisteIntegrante(dniEliminar);
							if (indiceIntegrante != -1)
							{
								g.EliminarIntegrante(indiceIntegrante);
								encontrado = 1;
								break;
							}
						}
					}
					if (encontrado==1)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("El obrero ha sido eliminado con éxito.");
						Console.ResetColor();
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("No se encontró un obrero con el DNI ingresado.");
						Console.ResetColor();
					}
				}

				else if (r=="3")
				{
					ConstruAR.mostrarGruposObreros();
				}
				else if (r=="4")
				{
					ConstruAR.mostrarObrasEjecucion();
				}
				else if (r=="5")
				{
					Console.WriteLine("-------");
					Console.WriteLine("Ingrese los datos de la obra ");
					Console.WriteLine("Ingrese nombre del propietario: ");
					string nomPro = Console.ReadLine();
					Console.WriteLine("Ingrese dni del propietario: ");
					int dniPro = int.Parse(Console.ReadLine());
					Console.WriteLine("Ingrese el tipo de obra: ");
					string tipoObra = Console.ReadLine();
					Console.WriteLine("Ingrese el tiempo estimado de ejecución de la obra en días: ");
					int tiempoObra = int.Parse(Console.ReadLine());
					Console.WriteLine("Ingrese el avance de la obra en %porcentaje%:");
					double avanceObra = double.Parse(Console.ReadLine());
					Console.WriteLine("Ingrese el costo de la obra: ");
					int costoObra = int.Parse(Console.ReadLine());

					obra nuevaObra = null;
					try
					{
						nuevaObra = new obra(nomPro, dniPro, tipoObra, tiempoObra, avanceObra, grupoObrero, costoObra);
						int InternalCode = nuevaObra.CodigoInterno;
						grupoObrero = new GrupoObrero(InternalCode);
						if (GrupoObrero.RecuentoGrupos == 8)
						{
							throw new SeExcedioGrupoObrerosException(GrupoObrero.RecuentoGrupos);
						}
					}
					catch (SeExcedioGrupoObrerosException ex)
					{
						Console.WriteLine(ex.Message);
					}
					ConstruAR.agregarObraEnEjecucion(nuevaObra);
					ConstruAR.agregarGrupoObrero(grupoObrero);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("La obra ha sido añadida exitosamente!! ");
					Console.ResetColor();
					Console.WriteLine("-------");
				}
				
				else if (r=="6")
				{
					Console.WriteLine("---------------------");
					ConstruAR.mostrarObrasFinalizadas();
					Console.WriteLine("Ingrese el código de la obra a eliminar: ");
					int cod = int.Parse(Console.ReadLine());
					Console.WriteLine("Ingrese el nuevo avance de la obra: ");
					double avance = int.Parse(Console.ReadLine());
					ConstruAR.ExisteObraEnEjecucion(cod);
					if (cod!=-1 && avance==100)
					{
						ConstruAR.agregarObraFinalizada((obra)ConstruAR.ObrasEjecucion[ConstruAR.ExisteObraEnEjecucion(cod)]);
						ConstruAR.EliminarObraEnEjecucion(cod);
					}
				}
				else if (r=="7")
				{
					ConstruAR.mostrarObrasFinalizadas();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Respuesta Invalida por favor ingrese de nuevo");
					Console.ResetColor();
				}
				Console.WriteLine("-------");
				Console.WriteLine("Menu: ");
				Console.WriteLine("Ingrese 1 para: Contratar un obrero nuevo. ");
				Console.WriteLine("Ingrese 2 para: Eliminar un obrero. ");
				Console.WriteLine("Ingrese 3 para: Mostrar la lista de obreros. ");
				Console.WriteLine("Ingrese 4 para: Mostrar la lista de obras. ");
				Console.WriteLine("Ingrese 5 para: Agregar una obra y asignarle un grupo de obreros. ");
				Console.WriteLine("Ingrese 6 para: Modificar el estado de avance de una obra. ");
				Console.WriteLine("Ingrese 7 para: Mostrar la lista de obras finalizadas. ");
				Console.WriteLine("Ingrese fin para: Finalizar con el programa");
				Console.WriteLine("-------");
				r = Console.ReadLine();
			}
			Console.WriteLine("presione ENTER para continuar");
			Console.Read();
		}
	}
}