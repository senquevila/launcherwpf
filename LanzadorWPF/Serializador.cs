/*
 * Created by SharpDevelop.
 * User: jose.avila
 * Date: 7/24/2015
 * Time: 3:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LanzadorAplicaciones
{
	/// <summary>
	/// Description of Serializador.
	/// </summary>
	public static class Serializador
	{
		public static void Serializar(string archivo, object objeto)
		{
			FileStream fs = new FileStream(archivo, FileMode.Create);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, objeto);
			fs.Close();
		}
		
		public static object Deserializar(string archivo)
		{
			FileStream fs = new FileStream(archivo, FileMode.OpenOrCreate);
			BinaryFormatter bf = new BinaryFormatter();
			object objeto;
			
			try {
				objeto = bf.Deserialize(fs);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				objeto = null;
			} finally {
				fs.Close();
			}
			
			return objeto;
		}		
	}
}