using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable()]
public class AttrProducto
    {		private Decimal? _IDTree;
               private String _NomTree;
                private Decimal? _IDAttr;
                private String _Tipo;
                public AttrProducto(
                    Decimal? AIDTree, String ANomTree, Decimal? AIDAttr, String ATipo)
                {
                    _IDTree = AIDTree;
                    _NomTree = ANomTree;
                    _IDAttr = AIDAttr;
                    _Tipo = ATipo;
                }
                public Decimal? IDTree { get { return _IDTree; } }
                public String NomTree { get { return _NomTree; } }
                public Decimal? IDAttr { get { return _IDAttr; } }
                public String Tipo { get { return _Tipo; } }
        
}
