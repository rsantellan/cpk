using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace SLReglas
{
	public partial class MainPage : UserControl
	{
        private int IDAttributo;
        private System.Collections.ObjectModel.Collection<SLReglas.DBService.AttrReglas> ListRows;
        public MainPage()
        {
            // Required to initialize variables
            InitializeComponent();
            SetAttr();
            CargaReglas();
            this.ReglasGrid.IsReadOnly = false;
        }

        private void SetAttr()
        {
            //IDAttributo = Convert.ToInt32(HtmlPage.Window.Invoke("getIdentifier"));
            this.IDAttributo = 1;
            this.ErrorConsole.Text = "Atributo "+Convert.ToString(IDAttributo);
        }

        private void CargaReglas()
        {
            if (IDAttributo == 0)
            {
                this.ErrorConsole.Text = "No se encontraron reglas para este atributo";
               
            }
            else
            {
                DBService.DBService1Client proxy = new SLReglas.DBService.DBService1Client();
                proxy.GetRulesCompleted += new EventHandler<SLReglas.DBService.GetRulesCompletedEventArgs>(proxy_GetRulesCompleted);
                proxy.GetRulesAsync (this.IDAttributo);
            }
        }

        void proxy_GetRulesCompleted(object sender, SLReglas.DBService.GetRulesCompletedEventArgs e)
        {
           this.ReglasGrid.ItemsSource = e.Result;
           this.ListRows = e.Result;
        
            
        }
       
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
         this.ListRows.Add(new DBService.AttrReglas());
         this.ReglasGrid.ItemsSource = this.ListRows;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {   DBService.AttrReglas item = (DBService.AttrReglas)this.ReglasGrid.SelectedItem;
            this.ListRows.Remove(item);
            this.ReglasGrid.ItemsSource = this.ListRows;
            ErrorConsole.Text = "Se elimino la Regla con Exito";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListRows.Count == 0) { ErrorConsole.Text = "No hay datos para guardar"; }
            else
            {
                this.GuardaRegla(ListRows, this.IDAttributo);
            }
        }

        private void GuardaRegla(System.Collections.ObjectModel.Collection<SLReglas.DBService.AttrReglas> preglas, int pIDattRel)
        {

            DBService.DBService1Client proxy = new SLReglas.DBService.DBService1Client();
            proxy.SaveRuleCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(proxy_SaveRuleCompleted);
            //proxy.SaveRuleCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(proxy_SaveRuleCompleted);
            //proxy.SaveRuleAsync(preglas,pIDattRel);
            proxy.SaveRuleAsync(preglas, pIDattRel);

        }

        void proxy_SaveRuleCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.ErrorConsole.Text = ("Se guardaron las Reglas correctamente");
        }

        //void proxy_SaveRuleCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    this.ErrorConsole.Text = ("Se guardaron las Reglas correctamente");
        //}

       
	}
}