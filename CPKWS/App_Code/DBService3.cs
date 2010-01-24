using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class DBService3
{
    [OperationContract]
    public List<AtributoInformacionGeneral> GetAttrFlias(decimal pFliaID)
    {
        List<AtributoInformacionGeneral> Lsalida = new List<AtributoInformacionGeneral>();
        DataClassesDataContext db = new DataClassesDataContext();
        var AttrFlia = from item in db.FamiliaAtributo
                       where item.idFamilia == pFliaID
                       select item;
        AttrFlia.ToList();

        System.IO.StreamWriter sw2 = new System.IO.StreamWriter("c:\\temp\\dbconnPro.txt", true);
        sw2.WriteLine("Cant Attr " + AttrFlia.ToList().Count);
        sw2.WriteLine("ID Attr " + pFliaID);
        sw2.Close();

        foreach (FamiliaAtributo f in AttrFlia.ToList())
        {
            Lsalida.Add(GetAttrFliasAux(Convert.ToInt32(f.idAtributo)));
            System.IO.StreamWriter sw1 = new System.IO.StreamWriter("c:\\temp\\dbconnPro.txt", true);
            sw1.WriteLine("Entre id " + f.idAtributo);
            sw1.WriteLine("Largo de salida " + Lsalida.Count);
            sw1.Close();

        }
        System.IO.StreamWriter sw4 = new System.IO.StreamWriter("c:\\temp\\dbconnPro.txt", true);
        sw4.WriteLine("Largo de salida " + Lsalida.Count);
        sw4.Close();


        return Lsalida;

    }

    private AtributoInformacionGeneral GetAttrFliasAux(int pid)
    {
        System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\temp\\dbconnPro.txt", true);
        sw.WriteLine("Entre a Buscar Attr id " + pid);
        sw.Close();

        DataClassesDataContext db = new DataClassesDataContext();
        var Attrs = (from item in db.AtributoInformacionGeneral
                     where item.Identificador == pid
                     select item).Single();

        return (AtributoInformacionGeneral)Attrs;
    }


    [OperationContract]
    public List<ProductoEstructuraAttr> GetProductAttrExtruc(decimal pProductID, decimal pFliaID, decimal pAtibutoID)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var Attrs = from item in db.ProductoEstructuraAttr
                    where item.idFamilia == pFliaID
                    && item.idProducto == pProductID
                    && item.idAtributo == pAtibutoID
                    select item;
        return Attrs.ToList();
    }
	
 [OperationContract]
    public List<TreeNodos> GetAttrNodos(decimal pAtibutoID)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var AttrNodos = from item in db.TreeNodos
                    where item.IDAttr == pAtibutoID
                    select item;
        return AttrNodos.ToList();
    }
	
	[OperationContract]
    public List<AttrProducto> GetAttrNodosTipo(decimal pAtibutoID)
    {
        List<AttrProducto> salidaList = new List<AttrProducto>();
        DataClassesDataContext db = new DataClassesDataContext();
        var query =
             from t in db.TreeNodos
             from i in db.TreeEstructuraItems
             where
               t.IDTree == i.IDTreeEstructuraItem &&
               t.IDAttr == pAtibutoID &&
               i.Tipo != null &&
               i.Tipo != ""
             select new
             {
                 t.IDTree,
                 t.NomTree,
                 t.IDAttr,
                 i.Tipo
             };
        foreach (var r in query)
        {
            salidaList.Add(new AttrProducto(r.IDTree, r.NomTree, r.IDAttr, r.Tipo));
        }
        return salidaList;
    }
    }

 





















