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
using System.Windows.Data;

namespace AttrForm
{
	public partial class MainPage : UserControl
	{
        private TNode SelItem = null;
        private int IDAttributo;
        private int IDNewItem;
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
            this.OcultarGrids();
            IDAttributo = 1;
            CargaArbol();
		}
         private void TreeViewEvent(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView tr = sender as TreeView;
            this.SelItem = (TNode)tr.SelectedItem;

            if (tr != null)
            {
                if (this.SelItem.Items.Count != 0 || this.SelItem.IDParent == 1)
                {
                    this.CleanScreen();
                    this.Campo.Visibility = Visibility.Collapsed;
                    this.Registro.Visibility = Visibility.Visible;
                    this.CargaForm();
                }
                else
                {
                    this.CleanScreen();
                    this.Registro.Visibility = Visibility.Collapsed;
                    this.Campo.Visibility = Visibility.Visible;
                    this.CargaForm();
                }

            }
        }
              

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ErrorConsole.Text = "";

            TNode Tri = new TNode();

            Tri.Header = this.NewItem.Text;
            if (SelItem.IDParent != 0)
            {
                TNode Padre = (TNode)this.SelItem.Parent;
                if ((string)Padre.Header == "root" | ((string)SelItem.Header == "root"))
                {
                    if (this.NewItem.Text != "")
                    {
                        Tri.Header = this.NewItem.Text;
                        Tri.Name = this.NewItem.Text;
                        Tri.IDAtt = this.IDAttributo;
                        Tri.IDParent = this.SelItem.IDNode;
                        this.SaveNode(Tri);
                        Tri.IDNode = this.IDNewItem;
                        this.SelItem.Items.Add(Tri);
                        this.NewItem.Text = "";
                    }
                    else { this.ErrorConsole.Text = "Error No se pueden agregar subItems a " + (String)SelItem.Header; }
                }
                else
                {
                    this.ErrorConsole.Text = "Error No se pueden agregar subItems a " + (String)SelItem.Header;
                    this.NewItem.Text = "";
                }
            }
            else
            {
                Tri.Header = this.NewItem.Text;
                this.SelItem.Items.Add(Tri);
                this.NewItem.Text = "";
            }
        }
        private void OcultarGrids()
        {
            Registro.Visibility = Visibility.Collapsed;
            Campo.Visibility = Visibility.Collapsed;
        }
           private void CargaGrid_Click(object sender, RoutedEventArgs e)
        {
            DBService.DBServiceClient proxy = new AttrForm.DBService.DBServiceClient();
            proxy.GetTreeAsync(this.IDAttributo);
        }
        private void CargaArbol()
        {
            DBService.DBServiceClient proxy = new AttrForm.DBService.DBServiceClient();
            proxy.GetTreeCompleted += new EventHandler<AttrForm.DBService.GetTreeCompletedEventArgs>(proxy_GetTreeCompleted);
            proxy.GetTreeAsync(this.IDAttributo);
         }
        void proxy_GetTreeCompleted(object sender, AttrForm.DBService.GetTreeCompletedEventArgs e)
        {
           TNode root = new TNode();
            foreach (AttrForm.DBService.TreeNodos trn in e.Result)
            {
                
                if (trn.IDParent == 0)
                {
                    root.Header = trn.NomTree;
                    root.NomNodo = trn.NomTree;
                    root.IDParent = Convert.ToInt32(trn.IDParent);
                    root.IDAtt = Convert.ToInt32(trn.IDAttr);
                    root.IDNode = Convert.ToInt32(trn.IDTree);
                    this.TreeForm.Items.Add(root);
                }
            }
            foreach (AttrForm.DBService.TreeNodos trn1 in e.Result)
                    {
                        if (trn1.IDParent == root.IDNode)
                        {
                            TNode treeitemCH = new TNode();
                            treeitemCH.Header = trn1.NomTree;
                            treeitemCH.NomNodo = trn1.NomTree;
                            treeitemCH.IDParent = Convert.ToInt32(trn1.IDParent);
                            treeitemCH.IDAtt = Convert.ToInt32(trn1.IDAttr);
                            treeitemCH.IDNode = Convert.ToInt32(trn1.IDTree);
                            root.Items.Add(CargaHojas(treeitemCH,e));
                         }
                     }
                  }

        private TNode CargaHojas(TNode pTNode, AttrForm.DBService.GetTreeCompletedEventArgs e)
        {
            foreach (AttrForm.DBService.TreeNodos trn2 in e.Result)
            {
                if (trn2.IDParent == pTNode.IDNode)
                {
                    TNode treeitemH = new TNode();
                    treeitemH.Header = trn2.NomTree;
                    treeitemH.IDParent = Convert.ToInt32(trn2.IDParent);
                    treeitemH.IDAtt = Convert.ToInt32(trn2.IDAttr);
                    treeitemH.IDNode = Convert.ToInt32(trn2.IDTree);
                    pTNode.Items.Add(treeitemH);
                }
            }
            return pTNode;
        }

        private void SaveNode(TNode pTnode) {
            DBService.DBServiceClient proxy = new AttrForm.DBService.DBServiceClient();
            proxy.SaveNodeCompleted += new EventHandler<AttrForm.DBService.SaveNodeCompletedEventArgs>(proxy_SaveNodeCompleted);    
             proxy.SaveNodeAsync(pTnode.IDParent,pTnode.IDAtt,(string)pTnode.Header);
        }

        void proxy_SaveNodeCompleted(object sender, AttrForm.DBService.SaveNodeCompletedEventArgs e)
        {
          
            this.IDNewItem = Convert.ToInt32(e.Result);
            this.ErrorConsole.Text = Convert.ToString(this.SelItem.IDNode);
        }

        private void CargaForm() {

            DBService.DBServiceClient proxy = new AttrForm.DBService.DBServiceClient();
            proxy.GetItemCompleted += new EventHandler<AttrForm.DBService.GetItemCompletedEventArgs>(proxy_GetItemCompleted);
        proxy.GetItemAsync(this.SelItem.IDNode);     
        }

        void proxy_GetItemCompleted(object sender, AttrForm.DBService.GetItemCompletedEventArgs e)
        {
                  
            if (this.SelItem.Items.Count == 0 && this.SelItem.IDParent !=1 ){

                foreach (AttrForm.DBService.TreeEstructuraItems trnit in e.Result)
                {
                    this.CampoDecimales.Text = Convert.ToString(trnit.Decimales);
                    this.CampoLargo.Text = Convert.ToString(trnit.Largo);
                    if (trnit.EsRequerido == true)
                    {
                        this.CampoRequerido.IsChecked = true;
                    }
                    else { this.CampoRequerido.IsChecked = false; }

                    if (trnit.SoloLectura == true)
                    {
                        this.CampoSoloLectura.IsChecked = true;
                    }
                    else { this.CampoSoloLectura.IsChecked = false; }

                    foreach (ComboBoxItem cbi in this.CampoTipo.Items)
                        if ((Convert.ToString(cbi.Content)) == trnit.Tipo)
                        {
                           this.CampoTipo.SelectedItem = cbi;
                        }
                    foreach (ComboBoxItem cbi in this.CampoSubTipo.Items)
                        if ((Convert.ToString(cbi.Content)) == trnit.SubTipo)
                        { this.CampoSubTipo.SelectedItem = cbi; }
                }
            }
            else
            {
                foreach (AttrForm.DBService.TreeEstructuraItems trnit in e.Result)
                {
                    this.RegistroAgrupacion.Text = this.SelItem.NomNodo;

                    if (trnit.EsRequerido == true)
                    {
                        this.RegistroEsRequerido.IsChecked = true;
                    }
                    else { this.RegistroEsRequerido.IsChecked = false; }

                    if (trnit.SoloLectura == true)
                    {
                        this.RegistroSoloLectura.IsChecked = true;
                    }
                    else { this.RegistroSoloLectura.IsChecked = false; }

                    if (trnit.MultiSeleccion == true)
                    {
                        this.RegistroMulseleccion.IsChecked = true;
                    }
                    else { this.RegistroMulseleccion.IsChecked = false; }

                    foreach (ComboBoxItem cbi in this.RegistroOrigenDeDatos.Items)
                        if ((Convert.ToString(cbi.Content)) == trnit.OrigenDeDatos)
                        {this.RegistroOrigenDeDatos.SelectedItem = cbi;}

                    foreach (ComboBoxItem cbi in this.RegistroSubTipo.Items)
                        if ((Convert.ToString(cbi.Content)) == trnit.SubTipo)
                        { this.RegistroSubTipo.SelectedItem = cbi; }

                    this.RegistroValores.Text = trnit.Valores;
                    this.RegistroRuta.Text = trnit.Ruta;
                    this.RegistroMetodo.Text = trnit.Metodo;

                }

                }
            
                }

                 public void CleanScreen() { 
                 this.CampoDecimales.Text = "";
                 this.CampoLargo.Text = "";
                 this.CampoRequerido.IsChecked = false;
                 this.CampoSoloLectura.IsChecked = false;
                 this.CampoTipo.SelectedItem = null;
                 this.CampoSubTipo.SelectedItem = null; 
                 this.RegistroAgrupacion.Text = "";
                 this.RegistroMulseleccion.IsChecked = false;
                 this.RegistroOrigenDeDatos.SelectedItem = null;
                 this.RegistroValores.Text = "";
                 this.RegistroRuta.Text = "";
                 this.RegistroMetodo.Text = "";
                 this.RegistroSubTipo.SelectedItem = null;
                 this.RegistroEsRequerido.IsChecked = false;
                 this.RegistroSoloLectura.IsChecked = false;
        }

            

            void proxy_SaveNodeEstructureCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                this.ErrorConsole.Text = "Se Guardo Correctamente";
            }

            private void CampoSave_Click(object sender, RoutedEventArgs e)
            {
                DBService.DBServiceClient proxy = new AttrForm.DBService.DBServiceClient();
                proxy.SaveNodeEstructureCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(proxy_SaveNodeEstructureCompleted);

                int pIDTree = this.SelItem.IDNode;
                ComboBoxItem cb = (ComboBoxItem)this.CampoTipo.SelectedItem;
                string pTipo = Convert.ToString(cb.Content);
                int pLargo = Convert.ToInt32(this.CampoLargo.Text);
                bool pEsReq;
                if (this.CampoRequerido.IsChecked == true) { pEsReq = true; } else { pEsReq = false;}
                bool pSolol;
                if (this.CampoSoloLectura.IsChecked == true) { pSolol = true; } else { pSolol = false;}
                int pDecimales = Convert.ToInt32(this.CampoDecimales.Text);
                ComboBoxItem cbt = (ComboBoxItem)this.CampoSubTipo.SelectedItem;
                string pSubTipo = Convert.ToString(cbt.Content);
             

                proxy.SaveNodeEstructureAsync(pIDTree,pEsReq,pSolol,false,pSubTipo,null,null,null,null,pTipo,pLargo,pDecimales);

            }

            private void RegistroSave_Click(object sender, RoutedEventArgs e)
            {
                DBService.DBServiceClient proxy = new AttrForm.DBService.DBServiceClient();
                proxy.SaveNodeEstructureCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(proxy_SaveNodeEstructureCompleted);

                int pIDTree = this.SelItem.IDNode;
                
                bool pEsReq;
                if (this.RegistroEsRequerido.IsChecked == true) { pEsReq = true; } else { pEsReq = false; }
                
                bool pSolol;
                if (this.RegistroSoloLectura.IsChecked == true) { pSolol = true; } else { pSolol = false; }
                
                bool pMulti;
                if (this.RegistroMulseleccion.IsChecked == true) { pMulti = true; } else { pMulti = false; }
                
                ComboBoxItem cbt = (ComboBoxItem)this.RegistroSubTipo.SelectedItem;
                string pSubTipo = Convert.ToString(cbt.Content);
              
                ComboBoxItem cbt1 = (ComboBoxItem)this.RegistroOrigenDeDatos.SelectedItem;
                string pOrigenDatos = Convert.ToString(cbt1.Content);

                string pValores = this.RegistroValores.Text;
                
                string pRuta = this.RegistroRuta.Text;

                string pMetodo = this.RegistroMetodo.Text;
                
                proxy.SaveNodeEstructureAsync(pIDTree,pEsReq,pSolol,pMulti,pSubTipo,pOrigenDatos,pValores,pRuta,pMetodo,null,0,0);
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {

            }
            
             }
	}
