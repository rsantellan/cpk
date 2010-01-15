using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AttrForm
{
    public class TNode : TreeViewItem
    {
        private int _idnodo;
        private int _idparent;
        private string _nombrenodo;
        private int _idatt;
  
        

        public int IDNode { get { return _idnodo;} set {_idnodo=value ;} }
        public int IDParent { get { return _idparent; } set { _idparent = value; } }
        public string NomNodo { get { return _nombrenodo; } set { _nombrenodo = value; } }
        public int IDAtt { get { return _idatt; } set { _idatt = value; } }
       
                 
      }
}
