/*
 * Creado en SharpDevelop.
 * 
 */
using System;
using System.Collections;

namespace TrabajoGrupal
{
	/// Description of GrupoObrero.
	public class GrupoObrero
	{
		private static int recuentoGrupos=0;
		private int numeroGrupo;
		private int codigoObra;
		private ArrayList integrantes;
		
		//propiedades
		public static int RecuentoGrupos{get{return recuentoGrupos;}set{recuentoGrupos=value;}}
		public int NumeroGrupo
		{
			get { return numeroGrupo; }
			set { numeroGrupo = value; }
		}
		public int CodigoObra
		{
			get { return codigoObra; }
			set { codigoObra = value; }
		}
		public ArrayList Integrantes
		{
			get { return integrantes;}
			set { integrantes = value;}
		}

		//Constructor
		public GrupoObrero(int Co)
		{
			codigoObra = Co;
			integrantes = new ArrayList();
			numeroGrupo=recuentoGrupos++;
		}

		//Metodos
		public void AgregarAlGrupo(obrero dato)
		{
			integrantes.Add(dato);
		}
		public int ExisteIntegrante(int doc)
		{
			foreach (obrero a in Integrantes)
			{
				if (a.Dni==doc)
				{
					return Integrantes.IndexOf(a);
				}
			}
			return -1;
		}
		public void EliminarIntegrante(int a)
		{
			if (a!=-1)
			{
				Integrantes.RemoveAt(a);
				
			}
			
		}
		public void MostrarGrupo()
		{
			Console.WriteLine("Número de Grupo: " + NumeroGrupo);
			Console.WriteLine("Código de Obra: " + CodigoObra);
			Console.WriteLine("Integrantes:");

			foreach (obrero integrante in Integrantes)
			{
				Console.WriteLine("Nombre y Apellido: " + integrante.Nomyape);
				Console.WriteLine("DNI: " + integrante.Dni);
				Console.WriteLine("Legajo: " + integrante.Legajo);
				Console.WriteLine("Cargo: " + integrante.Cargo);
			}
		}
	}
	public class SeExcedioGrupoObrerosException: Exception
	{
		private int grupos;
		//Esta excepcion se va a disparar cuando recuentoGrupos obreros sea 8
		public SeExcedioGrupoObrerosException(int grupos){this.grupos=grupos;}
		public SeExcedioGrupoObrerosException(int grupos,string message) : base(message) {this.grupos=grupos;}
		public SeExcedioGrupoObrerosException(int grupos,string message, Exception inner) : base(message, inner) {this.grupos=grupos;}
		//propiedades
		public int Grupos{get{return grupos;}set{grupos=value;}
			
		}
	}
}
