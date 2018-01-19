/*
 * Created by SharpDevelop.
 * User: jose.avila
 * Date: 09/29/2015
 * Time: 10:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using Microsoft.Win32;
using LanzadorAplicaciones;

namespace LanzadorWPF
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private AplicacionLista AppLista;
		private const string ARCHIVO = "app.dat";
		
		public Window1()
		{
			InitializeComponent();
			
			AppLista = (AplicacionLista) Serializador.Deserializar(ARCHIVO);
			
			if (AppLista == null) {
				AppLista = new AplicacionLista();
			}
			
			LlenarList();
		}
		
		void LlenarList()
		{
			AppLista.Reordenar();
			LvApp.DataContext = AppLista.ToArray();
		}
		
		void Guardar()
		{
			Serializador.Serializar(ARCHIVO, AppLista);
		}
		
		void Agregar()
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "EXE files (*.exe)|*.exe|JAR files|*.jar";
			open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			
			if (open.ShowDialog() == true) {
				Aplicacion app = new Aplicacion(open.FileName);
				AppLista.Agregar(app);
			}
		}
		
		void Eliminar()
		{
			if (LvApp.SelectedItem == null)
				return;
			
			var temp = LvApp.SelectedItem as Aplicacion;
			AppLista.Remover(temp);
		}
		
		void Lanzar()
		{
			if (LvApp.SelectedItem == null)
				return;
			
			var temp = LvApp.SelectedItem as Aplicacion;
			
			try {
				Process.Start(temp.Ruta);
				AppLista.GetElemento(temp.Nombre).Incrementar();
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
		
		void btnLazar_Click(object sender, RoutedEventArgs e)
		{
			Lanzar();
			LlenarList();
		}
		
		void btnAgregar_Click(object sender, RoutedEventArgs e)
		{
			Agregar();
			LlenarList();
		}
		
		void btnEliminar_Click(object sender, RoutedEventArgs e)
		{
			Eliminar();
			LlenarList();
		}
		
		void btnReiniciar_Click(object sender, RoutedEventArgs e)
		{
			AppLista.ReiniciarHits();
			LlenarList();
		}
		
		void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Guardar();
		}
		
		void LvApp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			btnLazar_Click(sender, e);
		}
	}
}