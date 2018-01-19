/*
 * Created by SharpDevelop.
 * User: jose.avila
 * Date: 7/24/2015
 * Time: 3:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace LanzadorAplicaciones
{
	/// <summary>
	/// Description of Aplicacion.
	/// </summary>
	/// 
	[Serializable]
	public class Aplicacion
	{
		public string Nombre {
			get;
			set;
		}
		
		public string Ruta {
			get;
			set;
		}
		
		public int Hits {
			get;
			set;
		}		
		
		public Aplicacion(string nombre, string ruta)
		{
			this.Nombre = nombre;
			this.Ruta = ruta;
			this.Hits = 0;
		}
		
		public Aplicacion(string ruta)
		{
			int pos1 = ruta.LastIndexOf("\\") + 1;
			int pos2 = ruta.Length;
			
			this.Nombre = ruta.Substring(pos1, pos2 - pos1);
			this.Ruta = ruta;
		}
		
		public void Incrementar()
		{
			this.Hits++;
		}
		
		public void Reiniciar() 
		{
			this.Hits = 0;
		}
	}
}
