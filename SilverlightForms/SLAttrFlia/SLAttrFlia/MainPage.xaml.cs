using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLAttrFlia
{
    public partial class MainPage : UserControl
    {
        int AttrSel;

        public MainPage()
        {
            // Required to initialize variables
            InitializeComponent();
            this.AttrSel = 1;
        }

        private void CargaAttributos()
        {

            

            //     proxy = new SLAttrFlia.DBService.DBService1Client();
            //        proxy.GetRulesCompleted += new EventHandler<SLReglas.DBService.GetRulesCompletedEventArgs>(proxy_GetRulesCompleted);
            //        proxy.GetRulesAsync (this.IDAttributo);
            //    }
            //}

            //private void proxy_GetRulesCompleted(object sender, SLReglas.DBService.GetRulesCompletedEventArgs e)
            //{
            //   this.ReglasGrid.ItemsSource = e.Result;
            //   this.ListRows = e.Result;


        }

    }
}

