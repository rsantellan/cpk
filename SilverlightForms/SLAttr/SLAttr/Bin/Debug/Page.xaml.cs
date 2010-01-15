using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLAttr
{
    public partial class Page : UserControl
    {
        int Flia = 29;
        System.Collections.ObjectModel.ObservableCollection<SLAttr.DBService.AtributoInformacionGeneral> ListAttr;

        public Page()
        {
            InitializeComponent();
            this.Flia = 29;
            this.CargaAttr();
        }

        private void CargaAttr()
        {

            DBService.DBService2Client proxy = new SLAttr.DBService.DBService2Client();
            proxy.GetAtributoPorIDCompleted += new EventHandler<SLAttr.DBService.GetAtributoPorIDCompletedEventArgs>(proxy_GetAtributoPorIDCompleted);
            //this.ErrorConsole.Text = Convert.ToString(this.Flia);
            proxy.GetAtributoPorIDAsync(this.Flia);

        }

        void proxy_GetAtributoPorIDCompleted(object sender, SLAttr.DBService.GetAtributoPorIDCompletedEventArgs e)
        {
            this.ListAttr = e.Result;
            this.GridAttr.ItemsSource = this.ListAttr;

        }

        private void GridAttr_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            this.GridAttr.Columns[0].Visibility = Visibility.Collapsed;
            this.GridAttr.Columns[1].Visibility = Visibility.Collapsed;
            this.GridAttr.Columns[2].Visibility = Visibility.Collapsed;
            this.GridAttr.Columns[3].Visibility = Visibility.Collapsed;
            this.GridAttr.Columns[4].Visibility = Visibility.Collapsed;
            this.GridAttr.Columns[5].Visibility = Visibility.Collapsed;
            this.GridAttr.Columns[6].Visibility = Visibility.Collapsed;
            this.GridAttr.Columns[8].Visibility = Visibility.Collapsed;
            this.GridAttr.Columns[9].Visibility = Visibility.Collapsed;


        }



        void proxy_GetAtributoPorNombreCompleted(object sender, SLAttr.DBService.GetAtributoPorNombreCompletedEventArgs e)
        {
            this.GridAttrNom.ItemsSource = e.Result;
        }

        private void GridAttrNom_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            this.GridAttrNom.Columns[0].Visibility = Visibility.Collapsed;
            this.GridAttrNom.Columns[1].Visibility = Visibility.Collapsed;
            this.GridAttrNom.Columns[2].Visibility = Visibility.Collapsed;
            this.GridAttrNom.Columns[3].Visibility = Visibility.Collapsed;
            this.GridAttrNom.Columns[4].Visibility = Visibility.Collapsed;
            this.GridAttrNom.Columns[5].Visibility = Visibility.Collapsed;
            this.GridAttrNom.Columns[6].Visibility = Visibility.Collapsed;
            this.GridAttrNom.Columns[8].Visibility = Visibility.Collapsed;
            this.GridAttrNom.Columns[9].Visibility = Visibility.Collapsed;

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            this.ListAttr.Add((DBService.AtributoInformacionGeneral)this.GridAttrNom.SelectedItem);

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            this.UlIDFlia();
            DBService.DBService2Client proxy = new SLAttr.DBService.DBService2Client();
            proxy.GetAtributoPorNombreCompleted += new EventHandler<SLAttr.DBService.GetAtributoPorNombreCompletedEventArgs>(proxy_GetAtributoPorNombreCompleted);
            proxy.GetAtributoPorNombreAsync(this.txtbuscar.Text);
        }


        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            this.ListAttr.Remove((DBService.AtributoInformacionGeneral)this.GridAttr.SelectedItem);
            this.GridAttr.ItemsSource = this.ListAttr;
        }

        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            DBService.DBService2Client proxy = new SLAttr.DBService.DBService2Client();
            proxy.SaveAttrFliaCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(proxy_SaveAttrFliaCompleted);
            proxy.SaveAttrFliaAsync(this.ListAttr, this.Flia);
          }

        void proxy_SaveAttrFliaCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.ErrorConsole.Text = "Se guardan los atributos con Exito";
        }

        private void UlIDFlia() { 
        DBService.DBService2Client proxy = new SLAttr.DBService.DBService2Client();
        proxy.GetFliaUltimoIDCompleted += new EventHandler<SLAttr.DBService.GetFliaUltimoIDCompletedEventArgs>(proxy_GetFliaUltimoIDCompleted);
        proxy.GetFliaUltimoIDAsync(this.txtbuscar.Text);
        }

        void proxy_GetFliaUltimoIDCompleted(object sender, SLAttr.DBService.GetFliaUltimoIDCompletedEventArgs e)
        {
            this.ErrorConsole.Text = Convert.ToString(e.Result);
        }

    }
}

