using System;
using System.Collections;
namespace TrabajoGrupal
{
	
	public class obrero
	{
		// atributos
		private string nomyape;
		private int dni;
		private int legajo;
		private string cargo;
		private GrupoObrero obreroGrupo;
		

		//propiedades
		
		public string Nomyape
		{
			get
			{
				return nomyape;
			}
			set{nomyape = value;}
		}
		public int Dni
		{
			get{return dni;}
			set{dni = value;}
		}
		public int Legajo
		{
			get{return legajo;}
			set{legajo = value;}
		}
		public string Cargo
		{
			get{return cargo;}
			set{cargo = value;}
		}
		public GrupoObrero ObreroGrupo
		{
			get{return obreroGrupo;}
			set{obreroGrupo = value;}
			
		}
		
		// constructor
		public obrero(string nomyape, int dni, int legajo, string cargo, GrupoObrero obreroGrupo)
		{
			this.nomyape = nomyape;
			this.dni = dni;
			this.legajo = legajo;
			this.cargo = cargo;
			this.obreroGrupo=obreroGrupo;
		}
		//metodo
		public void MostrarObrero()
		{
			Console.WriteLine("Nombre y Apellido: " + Nomyape);
			Console.WriteLine("DNI: " + Dni);
			Console.WriteLine("Legajo: " + Legajo);
			Console.WriteLine("Cargo: " + Cargo);
		}
		
	}
}



