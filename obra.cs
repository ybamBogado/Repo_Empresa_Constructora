using System;
using System.Collections;

namespace TrabajoGrupal
{

	/// Description of obra.
	public class obra
	{
		//atributos
		private string nombre;
		private int dniPropietario;
		private static int contadorObra=1;
		private int codigoInterno;
		private string tipo;
		private int tiempo;
		private double avance;
		private GrupoObrero grupo;
		private int costo;
		
		
		//constructor
		public obra(string nombre,int dniPropietario,string tipo, int tiempo, double avance,GrupoObrero grupo, int costo )
		{
			this.nombre = nombre;
			this.dniPropietario= dniPropietario;
			this.tipo = tipo;
			this.tiempo = tiempo;
			this.avance = avance;
			this.grupo =grupo;
			this.costo = costo;
			codigoInterno=contadorObra++;
		}

		//propiedades
		public string Nombre
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
		public int DniPropietario
		{
			get
			{
				return dniPropietario;
			}
			set
			{
				dniPropietario = value;
			}
		}
		public static int ContadorObra{get{return contadorObra;}set{contadorObra=value;}}
		
		public  int CodigoInterno{get{return codigoInterno;}set{codigoInterno = value;}}
		
		public string Tipo
		{
			get
			{
				return tipo;
			}
			set
			{
				tipo = value;
			}
			
		}
		public int Tiempo
		{
			get
			{
				return tiempo;
			}
			set
			{
				tiempo = value;
			}
		}
		public double Avance
		{
			get
			{
				return avance;
			}
			set
			{
				avance = value;
			}
		}
		public GrupoObrero Grupo
		{
			get
			{
				return grupo;
			}
			set
			{
				grupo = value;
			}
		}
		public int Costo
		{
			get
			{
				return costo;
			}
			set
			{
				costo = value;
			}
		}
		//metodos
		public void MostrarObra()
		{
		
		}
		
	}
}
