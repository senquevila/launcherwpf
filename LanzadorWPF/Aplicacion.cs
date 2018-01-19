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
		string nombre;
		string ruta;
		int hits;
		
		public Aplicacion(string nombre, string ruta)
		{
			SetRuta(ruta);
			SetNombre(nombre);			
		}
		
		public Aplicacion(string ruta)
		{
			int pos1 = ruta.LastIndexOf("\\") + 1;
			int pos2 = ruta.Length;
			SetNombre(ruta.Substring(pos1, pos2 - pos1));
			SetRuta(ruta);
		}
		
		public void SetRuta(string ruta) {
			this.ruta = ruta;
		}
		
		public void SetNombre(string nombre) {
			this.nombre = nombre;
		}
		
		public void SetHits() {
			this.hits++;
		}
		
		public string GetRuta() {
			return this.ruta;
		}
		
		public string GetNombre() {
			return this.nombre;
		}
		
		public int GetHits() {
			return this.hits;
		}
		
		public override string ToString() {
			return GetNombre();
		}
		
		public void ReiniciarHits() {
			this.hits = 0;
		}
		
		
	}
}
