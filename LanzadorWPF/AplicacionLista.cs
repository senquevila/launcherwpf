/*
 * Created by SharpDevelop.
 * User: jose.avila
 * Date: 7/24/2015
 * Time: 3:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace LanzadorAplicaciones
{
	/// <summary>
	/// Description of AplicacionLista.
	/// </summary>
	/// 
	[Serializable]
	public class AplicacionLista
	{
		private List<Aplicacion> Aplicaciones;
		
		public AplicacionLista()
		{
			Aplicaciones = new List<Aplicacion>();
		}

		public void Agregar(Aplicacion app)
		{
			Aplicaciones.Add(app);
		}
		
		public void Remover(Aplicacion app)
		{
			Aplicaciones.Remove(app);
		}
		
		public Aplicacion GetElemento(string nombre)
		{
			foreach (Aplicacion app in Aplicaciones) {
				if (app.GetNombre().Equals(nombre)) {
					return app;
				}
			}
			
			return null;
		}
		
		public Aplicacion[] ToArray()
		{
			int indice = 0;
			Aplicacion[] apps = new Aplicacion[Aplicaciones.Count];
			
			foreach (Aplicacion app in Aplicaciones) {
				apps[indice++] = app;
			}
			
			return apps;
		}
		
		public void Reordenar()
		{
			List<Aplicacion> Tmp;
			
			Tmp = new List<Aplicacion>();
			
			var query =
				from app in Aplicaciones				
				orderby app.GetHits() descending, app.GetNombre()
				select app;
				
			
			foreach(Aplicacion app in query) {
				Tmp.Add(app);
			}
			
			Aplicaciones = Tmp;
		}
		
		public void ReiniciarHits()
		{
			List<Aplicacion> Tmp;
				
			Tmp = new List<Aplicacion>();
			
			foreach(Aplicacion app in Aplicaciones) {
				Aplicacion TmpApp;
				
				TmpApp = app;
				TmpApp.ReiniciarHits();
				Tmp.Add(TmpApp);
			}
			
			Aplicaciones = Tmp;
		}
	}
}
