using System;
using System.Collections;
namespace TrabajoGrupal
{
	
	public class empresa
	{
		//atributos
		private ArrayList obrasFinalizadas;
		private ArrayList obrasEjecucion;
		private GrupoObrero[] gruposObreros;



		//constructor
		public empresa()
		{
			obrasFinalizadas = new ArrayList();
			obrasEjecucion = new ArrayList();
			gruposObreros = new GrupoObrero[8];
		}
		
		
		//propiedades
		public ArrayList ObrasFinalizadas
		{
			get{return obrasFinalizadas;}
			
		}
		public ArrayList ObrasEjecucion
		{
			get{return obrasEjecucion;}
			
		}
		
		public GrupoObrero[] GruposObreros
		{get { return gruposObreros;}}

		//metodos
		//metodos Obras finalizadas
		public void agregarObraFinalizada(obra a)
		{
			{
				obrasFinalizadas.Add(a);
				if(a.Avance<100){agregarObraEnEjecucion(a);}
			}
		}
		public void mostrarObrasFinalizadas()
		{
			foreach (obra a in obrasFinalizadas)
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("Nombre: {0}, dni: {1}, tipo{2}, tiempo: {3}, avance: {4}, código de grupo: {5}, costo: {6}", a.Nombre, a.DniPropietario, a.Tipo, a.Tiempo, a.Avance, a.Grupo, a.Costo);
				Console.ResetColor();
			}
		}
		public int ExisteObraFinalizada(int cod)
		{
			foreach (obra a in ObrasFinalizadas)
			{
				if (a.CodigoInterno == cod)
				{
					return ObrasFinalizadas.IndexOf(a);
				}
			}
			return -1;
		}
		public void EliminarObraFinalizada(int a)
		{
			if (a != -1)
			{
				obrasFinalizadas.RemoveAt(a);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("La obra ha sido eliminado con exito. ");
				Console.ResetColor();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("No existe esa obra o ya ha sido eliminado. ");
				Console.ResetColor();
			}
		}
		//metodos Obras en ejecucion
		public void agregarObraEnEjecucion(obra a)
		{
			{
				obrasEjecucion.Add(a);
				if(a.Avance>=100){agregarObraFinalizada(a);}
			}
		}
		public void mostrarObrasEjecucion()
		{
			foreach (obra a in obrasEjecucion)
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("Nombre: {0}, dni: {1}, tipo{2}, tiempo: {3}, avance: {4}, código de grupo: {5}, costo: {6}, codigo Interno: {7}",a.Nombre,a.DniPropietario,a.Tipo,a.Tiempo,a.Avance,a.Grupo,a.Costo, a.CodigoInterno);
				Console.ResetColor();
			}
		}
		public void EliminarObraEnEjecucion(int a)
		{
			if (a!=-1)
			{
				ObrasEjecucion.RemoveAt(a);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("La obra ha sido eliminado con exito. ");
				Console.ResetColor();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("No existe ese obrero o ya ha sido eliminado. ");
				Console.ResetColor();
			}
		}
		public int ExisteObraEnEjecucion(int cod)
		{
			foreach (obra a in ObrasEjecucion)
			{
				if (a.CodigoInterno==cod)
				{
					return obrasEjecucion.IndexOf(a);
				}
			}
			return -1;
		}
		public void ModificarAvanceEjecucion(double av,obra EmpObra, empresa a)
		{
			
			foreach (obra o in a.ObrasEjecucion)
			{
				if (o==EmpObra)
				{o.Avance=av;}
			}
			
		}
		//metodos de grupos obreros
		public bool existeGrupoObrero(int codigoObra)
		{
			foreach (GrupoObrero g in gruposObreros)
			{
				if (g != null && g.CodigoObra == codigoObra)
				{
					return true;
				}
			}
			return false;
		}
		
		public void agregarGrupoObrero(GrupoObrero g)
		{
			for (int i = 0; i < gruposObreros.Length; i++)
			{//agregamos donde este vacio
				if (gruposObreros[i] == null)
				{
					gruposObreros[i] = g;
					break;
				}
			}
		}
		public void eliminarGrupoObrero(int codigoObra)
		{
			for (int i = 0; i < gruposObreros.Length; i++)
			{
				if (gruposObreros[i] != null && gruposObreros[i].CodigoObra == codigoObra)
				{
					gruposObreros[i] = null;
					break;
				}
			}
		}
		public void mostrarGruposObreros()
		{
			foreach (GrupoObrero g in gruposObreros)
			{
				if (g != null)
				{
					g.MostrarGrupo();
				}
			}
		}
	}
}
